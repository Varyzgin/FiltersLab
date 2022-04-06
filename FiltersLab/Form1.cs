using System;
using System.Drawing;
using System.Windows.Forms;

namespace FiltersLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap inImg;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string imagePath;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "image files|*.jpg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = dialog.FileName;
                inImg = new Bitmap(imagePath);
                this.pictureBox1.Image = inImg;
            }
            this.label1.Visible = false;
        }
        // если попали по label
        private void label1_Click(object sender, EventArgs e)
        {
            string imagePath;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "image files|*.jpg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = dialog.FileName;
                inImg = new Bitmap(imagePath);
                this.pictureBox1.Image = inImg;
            }
            this.label1.Visible = false;
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invert f = new Invert();
            Bitmap outImg = f.processImg(inImg);
            this.pictureBox2.Image = outImg;
        }

        private void grayShadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap outImg = GrayShades.Filter(inImg);
            this.pictureBox2.Image = outImg;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap outImg = Sepia.Filter(inImg);
            this.pictureBox2.Image = outImg;
        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap outImg = Brightness.Filter(inImg, 20);
            this.pictureBox2.Image = outImg;
        }

        private void grayWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap outImg = GrayWorld.Filter(inImg);
            this.pictureBox2.Image = outImg;
        }

        private void shiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap outImg = Shift.Filter(inImg, 50);
            this.pictureBox2.Image = outImg;
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters f = new Blur();
            Bitmap outImg = f.processImg(inImg);
            this.pictureBox2.Image = outImg;
        }

        private void gaussBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters f = new GaussBlur();
            Bitmap outImg = f.processImg(inImg);
            this.pictureBox2.Image = outImg;
        }

        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters f = new MotionBlur();
            Bitmap outImg = f.processImg(inImg);
            this.pictureBox2.Image = outImg;
        }

        private void emboseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap outImg = Embose.Filter(inImg);
            this.pictureBox2.Image = outImg;
        }

        private void autoContrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap outImg = AutoContrast.Filter(inImg);
            this.pictureBox2.Image = outImg;
        }

        private void perffectReflectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap outImg = PerfectReflector.Filter(inImg);
            this.pictureBox2.Image = outImg;
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap outImg = Dilation.Filter(inImg);
            this.pictureBox2.Image= outImg;
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap outImg = Erosion.Filter(inImg);
            this.pictureBox2.Image = outImg;
        }

        private void medianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap outImg = Median.Filter(inImg);
            this.pictureBox2.Image = outImg;
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap outImg = Sobel.Filter(inImg);
            this.pictureBox2.Image = outImg;
        }

        private void sharrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap outImg = Sharr.Filter(inImg);
            this.pictureBox2.Image = outImg;
        }
    }
}
