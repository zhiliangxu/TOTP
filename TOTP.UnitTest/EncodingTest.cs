using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTP.Lib;
using System.Linq;

namespace TOTP.UnitTest
{
    [TestClass]
    public class EncodingTest
    {
        [TestMethod]
        public void TestBase32Decoding()
        {
            string encodedText = "HJJZZ4QRPSJIAPAN";
            byte[] expected = encodedText.ToByteArray();
            byte[] actual = { 58, 83, 156, 242, 17, 124, 146, 128, 60, 13 };
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}