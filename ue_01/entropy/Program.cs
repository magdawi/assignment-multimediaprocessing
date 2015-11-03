using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace entropy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> relFreq = new List<double>();
            if (args.Length == 0)
            {
                Console.WriteLine("Error! No Arguments are given!");
            }

            else
            {
                string inputFile = args[0];

                read(relFreq, inputFile);
                print(calcEntropie(relFreq));
            }
        }

        static double calcEntropie(List<double> relFreq)
        {
            double sumEntropie = 0;
            double subtotal = 0;

            foreach (var item in relFreq)
            {
                subtotal = (item / 100) * Math.Log(1 / (item / 100), 2);
                sumEntropie += subtotal;
            }
            return sumEntropie;
        }

        static void read(List<double> relFreq, string inputFile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(inputFile))
                {
                    string line;
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        relFreq.Add(Convert.ToDouble(line.Split('\t')[1]));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! File could not be read! Message: {0}", e);
            }
        }

        static void print(double output)
        {
            Console.WriteLine("Entropy\t" + output);
        }
    }
}
