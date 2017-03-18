using SalaryCalculator.Interfaces;

namespace SalaryCalculator.TaxPlans
{
    /// <summary>
    /// A simple tax deduction
    /// Has a simple flat percentage which is to be 
    /// applied to all the amount, no sections
    /// </summary>
    public class SimpleDeduction : ISimpleDeduction
    {
        private decimal _taxDeductionPercentage;
        private string _name;

        public decimal TaxDeductionPercentage
        {
            get { return _taxDeductionPercentage; }
        }

        public string Name
        {
            get { return _name; }
        }

        public SimpleDeduction(decimal TaxDeductionPercentage, string name)
        {
            _taxDeductionPercentage = TaxDeductionPercentage;
            _name = name;
        }
    }
}
