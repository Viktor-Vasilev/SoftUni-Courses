namespace P01._FileStream_Before
{
    public class Progress
    {
        IStreamable stream;

        public Progress(IStreamable stream)
        {
            this.stream = stream;
        }

        public int CurrentPercent()
        {
            return this.stream.Sent * 100 / this.stream.Length;
        }
    }
}
