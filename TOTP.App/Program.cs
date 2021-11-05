using System;
using System.Threading;

namespace TOTP.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string secret = "HOOZZ4QRPSWBNPAN";
            while (true)
            {
                Console.WriteLine("{0} {1}", DateTime.Now, Lib.TOTP.GetTotp(secret));
                Thread.Sleep(1000 * 3);
            }
        }
    }
}
