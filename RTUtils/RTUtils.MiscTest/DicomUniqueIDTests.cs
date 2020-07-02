using System;
using System.Diagnostics;
using NUnit.Framework;
using RTUtils.Misc;

namespace RTUtils.MiscTests
{
    [TestFixture]
    public class DicomUniqueIDTests
    {
        [Test]
        public void Generate_DICOMUID_Test()
        {
            for (int i = 0; i < 100; i++)
            {
                var uid = DicomUniqueID.Generate();
                Debug.WriteLine(uid);

                //TODO: Check for spaces, and special chars and non numeric
            }
            
        }

        [Test]
        public void Generate_GenerateDerivedFromUUID_Test()
        {
            for (int i = 0; i < 100; i++)
            {
                var uid = DicomUniqueID.GenerateDerivedFromGUID();
                Debug.WriteLine(uid);

                //TODO: Check for spaces, and special chars and non numeric
            }
            
        }
    }
}