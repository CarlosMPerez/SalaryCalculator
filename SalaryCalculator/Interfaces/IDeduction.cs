
namespace SalaryCalculator.Interfaces
{
    /// <summary>
    /// Base interface for deductions
    /// Empty, but its presence allows polymorphism
    /// </summary>
    public interface IDeduction
    {
        string Name { get; }
    }
}
