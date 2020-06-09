using NUnit.Framework;
using RTUtils.BitOperation;

namespace RTUtils.BitOperationTests
{
    public class ByteImageTests
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
        public void ByteImage_ctor_Test()
        {
            var bImage = ByteImage.Create(10, 20, 3, _biDict);
            bImage.SetBitForStructureON("Urethra", 5, 5,2);
            bImage.SetBitForStructureON("Prostate GTV", 7, 7, 2);

            var binaryImgUrethra = bImage.GetBinaryImage("Urethra");
            var binaryImgProstate = bImage.GetBinaryImage("Prostate GTV");

            var profileZ2 = binaryImgUrethra.GetProfile(2);

        }
    }
}