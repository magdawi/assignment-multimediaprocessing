using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace convert
{
    class Program
    {
        static void Main(string[] args)
        {
            string sNumber = "";
            string sFromBase = "";
            string sToBase = "";
            char[] number = new char[8] { '0', '0', '0', '0', '0', '0', '0', '0' };
            int fromBase = 0;
            int toBase = 0;
            
            if (args.Length == 0)
            {
                Console.WriteLine("Error! No Arguments are given!");
            }

            else
            {
                sNumber = args[0];
                sFromBase = args[1];
                sToBase = args[2];
            }
            
            for (int i = 0; i < sNumber.Length; i++) number[i] = sNumber[sNumber.Length - 1 - i];
            try
            {
                fromBase = Convert.ToInt32(sFromBase);
                toBase = Convert.ToInt32(sToBase);
            }
            catch(Exception e)
            {
                Console.WriteLine("Convertion failed! Message: {0}", e);
            }
            
            double dec = convertToDec(number, fromBase);
            string output = convertToBase(dec, toBase);

            print(sNumber, fromBase, toBase, output);

        }

        static double convertToDec(char[] number, int fromBase)
        {
            double dec = 0;
            double sub = 0;
            for (int i = 0; i < number.Length; i++)
            {
                sub = (Math.Pow(fromBase, i)) * Char.GetNumericValue(number[i]);
                dec += sub;
            }
            return dec;
        }

        static string convertToBase(double dec, int toBase)
        {
            string total = "";
            string output = "";
            double sub = dec;
            while(sub != 0)
            {
                total += sub % toBase;
                sub = Math.Floor(sub/toBase);
            }
            for (int i = 0; i < total.Length; i++) output += total[total.Length - 1 - i];
            return output;
        }

        static void print(string number, int fromBase, int toBase, string output)
        {
            Console.WriteLine("number:\t\t" + number + "\nfrom base:\t" + fromBase + "\nto base:\t" + toBase + "\nnew number:\t" + output);
        }
    }
}
