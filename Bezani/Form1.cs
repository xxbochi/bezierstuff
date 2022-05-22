using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bezani
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Brushes.White, 3.0f);
        Pen linePen = new Pen(Brushes.Red, 2.5f);
        SolidBrush brush = new SolidBrush(Color.White);
        SolidBrush lineBrush = new SolidBrush(Color.Red);


        float t = 0.5f;

        int pt0X = 335;
        int pt0Y = 335;
        int pt1X = 400;
        int pt1Y = 235;
        int pt2X = 400;
        int pt2Y = 390;

        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Point previousPoint = new Point(pt0X, pt0Y);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            circleStuff.DrawCircle(g, pen, pt0X, pt0Y, 5);
            circleStuff.FillCircle(g, brush, pt0X, pt0Y, 5);

            circleStuff.DrawCircle(g, pen, pt1X, pt1Y, 5);
            circleStuff.FillCircle(g, brush, pt1X, pt1Y, 5);

            circleStuff.DrawCircle(g, pen, pt2X, pt2Y, 5);
            circleStuff.FillCircle(g, brush, pt2X, pt2Y, 5);
            
            int tPointX = Convert.ToInt32(((1.0 - t) * pt0X) + (t * pt1X));
            int tPointY = Convert.ToInt32(((1.0 - t) * pt0Y) + (t * pt1Y));

            float i = 0;
            while (i < 1.0f)
            {
               

                t = i;

                int l0PointX = Convert.ToInt32(((1.0 - t) * pt0X) + (t * pt1X));
                int l0PointY = Convert.ToInt32(((1.0 - t) * pt0Y) + (t * pt1Y));

                int l1PointX = Convert.ToInt32(((1.0 - t) * pt1X) + (t * pt2X));
                int l1PointY = Convert.ToInt32(((1.0 - t) * pt1Y) + (t * pt2Y));

                int q0PointX = Convert.ToInt32(((1.0 - t) * l0PointX) + (t * l1PointX));
                int q0PointY = Convert.ToInt32(((1.0 - t) * l0PointY) + (t * l1PointY));


                circleStuff.DrawCircle(g, linePen, q0PointX, q0PointY, 1);
                circleStuff.FillCircle(g, lineBrush, q0PointX, q0PointY, 1);

                /*
                Point point1 = new Point(previousPoint.X, previousPoint.Y);
                Point point2 = new Point(q0PointX, q0PointY);
                */
                //  g.DrawLine(linePen, point1, point2);
                // previousPoint = point2;
                i = i + 0.001f;
            }
            /*
            circleStuff.DrawCircle(g, pen, tPointX, tPointY, 5);
            circleStuff.FillCircle(g, brush, tPointX, tPointY, 5);
            */

        }
    }
    public static class circleStuff
    {
        public static void DrawCircle(this Graphics g, Pen pen,
                                      float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public static void FillCircle(this Graphics g, Brush brush,
                                      float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }
    }
}
