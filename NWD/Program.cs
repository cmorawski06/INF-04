using System;

namespace NWD
{
    class NWD
    {
        /* *******************************************************************
         * nazwa funkcji:	NWD
         * argumenty:		a - integer
         *                  b - integer
         * typ zwracany:	Zwracane jest zmodyfikowane a (integer).
         * informacje:		Program prosi z poziomu konsoli o wprowadzenie dwóch liczb całkowitych (a oraz b). Następnie podaje ich największy wspólny dzielnik.
         * autor:		    Cyprian Morawski nr 16
         * ******************************************************************* */
        static int nwd(int a, int b)
        {
            while (a != b)
            {

                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            }
            return a;
        }
        public static void Main(string[] args)
        {
            int a, b;
            Console.Write("a = ");
            a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Największy wspólny dzielnik liczb " + a + " i " + b + " to " + nwd(a, b));
            Console.ReadKey();
        }

    }

}