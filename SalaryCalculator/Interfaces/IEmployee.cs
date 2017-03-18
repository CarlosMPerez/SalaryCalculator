
namespace SalaryCalculator.Interfaces
{
    /// <summary>
    /// Interface for Employee
    /// </summary>
    public interface IEmployee
    {
        decimal HoursWorked { get; }

        decimal HourlyRate { get; }

        ITaxPlan TaxPlan { get; }

        string CountryOfWork { get; }

        decimal GetGrossSalary();

        decimal GetNetSalary();
    }
}
