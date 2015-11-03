//pairprogramming
//fhs37248 Magdalena Wimmer
//fhs36111 Bernhard Steger

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pointproc
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            string img = "";
            Image image;
            Bitmap bmp;

            try
            {
                if(args.Length == 0)
                {
                    Console.WriteLine("Keine Argumente übergeben!");
                }
                else
                {
                    number = Convert.ToInt32(args[0]);
                    img = args[1];
                }
            }
            catch
            {
                Console.WriteLine("Error!");
            }

            image = Image.FromFile(img);
            bmp = GetBitmap(img);

            switch (number)
            {
                case 1:
                    Invert(bmp);
                    break;
                case 2:
                    Clamp(bmp);
                    break;
                case 3:
                    Multiply4AndClamp(bmp);
                    break;
                case 4:
                    Quantization(bmp);
                    break;
                case 5:
                    Threshold(bmp);
                    break;
                case 0:
                    Invert(bmp);
                    bmp = GetBitmap(img);
                    Clamp(bmp);
                    bmp = GetBitmap(img);
                    Multiply4AndClamp(bmp);
                    bmp = GetBitmap(img);
                    Quantization(bmp);
                    bmp = GetBitmap(img);
                    Threshold(bmp);
                    break;
                default:
                    Console.WriteLine("method with number " + number + " does not exist!");
                    break;
            }
        }

        static void Invert(Bitmap bmp)
        {
            int R, G, B;
            Color value;
            
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = 255 - bmp.GetPixel(i, j).R;
                    G = 255 - bmp.GetPixel(i, j).G;
                    B = 255 - bmp.GetPixel(i, j).B;
                    value = Color.FromArgb(R, G, B);
                    bmp.SetPixel(i, j, value);
                }
            }
            Print(bmp, "inverted");
        }

        static void Clamp(Bitmap bmp)
        {
            int R, G, B;
            Color value;
            int min = 75;
            int max = 180;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R;
                    G = bmp.GetPixel(i, j).G;
                    B = bmp.GetPixel(i, j).B;

                    if (R > max) R = max;
                    if (R < min) R = min;
                    if (G > max) G = max;
                    if (G < min) G = max;
                    if (B > max) B = max;
                    if (B < min) B = max;

                    value = Color.FromArgb(R, G, B);
                    bmp.SetPixel(i, j, value);
                }
            }
            Print(bmp, "clamp");
        }

        static void Multiply4AndClamp(Bitmap bmp)
        {
            int R, G, B;
            Color value;
            int min = 2;
            int max = 253;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R * 4;
                    G = bmp.GetPixel(i, j).G * 4;
                    B = bmp.GetPixel(i, j).B * 4;

                    if (R > max) R = max;
                    if (R < min) R = min;
                    if (G > max) G = max;
                    if (G < min) G = max;
                    if (B > max) B = max;
                    if (B < min) B = max;

                    value = Color.FromArgb(R, G, B);
                    bmp.SetPixel(i, j, value);
                }
            }
            Print(bmp, "multiply4AndClamp");
        }

        static void Quantization(Bitmap bmp)
        {
            int R, G, B;
            Color value;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R / 16;
                    G = bmp.GetPixel(i, j).G / 16;
                    B = bmp.GetPixel(i, j).B / 16;
                    R *= 16;
                    G *= 16;
                    B *= 16;

                    value = Color.FromArgb(R, G, B);
                    bmp.SetPixel(i, j, value);
                }
            }
            Print(bmp, "quantization");
        }

        static void Threshold(Bitmap bmp)
        {
            int R, G, B;
            Color value;
            int val = 128;
            int calc;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R;
                    G = bmp.GetPixel(i, j).G;
                    B = bmp.GetPixel(i, j).B;
                    calc = ((R + G + B) / 3);

                    if (calc > val) value = Color.FromArgb(255, 255, 255);
                    else value = Color.FromArgb(0, 0, 0);

                    bmp.SetPixel(i, j, value);
                }
            }
            Print(bmp, "threshold");
        }

        static Bitmap GetBitmap(string img)
        {
            return new Bitmap(img);
        }

        static void Print(Bitmap result, string postfix)
        {
            string filename = "out_" + postfix + ".png";
            Console.WriteLine("Saved to File: " + filename);
            result.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
