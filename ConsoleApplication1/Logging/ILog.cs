namespace Barclays.UberCalculator.Logging
{
    public interface ILog
    {
        void Debug(string message, params object[] parameter);

        void Error(string message, params object[] parameter);
    }
}
