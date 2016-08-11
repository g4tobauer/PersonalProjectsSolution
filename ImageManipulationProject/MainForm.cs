using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageManipulationProject
{
    public partial class MainForm : Form
    {
        private Bitmap firstBitmapImage;
        private Bitmap secondBitmapImage;

        private Bitmap imageBuffer;
        public MainForm()
        {
            InitializeComponent();
        }

        private void ProcuraImagem(ref Bitmap bitmapImage)
        {
            Stream stream = null;
            var openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = "C:\\Logo",
                Filter = @"jpg files (*.jpg)|*.jpg|All files (*.jpg)|*.jpg",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    stream = openFileDialog1.OpenFile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            if (stream != null)
            {
                using (stream)
                {
                    bitmapImage = (Bitmap)Image.FromStream(stream);
                    ImprimeImagem(bitmapImage, 0, 0);
                }
            }
        }

        private void btn_ProcuraImagem_Click(object sender, EventArgs e)
        {
            ProcuraImagem(ref firstBitmapImage);
        }

        private void ImprimeImagem(Bitmap image, int x, int y)
        {
            try
            {
                Graphics formGraphics = pnl_Draw.CreateGraphics();
                formGraphics.Clear(Color.Transparent);
                formGraphics.DrawImage(image, x, y);
                formGraphics.Dispose();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(@"There was an error opening the bitmap." +
                                @"Please check the path.");
            }
        }

        private void btn_AddImage_Click(object sender, EventArgs e)
        {
            ProcuraImagem(ref secondBitmapImage);
            imageBuffer = ImageOperation.Sum(firstBitmapImage, secondBitmapImage, chk_ResetColor.Checked);
            ImprimeImagem(imageBuffer,0, 0);
        }

        private void btn_SubImage_Click(object sender, EventArgs e)
        {
            ProcuraImagem(ref secondBitmapImage);
            imageBuffer = ImageOperation.Sub(firstBitmapImage, secondBitmapImage, chk_ResetColor.Checked);
            ImprimeImagem(imageBuffer,0, 0);
        }

        private void btn_SaveImage_Click(object sender, EventArgs e)
        {
            firstBitmapImage = imageBuffer;
        }

        private void btn_Mult_Click(object sender, EventArgs e)
        {
            ProcuraImagem(ref secondBitmapImage);
            imageBuffer = ImageOperation.Mul(firstBitmapImage, secondBitmapImage, chk_ResetColor.Checked);
            ImprimeImagem(imageBuffer, 0, 0);
        }

        private void btn_Div_Click(object sender, EventArgs e)
        {
            ProcuraImagem(ref secondBitmapImage);
            imageBuffer = ImageOperation.Div(firstBitmapImage, secondBitmapImage, chk_ResetColor.Checked);
            ImprimeImagem(imageBuffer, 0, 0);
        }
    }
}
