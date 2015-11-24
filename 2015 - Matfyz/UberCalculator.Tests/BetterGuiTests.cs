namespace UberCalculator.Tests
{
    using Barclays.UberCalculator;
    using Barclays.UberCalculator.Calculators;
    using Barclays.UberCalculator.IO;
    using Barclays.UberCalculator.Magics;

    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using UberCalculator.Tests.Mocks;

    [TestClass]
    public class BetterGuiTests
    {
        [TestMethod]
        public void TestOutputForCorrectFormula()
        {
            var container = new UnityContainer();

            var readerMock = new Mock<IInputReader>();
            readerMock
                .SetupSequence(o => o.ReadInput())
                .Returns("22")
                .Returns(string.Empty);

            var writerMock = new Mock<IOutputWritter>();
            
            container
                .RegisterType<ICalculator, Calculator>(new ContainerControlledLifetimeManager())
                .RegisterType<IMagic, Magic>(new ContainerControlledLifetimeManager())
                .RegisterInstance<IOutputWritter>(writerMock.Object)                
                .RegisterInstance<IInputReader>(readerMock.Object);

            container.Resolve<CalculatorGui>().Run();

            writerMock.Verify(o => o.WriteOuput(It.IsAny<double>()), Times.Exactly(1));
        }
    }
}
