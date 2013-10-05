using System;
using System.Linq;
using System.Security.Cryptography;

namespace TOTP.Lib
{
    public static class TOTP
    {
        public static string GetHotp(string base32EncodedSecret, long counter)
        {
            byte[] message = BitConverter.GetBytes(counter)
                .Reverse().ToArray(); // Assuming Intel machine (little endian)
            byte[] secret = base32EncodedSecret.ToByteArray();

            byte[] hash;
            using (HMACSHA1 hmac = new HMACSHA1(secret, true))
            {
                hash = hmac.ComputeHash(message);
            }
            int offset = hash[hash.Length - 1] & 0xf;
            int truncatedHash = ((hash[offset] & 0x7f) << 24) |
                ((hash[offset + 1] & 0xff) << 16) |
                ((hash[offset + 2] & 0xff) << 8) |
                (hash[offset + 3] & 0xff);
            int hotp = truncatedHash % 1000000; // 6-digit code and hence 10 power 6, that is a million
            return hotp.ToString("D6");
        }

        public static string GetTotp(string base32EncodedSecret)
        {
            DateTime epochStart = new DateTime(1970, 1, 1);
            long counter = (long)Math.Floor((DateTime.UtcNow - epochStart).TotalSeconds / 30);
            return GetHotp(base32EncodedSecret, counter);
        }
    }
}
