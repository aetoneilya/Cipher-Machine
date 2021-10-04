using System;

namespace lab_1_c_.CryptoAlgoritms
{
    class DiffieHellman
    {
        private int closeKey, openKey;
        private int g = 10;
        private int p = 541;
        private int resKey;

        public void setCloseKey()
        {
            closeKey = Convert.ToInt32(Console.ReadLine());
            while (closeKey <= 2 || closeKey > p - 1)
            {
                Console.Write("ERROR: secret code must be greater than 2 ");
                Console.WriteLine("but smaller than " + (p - 1));
                closeKey = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void setOpenKey()
        {
            openKey = cryptoMath.modCompare(g, closeKey, p);
            Console.WriteLine("Open key is " + openKey);
        }

        public int getOpenKey()
        {
            return openKey;
        }

        public void setResKey(int friendOpenKey)
        {
            resKey = cryptoMath.modCompare(friendOpenKey, closeKey, p);
            Console.WriteLine("Result key " + resKey);
        }

        public int getResKey()
        {
            return resKey;
        }
    }
}