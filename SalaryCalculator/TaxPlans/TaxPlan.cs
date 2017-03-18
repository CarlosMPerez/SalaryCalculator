using SalaryCalculator.Interfaces;
using System;
using System.Collections.Generic;

namespace SalaryCalculator.TaxPlans
{
    /// <summary>
    /// The abstract tax plan
    /// Calculates the total tax deductions based on the provided
    /// gross salary and the concrete national plan implemented
    /// by the derived classes
    /// </summary>
    public abstract class TaxPlan : ITaxPlan
    {
        Dictionary<string, decimal> _deductions;

        public Dictionary<string, decimal> Deductions
        {
            get { return _deductions; }
        }
        /// <summary>
        /// The deductions collection.
        /// To be specified on each national plan
        /// </summary>
        internal abstract List<IDeduction> DeductionDefinitions
        {
            get;
        }

        /// <summary>
        /// Calculates the total deducted from the base salary according
        /// to the deductions specified on each plan.
        /// </summary>
        /// <returns>The total amount to deduct</returns>
        public decimal GetTotalDeductions(decimal baseSalary)
        {
            decimal totalDeductedAmount = 0;
            decimal currentDeductedAmount = 0;
            _deductions = new Dictionary<string, decimal>();

            foreach (IDeduction definition in DeductionDefinitions)
            {
                if (definition.GetType() == typeof(SimpleDeduction))
                {
                    currentDeductedAmount = GetSimpleDeduction(baseSalary,
                                                (SimpleDeduction)definition);
                    totalDeductedAmount += currentDeductedAmount;
                    _deductions.Add(definition.Name, 
                        FormatTwoDecimalSpaces(currentDeductedAmount));
                }
                else if (definition.GetType() == typeof(SectionDeduction))
                {
                    currentDeductedAmount = GetSectionDeduction(baseSalary,
                                            (SectionDeduction)definition);
                    totalDeductedAmount += currentDeductedAmount;
                    _deductions.Add(definition.Name, 
                        FormatTwoDecimalSpaces(currentDeductedAmount));
                }
            }

            return FormatTwoDecimalSpaces(totalDeductedAmount);
        }

        /// <summary>
        /// Calculates a <see cref="SimpleDeduction">Simple Deduction</see>.
        /// A <see cref="SimpleDeduction">simple seduction</see> is one 
        /// that's applied to the entire baseSalary, without sections
        /// </summary>
        /// <param name="baseSalary">The base salary</param>
        /// <param name="deduction">The <see cref="SimpleDeduction">Simple Deduction</see></param>
        /// <returns>The amount deducted from base salary, according to
        /// the deduction data</returns>
        private decimal GetSimpleDeduction(decimal baseSalary, SimpleDeduction deduction)
        {
            return FormatTwoDecimalSpaces((baseSalary / 100) * deduction.TaxDeductionPercentage);
        }

        /// <summary>
        /// Calculates a <see cref="SectionDeduction">Section Deduction</see>.
        /// A <see cref="SectionDeduction">section deduction</see> is 
        /// based on sections. For the first X amount of base salary, 
        /// where X is the section threshold, 
        /// there's a deduction rate Y to apply, and then there's a
        /// second deduction rate Z to apply to the rest of the base salary
        /// </summary>
        /// <param name="baseSalary">The base salary</param>
        /// <param name="deduction">The <see cref="SectionDeduction">Section Deduction</see> type, 
        /// expressing the threshold, first section rate and second section rate</param>
        /// <returns>The amount deducted from baseSalary, according to 
        /// the deduction data</returns>
        private decimal GetSectionDeduction(decimal baseSalary, 
                                        SectionDeduction deduction)
        {
            decimal currentDeductionAmount = 0;
            if (baseSalary > deduction.TaxSectionThreshold)
            {
                // 1st section
                currentDeductionAmount = (deduction.TaxSectionThreshold / 100) *
                    deduction.FirstTaxSectionDeductionPercentage;
                // 2nd section
                currentDeductionAmount += ((baseSalary - deduction.TaxSectionThreshold) / 100) *
                    deduction.SecondTaxSectionDeductionPercentage;
            }
            else
            {
                // Only 1st section
                currentDeductionAmount = (baseSalary / 100) * deduction.FirstTaxSectionDeductionPercentage;
            }

            return FormatTwoDecimalSpaces(currentDeductionAmount);
        }

        /// <summary>
        /// Formats the given number to just two decimal spaces
        /// 12.3567m => 12.36
        /// 12.3342m => 12.33
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        private decimal FormatTwoDecimalSpaces(decimal amount)
        {
            return decimal.Round(amount, 2, MidpointRounding.AwayFromZero);
        }
    }
}
