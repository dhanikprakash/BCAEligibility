using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;

namespace BCAEligibility.Tests
{
    [TestClass()]
    public class BCAEligibilityTests
    {
        private string test01Data;
        private string test02Data;
        private string test03Data;
        private string test04Data;
        private string test05Data;
        private string test06Data;
        private string test07Data;
        private string test08Data;
        private BCAEligibility bcaEligibility;

        [TestInitialize()]
        public void Initialize()
        {
            test01Data = File.ReadAllText(@"TestData/Test01.json", Encoding.UTF8);
            test02Data = File.ReadAllText(@"TestData/Test02.json", Encoding.UTF8);
            test03Data = File.ReadAllText(@"TestData/Test03.json", Encoding.UTF8);
            test04Data = File.ReadAllText(@"TestData/Test04.json", Encoding.UTF8);
            test05Data = File.ReadAllText(@"TestData/Test05.json", Encoding.UTF8);
            test06Data = File.ReadAllText(@"TestData/Test06.json", Encoding.UTF8);
            test07Data = File.ReadAllText(@"TestData/Test07.json", Encoding.UTF8);
            test08Data = File.ReadAllText(@"TestData/Test08.json", Encoding.UTF8);
            bcaEligibility = new BCAEligibility();
        }


        [TestMethod()]
        public void BCACheckEligibilityTest01_Should_Return_Eligible()
        {
            var expectedResult = "Eligible";
            Assert.AreEqual(expectedResult, bcaEligibility.BCACheckEligibility(test01Data));
        }
        [TestMethod()]
        public void BCACheckEligibilityTest02_Should_Return_Eligible()
        {
            var expectedResult = "Eligible";
            Assert.AreEqual(expectedResult, bcaEligibility.BCACheckEligibility(test02Data));
        }
        [TestMethod()]
        public void BCACheckEligibilityTest03_HighValue_Should_Return_Ineligible()
        {
            var expectedResult = "Ineligible";
            Assert.AreEqual(expectedResult, bcaEligibility.BCACheckEligibility(test03Data));
        }
        [TestMethod()]
        public void BCACheckEligibilityTest04_LowAvgTransaction_Should_Return_Ineligible()
        {
            var expectedResult = "Ineligible";
            Assert.AreEqual(expectedResult, bcaEligibility.BCACheckEligibility(test04Data));
        }
        [TestMethod()]
        public void BCACheckEligibilityTest05_LowAmountReq_Should_Return_Ineligible()
        {
            var expectedResult = "Ineligible";
            Assert.AreEqual(expectedResult, bcaEligibility.BCACheckEligibility(test05Data));
        }
        [TestMethod()]
        public void BCACheckEligibilityTest06_NewBusinessOperation_Should_Return_Ineligible()
        {
            var expectedResult = "Ineligible";
            Assert.AreEqual(expectedResult, bcaEligibility.BCACheckEligibility(test06Data));
        }
        [TestMethod()]
        public void BCACheckEligibilityTest07_HighValue_Should_Return_Eligible()
        {
            var expectedResult = "Eligible";
            Assert.AreEqual(expectedResult, bcaEligibility.BCACheckEligibility(test07Data));
        }
        [TestMethod()]
        public void BCACheckEligibilityTest08_HighValue_Missing_1_Month_Ineligibl()
        {
            var expectedResult = "Ineligible";
            Assert.AreEqual(expectedResult, bcaEligibility.BCACheckEligibility(test08Data));
        }
    }
}