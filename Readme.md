# HMAC[1] Time-based One-Time Password in C#

## How to Use
Reference `TOTP.Lib` project, or the DLL it generates.

## Sample code
```csharp
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
                Console.WriteLine("{0} {1}", DateTime.Now, TOTP.Lib.TOTP.GetTotp(secret));
                Thread.Sleep(1000 * 3);
            }
        }
    }
}
```

[1]: https://en.wikipedia.org/wiki/Time-based_One-time_Password_Algorithm
