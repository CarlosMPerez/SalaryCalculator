using SalaryCalculator.Interfaces;
using SalaryCalculator.TaxPlans;
using System;

namespace SalaryCalculator
{
    class Program
    {
        /// <summary>
        /// Main program function
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                IntroData();
            } while (true);
        }

        /// <summary>
        /// Prompts the user to introduce all necessary data
        /// </summary>
        static void IntroData()
        {
            string input;
            int hoursWorked = 0;
            decimal hourlyRate = 0;

            Console.WriteLine("Welcome to the Salary Calculator Program.");
            // Get the worked hours
            do
            {
                Console.WriteLine("\n\nPlease enter the employee's WORKED HOURS.\nYou can press ESC anytime to exit: ");
                input = Utils.ReadInput();
            } while (!Utils.ValidateHours(input));
            hoursWorked = int.Parse(input);

            // Get the hourly rate
            do
            {
                Console.WriteLine("\n\nPlease enter the employee's HOURLY RATE.\nYou can press ESC anytime to exit: ");
                input = Utils.ReadInput();
            } while (!Utils.ValidateRate(input));
            hourlyRate = decimal.Parse(input);

            // Get the country
            do
            {
                Console.WriteLine("\n\nPlease enter the COUNTRY OF WORK." +
                    "\n\tEnter 1 for IRELAND" +
                    "\n\tEnter 2 for ITALY" +
                    "\n\tEnter 3 for GERMANY" +
                    "\n\tEnter 4 for CAYMAN ISLANDS" +
                    "\n\nYou can press ESC anytime to exit: ");
                input = Utils.ReadInput();
            } while (!Utils.ValidateCountry(input));

            Employee employee;

            switch(input)
            {
                case "1":
                    employee = new Employee(hourlyRate, hoursWorked, new IrelandTaxPlan());
                    ShowData(employee);
                    break;
                case "2":
                    employee = new Employee(hourlyRate, hoursWorked, new ItalyTaxPlan());
                    ShowData(employee);
                    break;
                case "3":
                    employee = new Employee(hourlyRate, hoursWorked, new GermanyTaxPlan());
                    ShowData(employee);
                    break;
                case "4":
                    employee = new Employee(hourlyRate, hoursWorked, new CaymanTaxPlan());
                    ShowData(employee);
                    break;
            }
        }

        /// <summary>
        /// Displays the employee salary report
        /// </summary>
        /// <param name="employee">The concrete employee</param>
        static void ShowData(Employee employee)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("************** EMPLOYEE SALARY REPORT **************");
            Console.WriteLine("\nCountry of Work: " + employee.CountryOfWork);
            Console.WriteLine("Gross Salary: " + 
                Utils.FormatToCurrency(employee.CountryOfWork, employee.GetGrossSalary()));
            Console.WriteLine("Deductions:");

            // We have to force the deduction calculation BEFORE
            // presenting the individual deduction collection so it's not null
            decimal totalDeductions = employee.TaxPlan.
                                GetTotalDeductions(employee.GetGrossSalary());
            foreach (var item in employee.TaxPlan.Deductions)
            {
                Console.WriteLine("\t" + item.Key + ": " +
                    Utils.FormatToCurrency(employee.CountryOfWork, item.Value));
            }

            Console.WriteLine("Total Deductions: " +
                Utils.FormatToCurrency(employee.CountryOfWork, totalDeductions));
            Console.WriteLine("Net Salary: " +
                Utils.FormatToCurrency(employee.CountryOfWork, employee.GetNetSalary()));

            Console.WriteLine("Press ENTER to continue.");
            Console.ReadLine();
        }
    }
}
