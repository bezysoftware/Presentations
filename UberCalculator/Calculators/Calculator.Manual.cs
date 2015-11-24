namespace Barclays.UberCalculator.Calculators
{
    using System;

    using Barclays.UberCalculator.Logging;
    using Barclays.UberCalculator.Magics;

    public class LoggingCalculator : ICalculator
    {
        private readonly ILog log;

        private readonly IMagic magic;

        public LoggingCalculator(ILog log, IMagic magic)
        {
            this.log = log;
            this.magic = magic;
        }

        public double Calculate(string formula)
        {
            this.log.Debug("Calculator.Calculate called with parameters: {0}", formula);

            try
            {
                var result = this.CalculateInternal(formula);

                this.log.Debug("Calculator.Calculate finished with parameters: {0}, result: {1}", formula, result);

                return result;
            }
            catch (Exception ex)
            {
                this.log.Error("Calculator.Calculate threw with parameters: {0}, exception: {1}", formula, ex);
                throw;
            }
        }

        public void Clear()
        {
            this.log.Debug("Calculator.Clear called");

            try
            {
                this.ClearInternal();

                this.log.Debug("Calculator.Clear finished");
            }
            catch (Exception ex)
            {
                this.log.Error("Calculator.Clear threw exception: {0}", ex);
                throw;
            }
        }

        private double CalculateInternal(string formula)
        {
            var magicNumber = this.magic.GetMagicNumber();
            return 42 * magicNumber;
        }

        private void ClearInternal()
        {
            throw new InvalidOperationException();
        }
    }
}
