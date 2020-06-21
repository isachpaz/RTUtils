using System;
using System.Collections.Generic;
using System.Linq;

namespace RTUtils.Misc
{
    public class ConvertDoubleToUInt32Array
    {
        public CompressedData Compress(double[] data, double precision)
        {
            var max = data.Max();
            var min = data.Min();
            var nValues = 1 + Math.Ceiling((max - min) / (2 * precision));
            var n = Math.Ceiling(Math.Log(nValues, 2));
            var offset = min;
            var scale = (max - min) / ((Math.Pow(2,n)) - 1);

            var compressedData = new UInt32[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                compressedData[i] = (UInt32) ((data[i] - offset) / scale);
            }

            var result = new CompressedData(
                data:compressedData,
                scale:scale,
                offset:offset);

            return result;
        }

        public IEnumerable<double> Uncompress(UInt32 [] data, double scale, double offset)
        {
            foreach (var item in data)
            {
                yield return item * scale + offset;
            }
        }

        public IEnumerable<double> Uncompress(CompressedData data)
        {
            return Uncompress(data: data.Data, scale: data.Scale, offset: data.Offset);
        }

    }
}