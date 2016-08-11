using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulationProject
{
    public class ImageOperation
    {
        public static Bitmap NormalizeImage(Bitmap model, Bitmap image)
        {
            var modelWidth = (int)(model.Width / 2);
            var modelHeight = (int) (model.Height/2);

            var imageWidth = (int)(image.Width / 2);
            var imageHeight = (int)(image.Height / 2);

            var offsetX = modelWidth - imageWidth;
            var offsetY = modelHeight - imageHeight;

            for (int y = 0; y < model.Height; y++)
            {
                for (int x = 0; x < model.Width; x++)
                {
                    if ((y - offsetY) >= 0 && (y - offsetY < image.Height))
                    {
                        if ((x - offsetX) >= 0 && (x - offsetX < image.Width))
                        {
                            var color = image.GetPixel(x - offsetX, y - offsetY);
                            model.SetPixel(x,y,color);
                        }
                        else
                        {
                            model.SetPixel(x, y, Color.Black);
                        }
                    }
                    else
                    {
                        model.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return model;
        }

        public static Bitmap Sum(Bitmap imagemA, Bitmap imagemB, bool resetColor)
        {
            Bitmap newImageA = null;
            if (imagemA.PixelFormat == imagemB.PixelFormat)
            {
                var hightwidth = imagemA.Width > imagemB.Width ? imagemA.Width : imagemB.Width;
                var hightheight = imagemA.Height > imagemB.Height ? imagemA.Height : imagemB.Height;
                //var lowtwidth = imagemA.Width < imagemB.Width ? imagemA.Width : imagemB.Width;
                //var lowtheight = imagemA.Height < imagemB.Height ? imagemA.Height : imagemB.Height;

                newImageA = new Bitmap(hightwidth, hightheight, imagemA.PixelFormat);
                imagemA = NormalizeImage(newImageA, imagemA);
                newImageA = new Bitmap(hightwidth, hightheight, imagemA.PixelFormat);
                imagemB = NormalizeImage(newImageA, imagemB);

                newImageA = new Bitmap(hightwidth, hightheight, imagemA.PixelFormat);

                for (int y = 0; y < hightheight; y++)
                    for (int x = 0; x < hightwidth; x++)
                    {
                        var colorA = imagemA.GetPixel(x, y);
                        var colorB = imagemB.GetPixel(x, y);

                        var A = (colorA.A + colorB.A) / 2;
                        var R = colorA.R + colorB.R;
                        var G = colorA.G + colorB.G;
                        var B = colorA.B + colorB.B;

                        R = R > 255 ? 255 : R;
                        G = G > 255 ? 255 : G;
                        B = B > 255 ? 255 : B;

                        var c = colorA.ToArgb() + colorB.ToArgb();

                        newImageA.SetPixel(x, y, resetColor ? Color.FromArgb(c) : Color.FromArgb(A, R, G, B));
                    }
            }
            return newImageA;
        }
        public static Bitmap Sub(Bitmap imagemA, Bitmap imagemB, bool resetColor)
        {
            Bitmap newImageA = null;
            if (imagemA.PixelFormat == imagemB.PixelFormat)
            {
                var hightwidth = imagemA.Width > imagemB.Width ? imagemA.Width : imagemB.Width;
                var hightheight = imagemA.Height > imagemB.Height ? imagemA.Height : imagemB.Height;
                var lowtwidth = imagemA.Width < imagemB.Width ? imagemA.Width : imagemB.Width;
                var lowtheight = imagemA.Height < imagemB.Height ? imagemA.Height : imagemB.Height;

                newImageA = new Bitmap(hightwidth, hightheight, imagemA.PixelFormat);
                imagemA = NormalizeImage(newImageA, imagemA);
                newImageA = new Bitmap(hightwidth, hightheight, imagemA.PixelFormat);
                imagemB = NormalizeImage(newImageA, imagemB);

                newImageA = new Bitmap(hightwidth, hightheight, imagemA.PixelFormat);

                for (int y = 0; y < hightheight; y++)
                    for (int x = 0; x < hightwidth; x++)
                    {
                        var colorA = imagemA.GetPixel(x, y);
                        var colorB = imagemB.GetPixel(x, y);

                        var A = (colorA.A + colorB.A) / 2;
                        var R = colorA.R - colorB.R;
                        var G = colorA.G - colorB.G;
                        var B = colorA.B - colorB.B;

                        R = R < 0 ? 0 : R;
                        G = G < 0 ? 0 : G;
                        B = B < 0 ? 0 : B;

                        var c = colorA.ToArgb() - colorB.ToArgb();

                        newImageA.SetPixel(x, y, resetColor ? Color.FromArgb(c) : Color.FromArgb(A, R, G, B));
                    }
            }
            return newImageA;
        }
        public static Bitmap Mul(Bitmap imagemA, Bitmap imagemB, bool resetColor)
        {
            Bitmap newImageA = null;
            if (imagemA.PixelFormat == imagemB.PixelFormat)
            {
                var hightwidth = imagemA.Width > imagemB.Width ? imagemA.Width : imagemB.Width;
                var hightheight = imagemA.Height > imagemB.Height ? imagemA.Height : imagemB.Height;
                var lowtwidth = imagemA.Width < imagemB.Width ? imagemA.Width : imagemB.Width;
                var lowtheight = imagemA.Height < imagemB.Height ? imagemA.Height : imagemB.Height;

                newImageA = new Bitmap(hightwidth, hightheight, imagemA.PixelFormat);
                imagemA = NormalizeImage(newImageA, imagemA);
                newImageA = new Bitmap(hightwidth, hightheight, imagemA.PixelFormat);
                imagemB = NormalizeImage(newImageA, imagemB);

                newImageA = new Bitmap(hightwidth, hightheight, imagemA.PixelFormat);

                for (int y = 0; y < hightheight; y++)
                    for (int x = 0; x < hightwidth; x++)
                    {
                        var colorA = imagemA.GetPixel(x, y);
                        var colorB = imagemB.GetPixel(x, y);

                        var A = (colorA.A + colorB.A) / 2;
                        var R = colorA.R * colorB.R;
                        var G = colorA.G * colorB.G;
                        var B = colorA.B * colorB.B;

                        R = R > 255 ? 255 : R;
                        G = G > 255 ? 255 : G;
                        B = B > 255 ? 255 : B;

                        var c = colorA.ToArgb() * colorB.ToArgb();

                        newImageA.SetPixel(x, y, resetColor ? Color.FromArgb(c) : Color.FromArgb(A, R, G, B));
                    }
            }
            return newImageA;
        }
        public static Bitmap Div(Bitmap imagemA, Bitmap imagemB, bool resetColor)
        {
            Bitmap newImageA = null;
            if (imagemA.PixelFormat == imagemB.PixelFormat)
            {
                var hightwidth = imagemA.Width > imagemB.Width ? imagemA.Width : imagemB.Width;
                var hightheight = imagemA.Height > imagemB.Height ? imagemA.Height : imagemB.Height;
                var lowtwidth = imagemA.Width < imagemB.Width ? imagemA.Width : imagemB.Width;
                var lowtheight = imagemA.Height < imagemB.Height ? imagemA.Height : imagemB.Height;

                newImageA = new Bitmap(hightwidth, hightheight, imagemA.PixelFormat);
                imagemA = NormalizeImage(newImageA, imagemA);
                newImageA = new Bitmap(hightwidth, hightheight, imagemA.PixelFormat);
                imagemB = NormalizeImage(newImageA, imagemB);

                newImageA = new Bitmap(hightwidth, hightheight, imagemA.PixelFormat);

                for (int y = 0; y < hightheight; y++)
                    for (int x = 0; x < hightwidth; x++)
                    {
                        var colorA = imagemA.GetPixel(x, y);
                        var colorB = imagemB.GetPixel(x, y);

                        var A = (colorA.A + colorB.A) / 2;
                        var R = colorB.R != 0 ? colorA.R / colorB.R : 0;
                        var G = colorB.G != 0 ? colorA.G / colorB.G : 0;
                        var B = colorB.B != 0 ? colorA.B / colorB.B : 0;

                        R = R < 0 ? 0 : R;
                        G = G < 0 ? 0 : G;
                        B = B < 0 ? 0 : B;

                        var c = colorA.ToArgb() * colorB.ToArgb();

                        newImageA.SetPixel(x, y, resetColor ? Color.FromArgb(c) : Color.FromArgb(A, R, G, B));
                    }
            }
            return newImageA;
        }
    }
}
