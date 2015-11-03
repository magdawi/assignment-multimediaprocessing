//pairprogramming
//fhs37248 Magdalena Wimmer
//fhs36111 Bernhard Steger

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mse
{
    class Program
    {
        static void Main(string[] args)
        {
            Image picA, picB;
            string pic1, pic2;

            try
            {
                if (args.Length == 0)
                {
                    pic1 = "img1.jpg";
                    pic2 = "img2.jpg";
                }
                else
                {
                    pic1 = args[0];
                    pic2 = args[1];
                }
                picA = Image.FromFile(pic1);
                picB = Image.FromFile(pic2);

                Bitmap bitA = new Bitmap(picA);
                Bitmap bitB = new Bitmap(picB);
                Console.WriteLine("MSE: " + calcMSE(bitA, bitB));
                Console.WriteLine("First Image: " + pic1 + "\nSecond Image: " + pic2);
            }
            catch
            {
                Console.WriteLine("no files found");
            }
            
        }

        static double calcMSE(Bitmap A, Bitmap B)
        {
            double sum = 0;
            double mse = 0;
            double errR, errG, errB;
            Color p1, p2;
            if (A.Height != B.Height || A.Width != B.Width) Console.WriteLine("Images have to be same size!!");
            else
            {
                int h = A.Height;
                int w = A.Width;

                for (int i = 0; i < w; ++i)
                {
                    for (int j = 0; j < h; ++j)
                    {
                        p1 = A.GetPixel(i, j);
                        p2 = B.GetPixel(i, j);
                        errR = p1.R - p2.R;
                        errG = p1.G - p2.G;
                        errB = p1.B - p2.B;
                        sum += (errR * errR);
                        sum += (errG * errG);
                        sum += (errB * errB);
                    }
                }
                mse = sum / (3 * h * w);
            }
            return mse;
        }
    }
}
