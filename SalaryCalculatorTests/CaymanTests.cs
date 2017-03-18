using SalaryCalculator;
using SalaryCalculator.TaxPlans;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalaryCalculatorTests
{
    /// <summary>
    /// Summary description for CaymanTests
    /// </summary>
    [TestClass]
    public class CaymanTests
    {
        [TestMethod]
        public void CaymanTaxPlanGetGrossSalaryTest()
        {
            CaymanTaxPlan itp = new CaymanTaxPlan();
            Employee empOne = new Employee(250, 100, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            Assert.AreEqual(25000, empOne.GetGrossSalary());
            Assert.AreEqual(2840.48m, empTwo.GetGrossSalary());
        }

        [TestMethod]
        public void CaymanTaxPlanGetNetSalaryTests()
        {
            CaymanTaxPlan itp = new CaymanTaxPlan();
            Employee empOne = new Employee(100, 250, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            Assert.AreEqual(25000, empOne.GetNetSalary());
            Assert.AreEqual(2840.48m, empTwo.GetNetSalary());
        }

        [TestMethod]
        public void CaymanTaxPlanGetTotalDeductions()
        {
            CaymanTaxPlan itp = new CaymanTaxPlan();
            Employee empOne = new Employee(250, 100, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            Assert.AreEqual(0, empOne.TaxPlan.GetTotalDeductions(empOne.GetGrossSalary()));
            Assert.AreEqual(0, empTwo.TaxPlan.GetTotalDeductions(empTwo.GetGrossSalary()));
        }

        [TestMethod]
        public void CaymanTaxPlanGetIndividualDeductions()
        {
            CaymanTaxPlan itp = new CaymanTaxPlan();
            Employee empOne = new Employee(250, 100, itp);
            Employee empTwo = new Employee(17.753m, 160, itp);

            // Force the calculations
            empOne.TaxPlan.GetTotalDeductions(empOne.GetGrossSalary());
            Assert.AreEqual(0, empOne.TaxPlan.Deductions.Count);

            //Force the calculations
            empTwo.TaxPlan.GetTotalDeductions(empTwo.GetGrossSalary());
            Assert.AreEqual(0, empTwo.TaxPlan.Deductions.Count);
        }
    }
}
