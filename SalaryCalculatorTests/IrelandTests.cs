using SalaryCalculator;
using SalaryCalculator.TaxPlans;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalaryCalculatorTests
{
    /// <summary>
    /// Summary description for IrelandTests
    /// </summary>
    [TestClass]
    public class IrelandTests
    {
        [TestMethod]
        public void IrelandTaxPlanGetGrossSalaryTest()
        {
            IrelandTaxPlan itp = new IrelandTaxPlan();
            Employee empOne = new Employee(250, 100, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            Assert.AreEqual(25000, empOne.GetGrossSalary());
            Assert.AreEqual(2840.48m, empTwo.GetGrossSalary());
        }

        [TestMethod]
        public void IrelandTaxPlanGetNetSalaryTests()
        {
            IrelandTaxPlan itp = new IrelandTaxPlan();
            Employee empOne = new Employee(100, 250, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            Assert.AreEqual(12095, empOne.GetNetSalary());
            Assert.AreEqual(1458.43m, empTwo.GetNetSalary());
        }

        [TestMethod]
        public void IrelandTaxPlanGetTotalDeductions()
        {
            IrelandTaxPlan itp = new IrelandTaxPlan();
            Employee empOne = new Employee(250, 100, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            Assert.AreEqual(12905, empOne.TaxPlan.GetTotalDeductions(empOne.GetGrossSalary()));
            Assert.AreEqual(1382.05m, empTwo.TaxPlan.GetTotalDeductions(empTwo.GetGrossSalary()));
        }

        [TestMethod]
        public void IrelandTaxPlanGetIndividualDeductions()
        {
            IrelandTaxPlan itp = new IrelandTaxPlan();
            Employee empOne = new Employee(250, 100, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            // Force the calculations
            empOne.TaxPlan.GetTotalDeductions(empOne.GetGrossSalary());
            Assert.AreEqual(3, empOne.TaxPlan.Deductions.Count);
            Assert.AreEqual(9910, empOne.TaxPlan.Deductions["Income Tax"]);
            Assert.AreEqual(1995, empOne.TaxPlan.Deductions["Universal Social Charge"]);
            Assert.AreEqual(1000, empOne.TaxPlan.Deductions["Pension Contribution"]);

            //Force the calculations
            empTwo.TaxPlan.GetTotalDeductions(empTwo.GetGrossSalary());
            Assert.AreEqual(3, empTwo.TaxPlan.Deductions.Count);
            Assert.AreEqual(1046.19m, empTwo.TaxPlan.Deductions["Income Tax"]);
            Assert.AreEqual(222.24m, empTwo.TaxPlan.Deductions["Universal Social Charge"]);
            Assert.AreEqual(113.62m, empTwo.TaxPlan.Deductions["Pension Contribution"]);
        }
    }
}
