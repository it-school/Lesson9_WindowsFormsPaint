using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsPaint
{
    public partial class Form1 : Form
    {
        Graphics g;
        Random r;
        Paint p;
        Point point;

        public Form1()
        {
            InitializeComponent();
            r = new Random();
            p = new Paint();
            g = panel1.CreateGraphics();
            point = new Point();
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.Left = r.Next(this.Width-btnExit.Width);
            btnExit.Top = r.Next(this.Height-btnExit.Height);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // MessageBox.Show(e.Button.ToString());

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (p.Type)
            {
                /*
                case 1:
                    if (p.IsDrawing)
                        g.DrawLine(p.Pen, point.X, point.Y, e.X, e.Y); break;
                        */
                case 2:
                    if (p.IsFirstLinePoint)
                    {
                        point = e.Location;
                        p.IsFirstLinePoint = false;
                    }
                    else
                    {
                        g.DrawLine(p.Pen, point.X, point.Y, e.X, e.Y);
                        p.IsFirstLinePoint = true;
                    }
                    break;
            }

           

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (p.IsDrawing && p.Type == 1)
            {
                if (p.IsFirstDrawPoint)
                {
                    point = e.Location;
                    p.IsFirstDrawPoint = false;
                }
                g.DrawLine(p.Pen, point.X, point.Y, e.X, e.Y);
                point = e.Location;
            }
            
            Form1.ActiveForm.Text = "(" + e.X + "," + e.Y + ")";                
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            p.IsDrawing = true;
            if (e.Button == MouseButtons.Left)
                p.Pen.Color = p.ForegroundColor;
            else
                p.Pen.Color = p.BackgroundColor;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            p.IsDrawing = false;
        }

        private void palette_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                    p.ForegroundColor = colorDialog1.Color;
            if (e.Button == MouseButtons.Right)
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                     p.BackgroundColor = colorDialog1.Color;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            p.Pen.Width = trackBar1.Value;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            p.Type = 2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            p.Type = 1;
            p.IsFirstDrawPoint = true;
        }
    }
}
