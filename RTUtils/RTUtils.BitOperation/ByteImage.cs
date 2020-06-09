using System;
using LanguageExt.ClassInstances;

namespace RTUtils.BitOperation
{
    public class ByteImage
    {
        public int XSize { get; private set; }
        public int YSize { get; private set; }
        public int ZSize { get; private set; }

        public ByteImageDictionary Dictionary { get; private set; }

        private Byte[] ByteArray { get; set; }

        private ByteImage(int xSize, int ySize, int zSize, ByteImageDictionary dict, Byte[] byteArray)
        {
            XSize = xSize;
            YSize = ySize;
            ZSize = zSize;
            Dictionary = dict;
            ByteArray = byteArray;
        }

        protected int GetIndex(int xPos, int yPos, int zPos)
        {
            return zPos * XSize * YSize + yPos * XSize + xPos;
        }

        public void SetBitForStructureON(string structureName, int xPos, int yPos, int zPos)
        {
            var bitPosition = Dictionary.GetIndex(structureName);
            bitPosition.Match(
                Some: (bpos) =>
                {
                    var byteArrayPosition = GetIndex(xPos, yPos, zPos);
                    ByteArray[byteArrayPosition] = ByteArray[byteArrayPosition].SetBit(bpos, true);
                },
                None: () => throw new ArgumentException("structureName cannot be found in the dictionary.")
            );
        }

        public static ByteImage Create(int xSize, int ySize, int zSize, ByteImageDictionary dict)
        {
            //Check here for memory allocation error.
            Byte[] byteArray = new Byte[xSize * ySize * zSize];
            for (int i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = 0;
            }

            return new ByteImage(xSize, ySize, zSize, dict, byteArray);
        }

        public BinaryImage GetBinaryImage(string structure)
        {
            var bImage = BinaryImage.Create(XSize, YSize, ZSize, structure);
            Dictionary.GetIndex(structure).Match(
                Some: (indexName) =>
                {
                    for (int i = 0; i < ByteArray.Length; i++)
                    {
                       var isOn = ByteArray[i].GetBit(indexName);
                       if (isOn)
                       {
                           bImage.SetBit(i);
                       }
                    }
                },
                None: ()=> throw new IndexOutOfRangeException("Structure cannot be found in the dictionary.")
            );
            return bImage;
        }
    }
}