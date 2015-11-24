namespace Barclays.UberCalculator.Logging
{
    using System;

    public class ConsoleLog : ILog
    {
        public void Debug(string message, params object[] parameter)
        {
            Console.WriteLine("DEBUG - " + message, parameter);
        }

        public void Error(string message, params object[] parameter)
        {
            Console.WriteLine("ERROR - " + message, parameter);
        }
    }
}
