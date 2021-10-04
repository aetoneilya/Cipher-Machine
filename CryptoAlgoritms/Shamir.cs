using System;

namespace lab_1_c_.CryptoAlgoritms
{
    class Shamir
    {
        private int p;
        private int privateKeyFirst, privateKeySecond;
        private int message;

        public void setp()
        {
            p = Convert.ToInt32(Console.ReadLine());
            while (!cryptoMath.isPrime(p))
            {
                Console.WriteLine("Error: p must be prime");
                p = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void setPrivateKey()
        {
            privateKeyFirst = Convert.ToInt32(Console.ReadLine());
            while (cryptoMath.gcd(privateKeyFirst, p - 1) != 1)
            {
                Console.WriteLine("Error: private key must be mutual prime with p - 1");
                privateKeyFirst = Convert.ToInt32(Console.ReadLine());
            }
            privateKeySecond = cryptoMath.extEucAlg(privateKeyFirst, p - 1);
            Console.WriteLine("Private key second " + privateKeySecond);
        }

        public void setMessage()
        {
            message = Convert.ToInt32(Console.ReadLine());
            while (message > p)
            {
                Console.WriteLine("ERROR: message must be less then p");
                message = Convert.ToInt32(Console.ReadLine());
            }
        }

        public int cipherFirst(int recived)
        {
            int res = cryptoMath.modCompare(recived, privateKeyFirst, p);
            return res;
        }

        public int cipherSecond(int recived)
        {
            int res = cryptoMath.modCompare(recived, privateKeySecond, p);
            return res;
        }

        public int getMessage()
        {
            return message;
        }
    }
}