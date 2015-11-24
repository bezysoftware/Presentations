namespace UberCalculator.Tests
{
    using Barclays.UberCalculator;
    using Barclays.UberCalculator.Calculators;
    using Barclays.UberCalculator.IO;
    using Barclays.UberCalculator.Magics;

    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using UberCalculator.Tests.Mocks;

    [TestClass]
    public class GuiTests
    {
        [TestMethod]
        public void TestOutputForCorrectFormula()
        {
            var container = new UnityContainer();

            container
                .RegisterType<ICalculator, Calculator>(new ContainerControlledLifetimeManager())
                .RegisterType<IOutputWritter, WriterMock>(new ContainerControlledLifetimeManager())
                .RegisterType<IMagic, Magic>(new ContainerControlledLifetimeManager())
                .RegisterType<IInputReader, ReaderMock>(new ContainerControlledLifetimeManager());


            var reader = container.Resolve<IInputReader>() as ReaderMock;
            reader.Inputs.Add("22");
            reader.Inputs.Add("");

            container.Resolve<CalculatorGui>().Run();

            var writer = container.Resolve<IOutputWritter>() as WriterMock;
            
            Assert.AreEqual(42, writer.LastWritten);
            Assert.AreEqual(1, writer.WritesCount);
        }
    }
}
