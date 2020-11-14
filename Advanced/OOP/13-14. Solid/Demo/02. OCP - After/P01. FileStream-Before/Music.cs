namespace P01._FileStream_Before
{
    public class Music : IStreamable
    {
       

        public string Artist { get; set; }

        public string Album { get; set; }
        public int Length { get; set; }
        public int Sent { get; set; }
    }
}
