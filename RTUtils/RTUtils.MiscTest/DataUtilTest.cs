using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RTUtils.Misc;


namespace RTUtils.MiscTests
{
    [TestFixture]
    public class MatrixUtilTest
    {
        
        public IEnumerable<UInt32> GetUInt32Array(int start, int length)
        {
            foreach (var item in Enumerable.Range(start, length))
            {
                yield return Convert.ToUInt32(item);
            }
        }

        [Test]
        public void Uncompress_Test()
        {
            var dataIn = GetUInt32Array(1000, 10000);

            var compressedData = new CompressedData(dataIn.ToArray(), 0.00000023, 0.0 );
            var converter = new ConvertDoubleToUInt32Array();
            var array = converter.Uncompress(compressedData).ToList();

            for (var i=0; i < array.Count; ++i)
            {
                var int_value = compressedData.Data[i];
                var double_value = int_value * compressedData.Scale + compressedData.Offset;
                Assert.AreEqual(double_value, array[i]);
            }
        }
    }
}
