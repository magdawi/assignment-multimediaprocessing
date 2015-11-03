using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace relativ_frequency
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> charDict = new Dictionary<int, double>();
            double charAmount = 0;

            if (args.Length == 0)
            {
                Console.WriteLine("Error! No Arguments are given!");
            }

            else
            {
                string inputFile = args[0];
                string outputFile = args[1];

                read(charDict, charAmount, inputFile);
                print(charDict, outputFile);
            }
        }

        static void countChars(string line, Dictionary<int, double> charDict)
        {
            for (int i = 0; i < line.Length; i++)
            {
                int key = (int)line[i];
                if (charDict.ContainsKey(key)) charDict[key] += 1;
                else charDict.Add(key, 1);
            }
        }

        static void getRelativeFrequency(Dictionary<int, double> charDict, double charAmount)
        {
            List<int> keys = new List<int>(charDict.Keys);

            foreach (var item in keys)
            {
                charDict[item] = charDict[item] / charAmount * 100;
            }
        }

        static void read(Dictionary<int, double> charDict, double charAmount, string inputFile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(inputFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        countChars(line, charDict);
                        charAmount += line.Length;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! File could not be read! Message: {0}", e);
            }

            getRelativeFrequency(charDict, charAmount);
        }

        static void print(Dictionary<int, double> charDict, string outputFile)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    foreach (var item in charDict) writer.WriteLine("{0}\t{1}", item.Key, item.Value);
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! File could not be written in! Message: {0}", e);
            }
        }
    }
}
