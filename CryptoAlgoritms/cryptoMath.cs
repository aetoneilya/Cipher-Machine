namespace lab_1_c_.CryptoAlgoritms
{
    class cryptoMath
    {
        static public int modCompare(int num, int pow, int mod)
        {
            pow = pow % (mod - 1);
            num %= mod;

            int result = 1;
            for (int i = 1; i <= pow; i++)
            {
                result *= num;
                result %= mod;
            }
            return result;
        }

        static public bool isPrime(int number)
        {
            if (number < 2)
                return false;
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;
            for (int i = 3; (i * i) <= number; i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        static public int gcd(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }

        static public int extEucAlg(int a, int b)
        {
            int mod = b;
            int q, r, nod, x, y;
            int x2 = 1, x1 = 0, y2 = 0, y1 = 1;

            while (b > 0)
            {
                q = a / b;
                r = a - q * b;
                x = x2 - q * x1;
                y = y2 - q * y1;
                a = b;
                b = r;
                x2 = x1;
                x1 = x;
                y2 = y1;
                y1 = y;
            }
            nod = a;
            x = x2;
            y = y2;

            if (x < 0)
            {
                x = x + mod;
            }
            return x;
        }
    }
}