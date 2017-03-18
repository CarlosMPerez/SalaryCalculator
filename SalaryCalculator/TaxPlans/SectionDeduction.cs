using SalaryCalculator.Interfaces;

namespace SalaryCalculator.TaxPlans
{
    /// <summary>
    /// Defines a tax deduction in sections.
    /// There's a threshold section, a tax rate to apply to the first section
    /// and a tax rate to apply to the rest of the money
    /// </summary>
    public class SectionDeduction : ISectionDeduction
    {
        private decimal _firstTaxSectionDeductionPct;
        private decimal _secondtaxSectionDeductionPct;
        private decimal _taxSectionThreshold;
        private string _name;

        public decimal FirstTaxSectionDeductionPercentage
        {
            get { return _firstTaxSectionDeductionPct; }
        }

        public decimal SecondTaxSectionDeductionPercentage
        {
            get { return _secondtaxSectionDeductionPct; }
        }

        public decimal TaxSectionThreshold
        {
            get { return _taxSectionThreshold; }
        }

        public string Name
        {
            get { return _name; }
        }

        public SectionDeduction(decimal FirstTaxSectionDeductionPct, 
            decimal SecondTaxSectionDeductionPct, 
            decimal TaxSectionthreshold, 
            string name)
        {
            _firstTaxSectionDeductionPct = FirstTaxSectionDeductionPct;
            _secondtaxSectionDeductionPct = SecondTaxSectionDeductionPct;
            _taxSectionThreshold = TaxSectionthreshold;
            _name = name;
        }
    }
}
