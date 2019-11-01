using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DRAW
{
    public partial class Form1 : Form
    {
        Bitmap pic;
        Bitmap pic1;
        string mode;
        int x1, y1;
        int xcl1, ycl1;
        public Form1()
        {
             mode = "Линия";
            InitializeComponent();
            
            pic = new Bitmap(800, 600);
            pic1 = new Bitmap(800, 600);
            x1 = y1 = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ColorBox.BackColor = colorDialog1.Color;


        }

        private void ColorBox_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if(saveFileDialog1.FileName!="")
            pic.Save(saveFileDialog1.FileName);
            
               
        }

        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if(openFileDialog1.FileName!="")
            {
                pic = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = pic;
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            mode = "Линия";
        }

        private void Crug_CheckedChanged(object sender, EventArgs e)
        {
            mode = "Круг";
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            mode = "Прямоугольник";
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Pen p;
            p = new Pen(ColorBox.BackColor, trackBar1.Value);
            Graphics g;
            g = Graphics.FromImage(pic);
            if (mode == "Прямоугольник")
            {

               
                g.DrawRectangle(p, xcl1, ycl1,e.X - xcl1, e.Y - ycl1);
            }

            if (mode == "Круг")
            {
                
                g.DrawEllipse(p, xcl1, ycl1, e.X - xcl1, e.Y - ycl1);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Graphics g;
            g = Graphics.FromImage(pic);
            g.Clear(Color.White);
            pictureBox1.Image = pic;
        }

       

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
           xcl1= e.X;
            ycl1= e.Y;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen p;
            p = new Pen(ColorBox.BackColor, trackBar1.Value);
            
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            //p.CustomStartCap.BaseCap = System.Drawing.Drawing2D.LineCap.Round;
            Graphics g;
            g = Graphics.FromImage(pic);
            Graphics g1;
            g1 = Graphics.FromImage(pic1);


            if (e.Button == MouseButtons.Left)
            {
                if (mode == "Линия")
                {
                    g.DrawLine(p, x1, y1, e.X, e.Y);
                }

                if (mode == "Прямоугольник")
                {
                    g1.Clear(Color.White);
                    int x, y;
                    x = xcl1;
                    y = ycl1;
                    if (x > e.X) x = e.X;
                    if (y > e.Y) y = e.Y;
                  
                    g1.DrawRectangle(p, x, y, Math.Abs(e.X-xcl1), Math.Abs(e.Y-ycl1));
                }

                if (mode == "Круг")
                {
                    g1.Clear(Color.White);
                   
                    g1.DrawEllipse(p, xcl1, ycl1, e.X - xcl1, e.Y - ycl1);
                }
                g1.DrawImage(pic, 0, 0);

                pictureBox1.Image = pic1;
               
            }
            x1 = e.X;
            y1 = e.Y;
        }
    }
}
