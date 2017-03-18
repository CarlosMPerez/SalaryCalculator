using SalaryCalculator.Interfaces;
using System.Collections.Generic;

namespace SalaryCalculator.TaxPlans
{
    /// <summary>
    /// Concrete tax plan for the Cayman Islands
    /// No deductions whatsoever
    /// Overrides abstract TaxPlan
    /// </summary>
    public class CaymanTaxPlan : TaxPlan, ITaxPlan
    {
        List<IDeduction> _deductionDefs;


        internal override List<IDeduction> DeductionDefinitions
        {
            get { return _deductionDefs; }
        }

        /// <summary>
        /// On each instancing adds the concrete
        /// Cayman Islands' deductions to the tax plan
        /// </summary>
        public CaymanTaxPlan()
        {
            _deductionDefs = new List<IDeduction>();
        }

    }
}
