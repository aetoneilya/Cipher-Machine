using System;

namespace lab_1_c_.CryptoAlgoritms
{
    class RSA
    {
        private int p, q;
        private int mod, len;
        private int encKey, decKey;
        private int message;
        private int[] publicKey = new int[2];

        public void setpq()
        {
            p = Convert.ToInt32(Console.ReadLine());
            while (!cryptoMath.isPrime(p))
            {
                Console.WriteLine("Error: p must be prime");
                p = Convert.ToInt32(Console.ReadLine());
            }

            q = Convert.ToInt32(Console.ReadLine());
            while (!cryptoMath.isPrime(q))
            {
                Console.WriteLine("Error: q must be prime");
                q = Convert.ToInt32(Console.ReadLine());
            }

            mod = p * q;
            len = (p - 1) * (q - 1);
        }

        public void setEncKey()
        {
            encKey = Convert.ToInt32(Console.ReadLine());
            while (cryptoMath.gcd(encKey, len) != 1 ||
                   cryptoMath.gcd(encKey, mod) != 1 ||
                   encKey < 1 || encKey > len)
            {
                Console.WriteLine("Error: incorrect key");
                encKey = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void setDecKey()
        {
            decKey = cryptoMath.extEucAlg(encKey, len);
            Console.WriteLine("decKey " + decKey);
        }

        public void setMes()
        {
            message = Convert.ToInt32(Console.ReadLine());
        }

        public int sendMes()
        {
            int encMes = cryptoMath.modCompare(message, publicKey[0], publicKey[1]);
            Console.WriteLine("sending message " + encMes);

            return encMes;
        }

        public int decode(int message)
        {
            return cryptoMath.modCompare(message, decKey, mod);
        }

        public int[] getPublicKey()
        {
            publicKey[0] = encKey;
            publicKey[1] = mod;
            return publicKey;
        }

        public void recievePublicKey(int[] r_publicKey)
        {
            publicKey[0] = r_publicKey[0];
            publicKey[1] = r_publicKey[1];
        }
    }
}