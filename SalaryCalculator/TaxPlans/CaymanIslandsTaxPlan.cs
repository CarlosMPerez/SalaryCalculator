using SalaryCalculator.Interfaces;
using System.Collections.Generic;

namespace SalaryCalculator.TaxPlans
{
    /// <summary>
    /// Italy's concrete national tax plan
    /// Overrides abstract TaxPlan
    /// </summary>
    public class CaymanIslandsTaxPlan : TaxPlan, ITaxPlan
    {
        List<IDeduction> _deductions;


        public override List<IDeduction> Deductions
        {
            get { return _deductions; }
        }

        /// <summary>
        /// On each instancing adds the concrete
        /// Cayman Islands' deductions to the tax plan
        /// of which they have NONE
        /// </summary>
        public CaymanIslandsTaxPlan()
        {
            _deductions = new List<IDeduction>();
        }
    }
}
