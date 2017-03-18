using SalaryCalculator;
using SalaryCalculator.TaxPlans;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalaryCalculatorTests
{
    /// <summary>
    /// Summary description for ItalyTests
    /// </summary>
    [TestClass]
    public class ItalyTests
    {
        [TestMethod]
        public void ItalyTaxPlanGetGrossSalaryTest()
        {
            ItalyTaxPlan itp = new ItalyTaxPlan();
            Employee empOne = new Employee(250, 100, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            Assert.AreEqual(25000, empOne.GetGrossSalary());
            Assert.AreEqual(2840.48m, empTwo.GetGrossSalary());
        }

        [TestMethod]
        public void ItalyTaxPlanGetNetSalaryTests()
        {
            ItalyTaxPlan itp = new ItalyTaxPlan();
            Employee empOne = new Employee(100, 250, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            Assert.AreEqual(16452.50m, empOne.GetNetSalary());
            Assert.AreEqual(1869.320m, empTwo.GetNetSalary());
        }

        [TestMethod]
        public void ItalyTaxPlanGetTotalDeductions()
        {
            ItalyTaxPlan itp = new ItalyTaxPlan();
            Employee empOne = new Employee(250, 100, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            Assert.AreEqual(8547.50m, empOne.TaxPlan.GetTotalDeductions(empOne.GetGrossSalary()));
            Assert.AreEqual(971.16m, empTwo.TaxPlan.GetTotalDeductions(empTwo.GetGrossSalary()));
        }

        [TestMethod]
        public void ItalyTaxPlanGetIndividualDeductions()
        {
            ItalyTaxPlan itp = new ItalyTaxPlan();
            Employee empOne = new Employee(250, 100, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            // Force the calculations
            empOne.TaxPlan.GetTotalDeductions(empOne.GetGrossSalary());
            Assert.AreEqual(2, empOne.TaxPlan.Deductions.Count);
            Assert.AreEqual(6250, empOne.TaxPlan.Deductions["Income Tax"]);
            Assert.AreEqual(2297.50m, empOne.TaxPlan.Deductions["INPS Contribution"]);

            //Force the calculations
            empTwo.TaxPlan.GetTotalDeductions(empTwo.GetGrossSalary());
            Assert.AreEqual(2, empTwo.TaxPlan.Deductions.Count);
            Assert.AreEqual(710.12m, empTwo.TaxPlan.Deductions["Income Tax"]);
            Assert.AreEqual(261.04m, empTwo.TaxPlan.Deductions["INPS Contribution"]);
        }
    }
}
