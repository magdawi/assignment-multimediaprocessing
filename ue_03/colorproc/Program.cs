// pairprogramming
// fhs37248 Magdalena Wimmer
// fhs36111 Bernhard Steger

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace _11_color {
    class Program {
        static void Main(string[] args) {

            Bitmap bmp = readImage(args[1]);

            switch (args[0]) {
                case "1":
                    channel(bmp);
                    break;
                case "2":
                    grayscale(bmp);
                    break;
                case "3":
                    swapColors(bmp);
                    break;
                default:
                    Console.WriteLine("Missing argument for an operation.");
                    break;
            }
        }



        public static void channel(Bitmap bmp) {
            Color pixel, newColor;

            for (int i = 0; i < bmp.Width; i++) {
                for (int j = 0; j < bmp.Height; j++) {
                    pixel = bmp.GetPixel(i, j);

                    newColor = Color.FromArgb(0, 0, pixel.B);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            writeImage("out.png", bmp);
        }


        public static void grayscale(Bitmap bmp) {
            Color pixel, newColor;
            int mean = 0;

            for (int i = 0; i < bmp.Width; i++) {
                for (int j = 0; j < bmp.Height; j++) {
                    pixel = bmp.GetPixel(i, j);
                    mean = (pixel.R + pixel.G + pixel.B) / 3;

                    newColor = Color.FromArgb(mean, mean, mean);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            writeImage("out.png", bmp);
        }


        public static void swapColors(Bitmap bmp) {
            Color pixel, newColor;
            int R, G, B;

            for (int i = 0; i < bmp.Width; i++) {
                for (int j = 0; j < bmp.Height; j++) {
                    pixel = bmp.GetPixel(i, j);
                    R = pixel.R;
                    G = pixel.G;
                    B = pixel.B;

                    newColor = Color.FromArgb(G, R, B);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            writeImage("out.png", bmp);
        }


        public static Bitmap readImage(string url) {
            Image img = Image.FromFile(url);
            Bitmap bmp = new Bitmap(img);
            return bmp;
        }


        public static void writeImage(string url, Bitmap bmp) {
            bmp.Save(url, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
