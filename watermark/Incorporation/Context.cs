﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace watermark.Incorporation
{
    class Context
    {
        public static double Accuracy(string a, string b)
        {
            int count = 0;
            if((a != null)&&(b != null))
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if(a[i] != b[i])
                        count ++;
                }
            }
            return 1 - (double)count / a.Length;
        }

        public static double GetBlueColorBright(int x, int y, Bitmap bmp)
        {
            return bmp.GetPixel(x, y).B;
        }

        public static Bitmap SetBlueColorBright(int x, int y, Bitmap bmp, double delta)
        {
            int r, g, b;
            int deltaInt = Convert.ToInt32(delta);
            r = bmp.GetPixel(x, y).R;
            g = bmp.GetPixel(x, y).G;
            b = bmp.GetPixel(x, y).B + deltaInt;
            if (b > 255) b = 255;
            if (b < 0) b = 0;
            Color color = Color.FromArgb(r, g, b);
            bmp.SetPixel(x, y, color);
            return bmp;
        }

        public static double GetBrightness(int x, int y, Bitmap bmp)
        {
            int r, g, b;
            r = bmp.GetPixel(x, y).R;
            g = bmp.GetPixel(x, y).G;
            b = bmp.GetPixel(x, y).B;
            return 0.3 * r + 0.59 * g + 0.11 * b;
        }

        public static Bitmap SetBrightness(int x, int y, Bitmap bmp, double delta)
        {
            int r, g, b;
            r = bmp.GetPixel(x, y).R + Convert.ToInt32(delta * 0.3);
            g = bmp.GetPixel(x, y).G + Convert.ToInt32(delta * 0.59);
            b = bmp.GetPixel(x, y).B + Convert.ToInt32(delta * 0.11);
            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;
            Color color = Color.FromArgb(r, g, b);
            bmp.SetPixel(x, y, color);
            return bmp;
        }

        public static int CountFor12AB(List<MyPixel> pixels, bool Lmark, bool mask)
        {
            int count = 0;
            foreach(MyPixel pixel in pixels)
            {
                if ((pixel.Lmark == Lmark)&&(pixel.mask == mask))
                {
                    count++;
                }
            }
            return count;
        }

        public static double MeanFor12AB(List<MyPixel> pixels, bool Lmark, bool mask)
        {
            double sum = 0;
            int count = 0;
            foreach (MyPixel pixel in pixels)
            {
                if ((pixel.Lmark == Lmark) && (pixel.mask == mask))
                {
                    sum += pixel.bright;
                    count++;
                }
            }
            return sum/count;
        }

        public static double MeanFor12(List<MyPixel> pixels, bool Lmark)
        {
            double sum = 0;
            int count = 0;
            foreach (MyPixel pixel in pixels)
            {
                if (pixel.Lmark == Lmark)
                {
                    sum += pixel.bright;
                    count++;
                }
            }
            return sum / count;
        }
    }
}
