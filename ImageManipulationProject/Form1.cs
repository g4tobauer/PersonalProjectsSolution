using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageManipulationProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_LoadImage_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            var openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = "C:\\Logo",
                Filter = @"bmp files (*.bmp)|*.bmp|All files (*.bmp)|*.bmp",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            Stream myStream1 = null;
            Stream myStream2 = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    myStream1 = openFileDialog1.OpenFile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    myStream2 = openFileDialog1.OpenFile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }
            if (myStream1 != null && myStream2 != null)
            {
                var teste1 = SubtraiImagem((Bitmap) Image.FromStream(myStream1), (Bitmap) Image.FromStream(myStream2),
                    true);
                ImprimeImagem(teste1, 0, 0);
                myStream1.Close();
                myStream2.Close();
            }
        }

        private void ImprimeImagem(Bitmap image, int x, int y)
        {
            try
            {
                Graphics formGraphics = this.CreateGraphics();
                formGraphics.DrawImage(image, x, y);
                formGraphics.Dispose();
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show(@"There was an error opening the bitmap." +
                                @"Please check the path.");
            }
        }

        private Bitmap SomaImagem(Bitmap imagemA, Bitmap imagemB, bool resetColor)
        {
            Bitmap newImageA = null;
            if (imagemA.PixelFormat == imagemB.PixelFormat)
            {
                var Hightwidth = imagemA.Width > imagemB.Width ? imagemA.Width : imagemB.Width;
                var Hightheight = imagemA.Height > imagemB.Height ? imagemA.Height : imagemB.Height;
                var Lowtwidth = imagemA.Width < imagemB.Width ? imagemA.Width : imagemB.Width;
                var Lowtheight = imagemA.Height < imagemB.Height ? imagemA.Height : imagemB.Height;

                newImageA = new Bitmap(Hightwidth, Hightheight, imagemA.PixelFormat);

                for (int y = 0; y < Lowtheight; y++)
                    for (int x = 0; x < Lowtwidth; x++)
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

                        if (resetColor)
                            newImageA.SetPixel(x, y, Color.FromArgb(c));
                        else
                            newImageA.SetPixel(x, y, Color.FromArgb(A, R, G, B));
                    }
            }
            return newImageA;
        }

        private Bitmap SubtraiImagem(Bitmap imagemA, Bitmap imagemB, bool resetColor)
        {
            Bitmap newImageA = null;
            if (imagemA.PixelFormat == imagemB.PixelFormat)
            {
                var hightwidth = imagemA.Width > imagemB.Width ? imagemA.Width : imagemB.Width;
                var hightheight = imagemA.Height > imagemB.Height ? imagemA.Height : imagemB.Height;
                var lowtwidth = imagemA.Width < imagemB.Width ? imagemA.Width : imagemB.Width;
                var lowtheight = imagemA.Height < imagemB.Height ? imagemA.Height : imagemB.Height;

                newImageA = new Bitmap(hightwidth, hightheight, imagemA.PixelFormat);

                for (int y = 0; y < lowtheight; y++)
                    for (int x = 0; x < lowtwidth; x++)
                    {
                        var colorA = imagemA.GetPixel(x, y);
                        var colorB = imagemB.GetPixel(x, y);

                        var A = (colorA.A + colorB.A) / 2;
                        var R = colorA.R - colorB.R;
                        var G = colorA.G - colorB.G;
                        var B = colorA.B - colorB.B;

                        R = R < 0 ? 0: R;
                        G = G < 0 ? 0 : G;
                        B = B < 0 ? 0 : B;

                        var c = colorA.ToArgb() - colorB.ToArgb();

                        if (resetColor)
                            newImageA.SetPixel(x, y, Color.FromArgb(c));
                        else
                            newImageA.SetPixel(x, y, Color.FromArgb(A, R, G, B));
                    }
            }
            return newImageA;
        }
    }
}
