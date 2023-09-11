using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Math1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] Line =
            {
                 "Linear","Quadratic","Cubic","Rational","Logarithmic"
            };
            comboBox1.Items.AddRange(Line);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            Point[] lineY = { new Point(10, -190), new Point(0, -200), new Point(-10, -190) };
            Point[] lineX = { new Point(190, 10), new Point(200, 0), new Point(190, -10) };
            Pen pen = new Pen(Color.Black, 2.0f);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.TranslateTransform(260, 260, MatrixOrder.Append);
            g.DrawString("Y", Font, Brushes.Black, new Point(-20, -210));
            g.DrawString("X", Font, Brushes.Black, new Point(200, -20));
            g.DrawLine(pen, -200, 0, 200, 0);
            g.DrawLine(pen, 0, -200, 0, 200);
            g.DrawLines(pen, lineX);
            g.DrawLines(pen, lineY);
            int X = -200;
            for (; X < 200; X += 20)
                g.DrawLine(pen, X, -5, X, 5);
            int Y = -180;
            for (; Y < 200; Y += 20)
                g.DrawLine(pen, -5, Y, 5, Y);
            if (comboBox1.SelectedItem.ToString() == "Linear")
            {
                int x1 = 0, x2 = 1;
                int y1 = 3 * x1 + 0;
                int y2 = 3 * x2 + 0;
                g.DrawLine(new Pen(Color.Orange, 2), x1 * 70, y1 * (-70), x2 * 70, y2 * (-70));
                g.DrawLine(new Pen(Color.Orange, 2), x1 * -70, y1 * (70), x2 * -70, y2 * (70));
            }
            if (comboBox1.SelectedItem.ToString() == "Quadratic")
            {
                Pen q = new Pen(Color.Blue, 2);

                Point[] points =
                {
                new Point(-100, -200),
                new Point(0, 0),
                new Point(100, -200)
            
                };
                g.DrawCurve(q, points);
                q.Dispose();
            }
            if (comboBox1.SelectedItem.ToString() == "Cubic")
            {
                Pen kyb = new Pen(Color.Red, 2);
                double a = 1, b = 0, c = 0, d = 0;
                List<PointF> points = new List<PointF>();
                for (double x = -20; x <= 20; x += 0.1)
                {
                    double y = a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * x + d;
                    points.Add(new PointF((float)x * 30, (float)y * (-30)));
                }
                g.DrawLines(kyb, points.ToArray());
                kyb.Dispose();
            }
            if (comboBox1.SelectedItem.ToString() == "Rational")
            {
                double a = 1, b = -2, c = 1, d = 1, k = 2;
                for (int x = 0; x <= 200; x++)
                {
                    double y = (a * x * x + b * x + c) / (d * x + k);
                    int yPixel = 0 - (int)y;
                    g.FillRectangle(Brushes.DarkBlue, x, yPixel, 2, 2);
                }
            }
            if (comboBox1.SelectedItem.ToString() == "Logarithmic")
            {
                Pen log = new Pen(Color.Brown, 2);
                double a = 2;
                List<PointF> points = new List<PointF>();
                for (double x = 0.1; x <= 20; x += 0.1)
                {
                    double y = Math.Log(x, a);
                    points.Add(new PointF((float)x * 30, (float)y * (-30)));
                }
                g.DrawLines(log, points.ToArray());
                log.Dispose();
            }
            pen.Dispose();
            g.Dispose();
        }
    }
}
