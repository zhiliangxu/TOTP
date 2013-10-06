using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TOTP.UnitTes
{
    [TestClass]
    public class TotpTest
    {
        [TestMethod]
        public void TestHotp()
        {
            string secret = "HJJZZ4QRPSJIAPAN";
            string totp = TOTP.Lib.TOTP.GetHotp(secret, 8773256821647312117);
            Assert.AreEqual("879617", totp);
        }

        [TestMethod]
        public void TestHotp_ZeroPadding()
        {
            string secret = "HJJZZ4QRPSJIAPAN";
            string totp = TOTP.Lib.TOTP.GetHotp(secret, 8773256821647312147);
            Assert.AreEqual("071501", totp);
        }
    }
}