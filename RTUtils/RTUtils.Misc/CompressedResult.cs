using System;

namespace RTUtils.Misc
{
    public class CompressedResult
    {
        public uint [] Data { get; }
        public double Scale { get; }
        public double Offset { get; }

        public CompressedResult(UInt32[] data, double scale, double offset)
        {
            Data = data;
            Scale = scale;
            Offset = offset;
        }
    }
}