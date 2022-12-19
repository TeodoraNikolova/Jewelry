namespace Jewelry
{
    internal class PdfTable
    {
        private int count;

        public PdfTable(int count)
        {
            this.count = count;
        }

        public object DefaultCell { get; internal set; }
    }
}