using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decode
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            if (args.Length == 0)
            {
                Console.WriteLine("Error! No Arguments are given!");
            }

            else
            {
                input = args[0];
            }

            decode(input);
        }

        static void decode(string input)
        {
            string subcode = "";
            string output = "";
            bool access = true;
            for (int i = 0; i < input.Length-1; i++)
            {
                subcode += input[i];
                switch (subcode)
                {
                    case "01001":
                        output += "A";
                        subcode = "";
                        break;
                    case "10":
                        output += "F";
                        subcode = "";
                        break;
                    case "01000":
                        output += "I";
                        subcode = "";
                        break;
                    case "0111":
                        output += "M";
                        subcode = "";
                        break;
                    case "0101":
                        output += "N";
                        subcode = "";
                        break;
                    case "11":
                        output += "O";
                        subcode = "";
                        break;
                    case "0110":
                        output += "R";
                        subcode = "";
                        break;
                    case "00":
                        output += "T";
                        subcode = "";
                        break;
                    default:
                        break;
                }
                if(subcode.Length > 5)
                {
                    Console.WriteLine("Fehlerhafte Eingabe!");
                    access = false;
                    break;
                }
            }
            if(access) print(output);
        }

        static void print(string output)
        {
            Console.WriteLine(output);
        }
    }
}
