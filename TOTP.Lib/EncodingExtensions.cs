namespace TOTP.Lib
{
    public static class EncodingExtensions
    {
        private static readonly byte[] mapping = { 26, 27, 28, 29, 30, 255, 255, 255, 255, 255,
                                        255, 255, 255, 255, 255, 0, 1, 2, 3, 4,
                                        5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
                                        15, 16, 17, 18, 19, 20, 21, 22, 23, 24,
                                        25 };

        public static byte[] ToByteArray(this string secret)
        {
            secret = secret.ToUpperInvariant();
            byte[] byteArray = new byte[(secret.Length + 7) / 8 * 5];

            long shiftingNum = 0L;
            int srcCounter = 0;
            int destCounter = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                long num = (long)mapping[secret[i] - 50];
                shiftingNum |= num << (35 - srcCounter * 5);

                if (srcCounter == 7 || i == secret.Length - 1)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        byteArray[destCounter++] = (byte)((shiftingNum >> (32 - j * 8)) & 0xff);
                    }
                    shiftingNum = 0L;
                }
                srcCounter = (srcCounter + 1) % 8;
            }

            return byteArray;
        }
    }
}
