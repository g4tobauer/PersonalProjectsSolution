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

        private bool ProcuraImagem()
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
                    imageBuffer = (Bitmap)Image.FromStream(stream);
                }
                return true;
            }
            return false;
        }

        private void btn_ProcuraImagem_Click(object sender, EventArgs e)
        {
            if (ProcuraImagem())
            {
                firstBitmapImage = imageBuffer;
                ImprimeImagem(firstBitmapImage, 0, 0);
            }
        }

        private void ImprimeImagem(Bitmap image, int x, int y)
        {
            try
            {
                var ratioX = (double)this.Width / image.Width;
                var ratioY = (double)this.Height / image.Height;
                var ratio = Math.Min(ratioX, ratioY);

                var newWidth = (int)(image.Width * ratio);
                var newHeight = (int)(image.Height * ratio);

                Image imageObject = new Bitmap(image, newWidth, newHeight);
                
                MemoryStream stream = new MemoryStream();
                imageObject.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                Graphics formGraphics = pnl_Draw.CreateGraphics();
                formGraphics.Clear(Color.Transparent);
                formGraphics.DrawImage(imageObject, x, y);
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
            if (firstBitmapImage != null)
            {
                if (ProcuraImagem())
                {
                    secondBitmapImage = imageBuffer;
                    imageBuffer = ImageOperation.Sum(firstBitmapImage, secondBitmapImage, chk_ResetColor.Checked);
                    ImprimeImagem(imageBuffer, 0, 0);
                }
            }
        }

        private void btn_SubImage_Click(object sender, EventArgs e)
        {
            if (firstBitmapImage != null)
            {
                if (ProcuraImagem())
                {
                    secondBitmapImage = imageBuffer;
                    imageBuffer = ImageOperation.Sub(firstBitmapImage, secondBitmapImage, chk_ResetColor.Checked);
                    ImprimeImagem(imageBuffer, 0, 0);
                }
            }
        }

        private void btn_SaveImage_Click(object sender, EventArgs e)
        {
            firstBitmapImage = imageBuffer;
        }

        private void btn_Mult_Click(object sender, EventArgs e)
        {
            if (firstBitmapImage != null)
            {
                if (ProcuraImagem())
                {
                    secondBitmapImage = imageBuffer;
                    imageBuffer = ImageOperation.Mul(firstBitmapImage, secondBitmapImage, chk_ResetColor.Checked);
                    ImprimeImagem(imageBuffer, 0, 0);
                }
            }
        }

        private void btn_Div_Click(object sender, EventArgs e)
        {
            if (firstBitmapImage != null)
            {
                if (ProcuraImagem())
                {
                    secondBitmapImage = imageBuffer;
                    imageBuffer = ImageOperation.Div(firstBitmapImage, secondBitmapImage, chk_ResetColor.Checked);
                    ImprimeImagem(imageBuffer, 0, 0);
                }
            }
        }

        private void btn_ResetImage_Click(object sender, EventArgs e)
        {
            ImprimeImagem(firstBitmapImage, 0, 0);
        }
    }
}
