﻿using System;
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
        [Test]
        public void DecompressSequence_Empty_Input_Test()
        {
            var seq = MatrixUtil.DecompressSequence(null);
            Assert.True(seq.ToList().Count == 0);
        }

        public IEnumerable<UInt32> GetUInt32Array(int start, int length)
        {
            foreach (var item in Enumerable.Range(start, length))
            {
                yield return Convert.ToUInt32(item);
            }
        }

        [Test]
        public void DecompressSequence_Input_Test()
        {
            var dataIn = GetUInt32Array(1000, 10000);

            var compressedData = new CompressedResult(dataIn.ToArray(), 0.1234, 0.0 );
            var range = Enumerable.Range(0, compressedData.Data.Length);
            var seq = MatrixUtil.DecompressSequence(compressedData);
            foreach (var item in seq.Zip(range,(d, i) => Tuple.Create(i,d)))
            {
                var int_value = compressedData.Data[item.Item1];
                var double_value = int_value * compressedData.Scale + compressedData.Offset;
                Assert.AreEqual(double_value, item.Item2);
            }
        }
    }
}
