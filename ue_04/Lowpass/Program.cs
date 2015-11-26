/*
    Pair-Programming
        fhs37248 Magdalena Wimmer
        fhs36111 Bernhard Steger
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lowpass
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bm;
            if (args.Length == 0) bm = createBM("input.png");
            else bm = createBM(args[0]);

            createLowPass(bm);
        }

        static Bitmap createBM(string url)
        {
            Bitmap bm = new Bitmap(Image.FromFile(url));
            return bm;
        }

        static void createLowPass(Bitmap bm)
        {
            Bitmap fin = new Bitmap(bm.Width, bm.Height);
            double r, g, b;
            double[] lowArr = { -1d / 8d, 2d / 8d, 6d / 8d, 2d / 8d, -1d / 8d };
            int a;
            Color col;

            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    r = 0;
                    g = 0;
                    b = 0;

                    for (int k = 0; k < lowArr.Length; k++)
                    {
                        a = Math.Min(Math.Max(i - 2 + k, 0), bm.Width - 1);

                        r += bm.GetPixel(a, j).R * lowArr[k];
                        g += bm.GetPixel(a, j).G * lowArr[k];
                        b += bm.GetPixel(a, j).B * lowArr[k];
                    }

                    r = Math.Min(Math.Max(r, 0), 255);
                    g = Math.Min(Math.Max(g, 0), 255);
                    b = Math.Min(Math.Max(b, 0), 255);
                    col = Color.FromArgb((int)r, (int)g, (int)b);
                    fin.SetPixel(i, j, col);
                }
            }
            Console.WriteLine("Created image with lowpass-filter in : outputLowpass.png");

            fin.Save("outputLowpass.png");
        }
    }
}
