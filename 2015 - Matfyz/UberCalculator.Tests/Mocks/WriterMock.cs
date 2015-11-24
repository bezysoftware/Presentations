namespace UberCalculator.Tests.Mocks
{
    using Barclays.UberCalculator;
    using Barclays.UberCalculator.IO;

    public class WriterMock : IOutputWritter
    {
        public WriterMock()
        {
            this.LastWritten = null;
            this.WritesCount = 0;
        }

        public void WriteOuput(double result)
        {
            this.LastWritten = result;
            this.WritesCount++;
        }

        public double? LastWritten { get; set; }

        public int WritesCount { get; set; }
    }
}
