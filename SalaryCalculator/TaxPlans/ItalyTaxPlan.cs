using SalaryCalculator.Interfaces;
using System.Collections.Generic;

namespace SalaryCalculator.TaxPlans
{
    /// <summary>
    /// Italy's concrete national tax plan
    /// Overrides abstract TaxPlan
    /// </summary>
    public class ItalyTaxPlan : TaxPlan, ITaxPlan
    {
        List<IDeduction> _deductionDefs;


        internal override List<IDeduction> DeductionDefinitions
        {
            get { return _deductionDefs; }
        }

        /// <summary>
        /// On each instancing adds the concrete
        /// Italy's deductions to the tax plan
        /// </summary>
        public ItalyTaxPlan()
        {
            _deductionDefs = new List<IDeduction>();
            // Income tax, 25%
            _deductionDefs.Add(new SimpleDeduction(25, "Income Tax"));
            // Pension contribution, 9.19%
            _deductionDefs.Add(new SimpleDeduction(9.19m, "INPS Contribution"));
        }
    }
}
