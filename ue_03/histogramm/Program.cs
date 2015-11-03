// pairprogramming
// fhs37248 Magdalena Wimmer
// fhs36111 Bernhard Steger

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace _09_histogram {
    class Program {
        static void Main(string[] args) {

            Bitmap bmp = readImage("lena.png");
            int[] values = new int[256];
            int width = bmp.Width;
            int height = bmp.Height;
            Color pixel;


            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    pixel = bmp.GetPixel(i, j);
                    values[pixel.R]++;
                }
            }

            writeToFile("out.csv", values);
        }


        public static Bitmap readImage(string url) {
            Image img = Image.FromFile(url);
            Bitmap bmp = new Bitmap(img);
            return bmp;
        }


        public static void writeToFile(string url, int[] values) {
            using (StreamWriter sw = new StreamWriter(url)) {
                for (int i = 0; i < values.Length; i++) {
			        sw.WriteLine(values[i]);
			    }
            }
        }
    }
}
