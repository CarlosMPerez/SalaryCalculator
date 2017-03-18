
using System.Collections.Generic;

namespace SalaryCalculator.Interfaces
{
    /// <summary>
    /// Interface for Tax Plan
    /// </summary>
    public interface ITaxPlan
    {
        decimal GetTotalDeductions(decimal baseSalary);

        Dictionary<string, decimal> Deductions { get; }
    }
}
