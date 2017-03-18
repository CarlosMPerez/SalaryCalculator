using SalaryCalculator;
using SalaryCalculator.TaxPlans;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalaryCalculatorTests
{
    /// <summary>
    /// Summary description for IrelandTests
    /// </summary>
    [TestClass]
    public class CaymanIslandsTests
    {
        [TestMethod]
        public void CaymanIslandsTaxPlanGetGrossSalaryTest()
        {
            Assert.AreEqual(25000, Calculator.GetGrossSalary(250, 100));
            Assert.AreEqual(2840.48m, Calculator.GetGrossSalary(17.753m, 160));
        }

        [TestMethod]
        public void CaymanIslandsTaxPlanGetNetSalaryTests()
        {
            CaymanIslandsTaxPlan citp = new CaymanIslandsTaxPlan();
            Assert.AreEqual(25000, Calculator.GetNetSalary(100, 250, citp));
            Assert.AreEqual(2840.48m, Calculator.GetNetSalary(17.753m, 160, citp));
        }
    }
}
