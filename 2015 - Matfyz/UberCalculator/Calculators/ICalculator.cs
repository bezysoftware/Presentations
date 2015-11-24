namespace Barclays.UberCalculator.Calculators
{
    public interface ICalculator
    {
        double Calculate(string formula);

        void Clear();
    }
}
