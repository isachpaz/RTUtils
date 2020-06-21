using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTUtils.Misc
{
    public static class MatrixUtil
    {
        public static CompressedResult Compress(double[] data, double presicion)
        {
            var result = new CompressedResult(null, Double.NaN, Double.NaN);
            return result;
        }

        public static double[] Decompress(CompressedResult compressedData)
        {
            return new double[1];
        }

        public static IEnumerable<double> DecompressSequence(CompressedResult compressed)
        {
            if (compressed == null)
            {
                  yield break;
            }

            foreach (var item in compressed.Data)
            {
                yield return item * compressed.Scale + compressed.Offset;
            }
        }
    }
}