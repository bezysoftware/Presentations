namespace UberCalculator.Tests
{
    using Barclays.UberCalculator.Calculators;
    using Barclays.UberCalculator.Magics;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Returns42()
        {
            // setup
            var calculator = new Calculator(new Magic());

            // act
            var result = calculator.Calculate("10+11");

            // assert
            Assert.AreEqual(42.0, result);
        }
    }
}
