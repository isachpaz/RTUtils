using System;

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

    }
}