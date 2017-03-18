using SalaryCalculator.Interfaces;
using System.Collections.Generic;

namespace SalaryCalculator.TaxPlans
{
    /// <summary>
    /// Germany's concrete national tax plan
    /// Overrides abstract TaxPlan
    /// </summary>
    public class GermanyTaxPlan : TaxPlan, ITaxPlan
    {
        List<IDeduction> _deductionDefs;

        internal override List<IDeduction> DeductionDefinitions
        {
            get { return _deductionDefs; }
        }

        /// <summary>
        /// On each instancing adds the concrete
        /// Germany's deductions to the tax plan
        /// </summary>
        public GermanyTaxPlan()
        {
            _deductionDefs = new List<IDeduction>();
            // Income tax, first 400 € at 25%, the rest at 32%
            _deductionDefs.Add(new SectionDeduction(25, 32, 400, "Income Tax"));
            // Pension contribution, 2%
            _deductionDefs.Add(new SimpleDeduction(2, "Pension Contribution"));
        }
    }
}
