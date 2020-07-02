using System;
using System.Runtime.Remoting.Messaging;

namespace RTUtils.Misc
{
    public class DicomUniqueID
    {
        public static string RootUID { get; set; }

        public static string Generate()
        {
            if (string.IsNullOrEmpty(RootUID))
            {
                RootUID = "1.2.826.0.1.3680043.2.1343.1";
            }

            var uid = $"{RootUID}.{DateTime.UtcNow}.{DateTime.UtcNow.Millisecond*97}"
                .Replace("/",".")
                .Replace(":",".")
                .Replace(" ",".");

            return uid;
        }

        public static string GenerateDerivedFromGUID()
        {
            var guid = Guid.NewGuid().ToByteArray();
            var bigint = new System.Numerics.BigInteger(guid);
            if (bigint < 0) bigint = -bigint;
            var uid = "2.25." + bigint;

            return uid;
        }


    }
}