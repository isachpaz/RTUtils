using System;

namespace RTUtils.BitOperation
{
    public class BinaryImage
    {
        public int XSize { get; private set; }
        public int YSize { get; private set; }
        public int ZSize { get; private set; }

        public string Description { get; private set; }

        private Byte[] ByteArray { get; }

        public BinaryImage(int xSize, int ySize, int zSize, string description, byte[] byteArray)
        {
            XSize = xSize;
            YSize = ySize;
            ZSize = zSize;
            Description = description;
            ByteArray = byteArray;
        }

        public static BinaryImage Create(int xSize, int ySize, int zSize, string description)
        {
            Byte[] byteArray = new Byte[xSize * ySize * zSize];
            for (int i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = 0;
            }

            return new BinaryImage(xSize, ySize, zSize, description, byteArray);
        }

        protected int GetIndex(int xPos, int yPos, int zPos)
        {
            return zPos * XSize * YSize + yPos * XSize + xPos;
        }

        public void SetBit(int xPos, int yPos, int zPos)
        {
            int pos = GetIndex(xPos, yPos, zPos);
            ByteArray[pos] = ByteArray[pos].SetBit(0, true);
        }

        public void SetBit(int pos1DArray)
        {
            ByteArray[pos1DArray] = ByteArray[pos1DArray].SetBit(0, true);
        }

        public byte[,] GetProfile(int zPos)
        {
            byte[,] zProfile = new byte[XSize,YSize];
            for (int i = 0; i < XSize; i++)
            {
                for (int j = 0; j < YSize; j++)
                {
                    zProfile[i, j] = this.ByteArray[GetIndex(i, j, zPos)];
                }
            }

            return zProfile;
        }
    }
}
