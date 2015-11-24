namespace Barclays.UberCalculator.Magics
{
    using System;

    public class MagicNotOk : IMagic
    {
        public double GetMagicNumber()
        {
            throw new TimeoutException();
        }
    }
}
