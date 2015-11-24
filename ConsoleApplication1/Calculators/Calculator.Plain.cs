namespace Barclays.UberCalculator.Calculators
{
    using System;

    using Barclays.UberCalculator.Magics;

    public class Calculator : ICalculator
    {
        private readonly IMagic magic;

        public Calculator(IMagic magic)
        {
            this.magic = magic;
        }

        public double Calculate(string formula)
        {
            var magicNumber = this.magic.GetMagicNumber();
            
            return magicNumber;
        }

        public void Clear()
        {
            throw new InvalidOperationException();
        }
    }
}
