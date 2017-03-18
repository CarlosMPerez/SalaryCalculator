
namespace SalaryCalculator.Interfaces
{
    /// <summary>
    /// Interface for Simple Deduction
    /// </summary>
    public interface ISimpleDeduction : IDeduction
    {
        decimal TaxDeductionPercentage { get; }
    }
}
