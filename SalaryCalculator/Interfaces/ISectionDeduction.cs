
namespace SalaryCalculator.Interfaces
{
    /// <summary>
    /// Interface for Section Deduction
    /// </summary>
    public interface ISectionDeduction : IDeduction
    {
        decimal FirstTaxSectionDeductionPercentage { get; }

        decimal SecondTaxSectionDeductionPercentage { get; }

        decimal TaxSectionThreshold { get; }

    }
}
