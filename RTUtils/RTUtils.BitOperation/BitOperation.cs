using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTUtils.BitOperation
{
    public static class BitOperation
    {
        public static byte SetBit(this byte self, int index, bool isOn)
        {
            if (index > 7 || index < 0)
            {
                throw new ArgumentOutOfRangeException("index must be from [0,7] => 8 bit positions.");
            }

            if (isOn == true)
            {
                byte mask = (byte)(1 << index);
                return self |= mask;
            }

            return self;
        }

        public static byte ToggleBit(this byte self, int index)
        {
            byte mask = (byte)(1 << index);
            self ^= mask;
            return self;
        }

        public static bool GetBit(this byte self, int index)
        {
            byte mask = (byte)(1 << index);

            return (self & mask) != 0;
        }
    }
}
