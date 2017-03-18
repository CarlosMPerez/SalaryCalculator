using SalaryCalculator.Interfaces;
using System.Collections.Generic;

namespace SalaryCalculator.TaxPlans
{
    /// <summary>
    /// Ireland's concrete national tax plan
    /// Overrides abstract TaxPlan
    /// </summary>
    public class IrelandTaxPlan : TaxPlan, ITaxPlan
    {
        List<IDeduction> _deductionDefs;

        internal override List<IDeduction> DeductionDefinitions
        {
            get { return _deductionDefs; }
        }

        /// <summary>
        /// On each instancing adds the concrete
        /// Ireland's deductions to the tax plan
        /// </summary>
        public IrelandTaxPlan()
        {
            _deductionDefs = new List<IDeduction>();
            //Income tax (25% to first 600€, 40% to the rest)
            _deductionDefs.Add(new SectionDeduction(25, 40, 600, "Income Tax"));
            // Universal Social Charge  (7% to the first 500€, 8 to the rest)
            _deductionDefs.Add(new SectionDeduction(7, 8, 500, "Universal Social Charge"));
            // Pension (4%)
            _deductionDefs.Add(new SimpleDeduction(4, "Pension Contribution"));
        }
    }
}
