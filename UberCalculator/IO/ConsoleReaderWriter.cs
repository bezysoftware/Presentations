namespace Barclays.UberCalculator.IO
{
    using System;

    public class ConsoleReaderWriter : IInputReader, IOutputWritter
    {
        public string ReadInput()
        {
            Console.Write("Enter formula: ");
            return Console.ReadLine();
        }

        public void WriteOuput(double result)
        {
            Console.WriteLine("Result is: {0}", result);
        }
    }
}