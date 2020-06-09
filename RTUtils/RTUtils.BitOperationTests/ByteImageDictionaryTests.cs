using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RTUtils.BitOperation;

namespace RTUtils.BitOperationTests
{
    public class ByteImageDictionaryTests
    {
        private ByteImageDictionary _biDict;

        [SetUp]
        public void InitDictionary()
        {
            _biDict = ByteImageDictionary.Create(
                new Map("Prostate GTV", 0),
                new Map("Urethra", 1)
            );
        }

        [Test]
        public void ByteImageDictionary_ctor_Test()
        {
            var biDict = ByteImageDictionary.Create(
                new Map("Prostate GTV", 0),
                new Map("Urethra", 1)
            );

            Assert.AreNotEqual(null, biDict);
        }

        [Test]
        public void ByteImageDictionary_Mapping_Test()
        {
            string name = "Prostate GTV";
            var index = _biDict.GetIndex(name);
            Assert.AreEqual(0, index.IfNone(null));

            name = "Urethra";
            index = _biDict.GetIndex(name);
            Assert.AreEqual(1, index.IfNone(null));
        }

        [Test]
        public void GetIndex_Wrong_Name_Test()
        {
            string name = "Does not exit";
            var index = _biDict.GetIndex(name);
            Assert.AreEqual(true, index.IsNone);
        }
    }
}