using System;

namespace RTUtils.Misc
{
    public class CompressedData
    {
        public uint [] Data { get; }
        public double Scale { get; }
        public double Offset { get; }

        public CompressedData(UInt32[] data, double scale, double offset)
        {
            Data = data;
            Scale = scale;
            Offset = offset;
        }
    }
}