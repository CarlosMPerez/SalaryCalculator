using SalaryCalculator.TaxPlans;
using SalaryCalculator.Interfaces;
using System;

namespace SalaryCalculator
{
    /// <summary>
    /// Static class, cannot be instantiated
    /// Calculates the gross salary
    /// and the net salary, depending on the national
    /// tax plan provided
    /// </summary>
    public static class Calculator
    {

        /// <summary>
        /// Calculates the gross salary, a total of 
        /// the worker's hourly rate multiplied by the total
        /// of hours worked. 
        /// </summary>
        /// <param name="hourlyRate">The rate per hour</param>
        /// <param name="hoursWorked">The total hours worked</param>
        /// <returns>Gross salary</returns>
        public static decimal GetGrossSalary(decimal hourlyRate, decimal hoursWorked)
        {
            return hourlyRate * hoursWorked;
        }

        /// <summary>
        /// Calculates the net salary, deductions included,
        /// of the worker; based on the hourly rate and the total hours worked
        /// minus the deductions applicable depending on the country 
        /// where the worker works. 
        /// </summary>
        /// <param name="hourlyRate">The rate per hour</param>
        /// <param name="hoursWorked">The total amount of hours worked</param>
        /// <param name="taxPlan">An object implementing the ITaxPlan interface</param>
        /// <returns>Net salary</returns>
        public static decimal GetNetSalary(decimal hourlyRate, decimal hoursWorked, ITaxPlan taxPlan)
        {
            decimal gross = GetGrossSalary(hourlyRate, hoursWorked);
            gross -= ((TaxPlan) taxPlan).GetTotalDeductions(gross);
            return decimal.Round(gross, 2, MidpointRounding.AwayFromZero);
        }
    }
}
