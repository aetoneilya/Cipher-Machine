using System;
using lab_1_c_.CryptoAlgoritms;

namespace lab_1_c_
{
    class Program
    {
        static void Main(string[] args)
        {
            interface_.run();
            Console.ReadKey();
        }
    }
    enum commands
    {
        DFHLM,
        RSA,
        SHMR,
        ELGML,
        ENCODE,
        DECODE,
        CLEAR,
        NONE,
        EXIT
    };

    static public class interface_
    {
        static public void run()
        {
            while (true)
            {
                commands cmd;
                cmd = stocmd(Console.ReadLine());
                if (cmd == commands.EXIT)
                {
                    return;
                }
                doCommand(cmd);
            }
        }

        static private commands stocmd(string input)
        {
            commands res;
            switch (input)
            {
                case "DFHLM":
                    res = commands.DFHLM;
                    break;
                case "RSA":
                    res = commands.RSA;
                    break;
                case "SHMR":
                    res = commands.SHMR;
                    break;
                case "ELGML":
                    res = commands.ELGML;
                    break;
                case "ENCODE":
                    res = commands.ENCODE;
                    break;
                case "DECODE":
                    res = commands.DECODE;
                    break;
                case "EXIT":
                    res = commands.EXIT;
                    break;
                case "CLEAR":
                    res = commands.CLEAR;
                    break;

                default:
                    res = commands.NONE;
                    break;
            }
            return res;
        }

        static private void doCommand(commands cmd)
        {
            switch (cmd)
            {
                case commands.DFHLM:
                    Console.WriteLine("Diffie-Hellman");
                    test.diffieHellmanTest();
                    break;
                case commands.ELGML:
                    Console.WriteLine("El-Gamal");
                    test.elGamalTest();
                    break;
                case commands.RSA:
                    Console.WriteLine("RSA");
                    test.rsaTest();
                    break;
                case commands.SHMR:
                    Console.WriteLine("Shamir");
                    test.shamirTest();
                    break;
                case commands.CLEAR:
                    Console.Clear();
                    break;


                default:
                    Console.WriteLine("Error: unknoun command");
                    break;
            }
        }
    }

    class test
    {
        static public void diffieHellmanTest()
        {
            DiffieHellman Alice = new DiffieHellman();
            DiffieHellman Bob = new DiffieHellman();

            Console.WriteLine("Enter close key for Alice");
            Alice.setCloseKey();
            Alice.setOpenKey();

            Console.WriteLine("Enter close key for Bob");
            Bob.setCloseKey();
            Bob.setOpenKey();

            Alice.setResKey(Bob.getOpenKey());
            Bob.setResKey(Alice.getOpenKey());

            if (Alice.getResKey() == Bob.getResKey())
            {
                Console.WriteLine("Diffie-Hellman success.");
                Console.WriteLine("Your secret key is " + Alice.getResKey());
            }
        }

        static public void elGamalTest()
        {
            ElGamal Alice = new ElGamal();
            ElGamal Bob = new ElGamal();

            Console.WriteLine("Enter close key for Alice");
            Alice.setPrivateKey();
            Alice.setPublicKey();

            Console.WriteLine("Enter close key for Bob");
            Bob.setPrivateKey();

            Console.WriteLine("Enter message for Bob");
            Bob.setMessage();

            Alice.getMessage(Bob.sendEncMessage(Alice.getPublicKey()));

            Console.WriteLine("Alice gets message: " + Alice.decMessage());
        }

        static public void rsaTest()
        {
            RSA Alice = new RSA();
            RSA Bob = new RSA();

            Console.WriteLine("Enter two prime numbers for Alice");
            Alice.setpq();
            Console.WriteLine("Enter encryption key");
            Alice.setEncKey();
            Alice.setDecKey();

            Bob.recievePublicKey(Alice.getPublicKey());

            Console.WriteLine("Enter Bob's message");
            Bob.setMes();
            Console.WriteLine("Alice get: " + Alice.decode(Bob.sendMes()));
        }

        static public void shamirTest()
        {
            Shamir Alice = new Shamir();
            Shamir Bob = new Shamir();

            Console.WriteLine("Enter p for Alice");
            Alice.setp();
            Console.WriteLine("Enter p for Bob");
            Bob.setp();

            Console.WriteLine("Enter Alice's private key");
            Alice.setPrivateKey();
            Console.WriteLine("Enter Bob's private key");
            Bob.setPrivateKey();

            Console.WriteLine("Enter Alice's message to Bob");
            Alice.setMessage();

            int firstStage = Bob.cipherFirst(Alice.cipherFirst(Alice.getMessage()));
            Console.WriteLine("Bob gets: " + Bob.cipherSecond(Alice.cipherSecond(firstStage)));
        }
    }
}
