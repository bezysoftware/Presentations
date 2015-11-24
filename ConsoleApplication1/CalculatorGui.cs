namespace Barclays.UberCalculator
{
    using Barclays.UberCalculator.Calculators;
    using Barclays.UberCalculator.IO;

    public class CalculatorGui
    {
        private readonly ICalculator calculator;
        private readonly IInputReader inputReader;
        private readonly IOutputWritter outputWritter;

        public CalculatorGui(ICalculator calculator, IInputReader inputReader, IOutputWritter outputWritter)
        {
            this.calculator = calculator;
            this.inputReader = inputReader;
            this.outputWritter = outputWritter;
        }

        public void Run()
        {
            var input = this.inputReader.ReadInput();

            while (!string.IsNullOrWhiteSpace(input))
            {
                var result = this.calculator.Calculate(input);
                this.outputWritter.WriteOuput(result);
                input = this.inputReader.ReadInput();
            }
        }
    }
}
