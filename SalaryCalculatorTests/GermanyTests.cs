using SalaryCalculator;
using SalaryCalculator.TaxPlans;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalaryCalculatorTests
{
    /// <summary>
    /// Summary description for GermanyTests
    /// </summary>
    [TestClass]
    public class GermanyTests
    {
        [TestMethod]
        public void GermanyTaxPlanGetGrossSalaryTest()
        {
            GermanyTaxPlan itp = new GermanyTaxPlan();
            Employee empOne = new Employee(250, 100, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            Assert.AreEqual(25000, empOne.GetGrossSalary());
            Assert.AreEqual(2840.48m, empTwo.GetGrossSalary());
        }

        [TestMethod]
        public void GermanyTaxPlanGetNetSalaryTests()
        {
            GermanyTaxPlan itp = new GermanyTaxPlan();
            Employee empOne = new Employee(100, 250, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            Assert.AreEqual(16528, empOne.GetNetSalary());
            Assert.AreEqual(1902.72m, empTwo.GetNetSalary());
        }

        [TestMethod]
        public void GermanyTaxPlanGetTotalDeductions()
        {
            GermanyTaxPlan itp = new GermanyTaxPlan();
            Employee empOne = new Employee(250, 100, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            Assert.AreEqual(8472, empOne.TaxPlan.GetTotalDeductions(empOne.GetGrossSalary()));
            Assert.AreEqual(937.76m, empTwo.TaxPlan.GetTotalDeductions(empTwo.GetGrossSalary()));
        }

        [TestMethod]
        public void GermanyTaxPlanGetIndividualDeductions()
        {
            GermanyTaxPlan itp = new GermanyTaxPlan();
            Employee empOne = new Employee(250, 100, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            // Force the calculations
            empOne.TaxPlan.GetTotalDeductions(empOne.GetGrossSalary());
            Assert.AreEqual(2, empOne.TaxPlan.Deductions.Count);
            Assert.AreEqual(7972, empOne.TaxPlan.Deductions["Income Tax"]);
            Assert.AreEqual(500, empOne.TaxPlan.Deductions["Pension Contribution"]);

            //Force the calculations
            empTwo.TaxPlan.GetTotalDeductions(empTwo.GetGrossSalary());
            Assert.AreEqual(2, empTwo.TaxPlan.Deductions.Count);
            Assert.AreEqual(880.95m, empTwo.TaxPlan.Deductions["Income Tax"]);
            Assert.AreEqual(56.81m, empTwo.TaxPlan.Deductions["Pension Contribution"]);
        }
    }
}
