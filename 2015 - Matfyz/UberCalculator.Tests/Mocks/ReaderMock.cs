namespace UberCalculator.Tests.Mocks
{
    using System.Collections.Generic;

    using Barclays.UberCalculator;
    using Barclays.UberCalculator.IO;

    public class ReaderMock : IInputReader
    {
        private int counter;

        public ReaderMock()
        {
            this.Inputs = new List<string>();
        }

        public string ReadInput()
        {
            return this.Inputs[this.counter++];
        }

        public List<string> Inputs { get; set; }
    }
}
