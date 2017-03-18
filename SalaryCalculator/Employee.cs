using SalaryCalculator.TaxPlans;
using SalaryCalculator.Interfaces;

namespace SalaryCalculator
{
    /// <summary>
    /// Encapsulates all information about the employee
    /// </summary>
    public class Employee : IEmployee
    {
        decimal _rate;
        decimal _hours;
        ITaxPlan _plan;
        string _country;

        public decimal HourlyRate
        {
            get { return _rate; }
        }

        public decimal HoursWorked
        {
            get { return _hours; }
        }

        public string CountryOfWork
        {
            get { return _country; }
        }

        public ITaxPlan TaxPlan
        {
            get { return _plan; }
        }
        /// <summary>
        /// Calculates the gross salary, a total of 
        /// the worker's hourly rate multiplied by the total
        /// of hours worked. 
        /// </summary>
        /// <returns>Gross salary</returns>
        public decimal GetGrossSalary()
        {
            return _rate * _hours;
        }

        /// <summary>
        /// Calculates the net salary, deductions included,
        /// of the worker; based on the hourly rate and the total hours worked
        /// minus the deductions applicable depending on the country 
        /// where the worker works. 
        /// </summary>
        /// <returns>Net salary</returns>
        public decimal GetNetSalary()
        {
            decimal gross = GetGrossSalary();
            return gross - _plan.GetTotalDeductions(gross);
        }

        /// <summary>
        /// Mandatory ctor
        /// Injects the necessary parameters
        /// </summary>
        /// <param name="rate">The rate per hour</param>
        /// <param name="hours">The hours worked</param>
        /// <param name="plan">The national tax plan</param>
        public Employee(decimal rate, decimal hours, ITaxPlan plan)
        {
            _rate = rate;
            _hours = hours;
            _plan = plan;
            
            switch(plan.GetType().Name)
            {
                case "IrelandTaxPlan":
                    _country = "Ireland";
                    break;
                case "GermanyTaxPlan":
                    _country = "Germany";
                    break;
                case "ItalyTaxPlan":
                    _country = "Italy";
                    break;
                case "CaymanTaxPlan":
                    _country = "Cayman Islands";
                    break;
            }
        }
    }
}
