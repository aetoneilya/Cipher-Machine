using System;

namespace lab_1_c_.CryptoAlgoritms
{
    class ElGamal
    {
        private int p = 541, g = 10;
        private int privateKey, publicKey;
        private int message;
        private int[] encrMessage = new int[2];

        public void setPrivateKey()
        {
            privateKey = Convert.ToInt32(Console.ReadLine());
            while (privateKey <= 2 || privateKey > p - 1)
            {
                Console.Write("ERROR: secret code must be greater than 2 ");
                Console.WriteLine("but smaller than " + (p - 1));
                privateKey = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void setPublicKey()
        {
            publicKey = cryptoMath.modCompare(g, privateKey, p);
            Console.WriteLine("Open key is " + publicKey);
        }

        public int getPublicKey()
        {
            return publicKey;
        }

        public void setMessage()
        {
            message = Convert.ToInt32(Console.ReadLine());
        }

        public int[] sendEncMessage(int friendPublicKey)
        {
            encrMessage[0] = cryptoMath.modCompare(g, privateKey, p);
            encrMessage[1] = cryptoMath.modCompare(friendPublicKey, privateKey, p);
            encrMessage[1] = (encrMessage[1] * message) % p;
            return encrMessage;
        }

        public void getMessage(int[] message)
        {
            encrMessage[0] = message[0];
            encrMessage[1] = message[1];
        }

        public int decMessage()
        {
            return (encrMessage[1] * cryptoMath.modCompare(encrMessage[0], p - 1 - privateKey, p)) % p;
        }
    }
}