// pairprogramming
// fhs37248 Magdalena Wimmer
// fhs36111 Bernhard Steger

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_huffman {
    internal class Program {

        private static void Main(string[] args) {
            string Example = "";
            if (args.Length == 0) Example = "Lorem ipsum dolor";
            else Example = args[0];
            var huffman = new Huffman<char>(Example);
            List<int> encoding = huffman.Encode(Example);
            List<char> decoding = huffman.Decode(encoding);
            var outString = new string(decoding.ToArray());
            Console.WriteLine(outString == Example ? "Encoding/decoding worked" : "Encoding/Decoding failed");

            var chars = new HashSet<char>(Example);
            foreach (char c in chars) {
                encoding = huffman.Encode(c);
                Console.Write("{0}:  ", c);
                foreach (int bit in encoding) {
                    Console.Write("{0}", bit);
                }
                Console.WriteLine();
            }
        }
    }
    
}
