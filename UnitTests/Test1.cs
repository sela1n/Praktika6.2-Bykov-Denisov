using Microsoft.VisualStudio.TestTools.UnitTesting;
using Praktika4_Bykov_Denisov;

namespace UnitTests
{
    [TestClass]
    public class MathFunctionsTests
    {
        [TestMethod]
        public void CalcC_Test()
        {
            double result = MathFunctions.CalcC(1, 2, 1);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CalcB_Test()
        {
            double result = MathFunctions.CalcB(2, 1);

            Assert.IsTrue(result != 0);
        }

        [TestMethod]
        public void CalcB_Yzero_Test()
        {
            double result = MathFunctions.CalcB(2, 0);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalcY_Test()
        {
            double result = MathFunctions.CalcY(1, 3.2);

            Assert.IsTrue(result != 0);
        }
    }
}