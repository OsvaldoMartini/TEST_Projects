using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawStars
{

    
    public partial class Form1 : Form
    {
        private Point basePoit = new Point();
        private Label lblCol = new Label();

        public Form1()
        {
            InitializeComponent();
            INIT();
        }

        public void INIT()
        {
            //Capture Star
            startRed.MouseDown += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    basePoit = Control.MousePosition;
                }
            };

            startRed.MouseMove += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //Temp Point
                    Point temp = Control.MousePosition;
                    Point reserv = new Point(basePoit.X - temp.X, basePoit.Y - temp.Y);

                    startRed.Location = new Point(startRed.Location.X - reserv.X, startRed.Location.Y - reserv.Y);
                    basePoit = temp;
                }

                if (startRed.Bounds.IntersectsWith(startBlue.Bounds))
                {
                    //They have collided
                    lblCol.Text = "Collision with Blue";
                    lblCol.BackColor = Color.Red;
                }
                else
                {
                    lblCol.Text = "No Collision";
                    lblCol.BackColor = Color.Blue;

                }
            };

            startBlue.MouseDown += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    basePoit = Control.MousePosition;
                }
            };

            startBlue.MouseMove += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //Temp Point
                    Point temp = Control.MousePosition;
                    Point reserv = new Point(basePoit.X - temp.X, basePoit.Y - temp.Y);

                    startBlue.Location = new Point(startBlue.Location.X - reserv.X, startBlue.Location.Y - reserv.Y);
                    basePoit = temp;
                }

                if (startBlue.Bounds.IntersectsWith(startRed.Bounds))
                {
                    //They have collided
                    lblCol.Text = "Collision with Red";
                    lblCol.BackColor = Color.Red;
                }
                else
                {
                    lblCol.Text = "No Collision";
                    lblCol.BackColor = Color.Blue;

                }
            };

       
        }

        private PictureBox pictureBox1 = new PictureBox();

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BackColor = Color.White;
            // Connect the Paint event of the PictureBox to the event handler method.
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            //pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseClick);
            //this.panel1.MouseHover += new System.EventHandler(this.PictureBox1_MouseHover);

            // Add the PictureBox control to the Form.
            this.Controls.Add(pictureBox1);
        }

    


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics l = e.Graphics;
            //Pen p = new Pen(Color.BlueViolet, 10);
            //Point[] a = { new Point(100, 100), new Point(200, 100), new Point(400, 200) };
            //l.DrawPolygon(p, a);
            //l.Dispose();
            Pen penColor = new Pen(Color.BlueViolet, 10);

            Graphics g = e.Graphics;
            Point[] star_1 = new Point[8];
            star_1[0] = new Point(0, 25);
            star_1[1] = new Point(20, 20);
            star_1[2] = new Point(25, 0);
            star_1[3] = new Point(30, 20);
            star_1[4] = new Point(50, 25);
            star_1[5] = new Point(30, 30);
            star_1[6] = new Point(25, 50);
            star_1[7] = new Point(20, 30);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddPolygon(star_1);
            System.Drawing.Region r = new System.Drawing.Region(gp);
            startBlue.Region = r;
            startRed.Region = r;
            // Draw a string on the PictureBox.
            //g.DrawString("This is a diagonal line drawn on the control",
            //    new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(30, 30));
            // Draw a line in the PictureBox.
            //g.DrawLine(System.Drawing.Pens.Red, pictureBox1.Left, pictureBox1.Top,
            //    pictureBox1.Right, pictureBox1.Bottom);

            //Point[] a = { new Point(100, 100), new Point(200, 100), new Point(400, 200) };
            //g.DrawPolygon(penColor, StarPoints(5, this.ClientRectangle));
           // g.DrawPolygon(penColor, star_1);

        }

        // Return PointFs to define a star.
        private PointF[] StarPoints(int num_points, Rectangle bounds)
        {
            // Make room for the points.
            PointF[] pts = new PointF[num_points];

            double rx = bounds.Width / 2;
            double ry = bounds.Height / 2;
            double cx = bounds.X + rx;
            double cy = bounds.Y + ry;

            // Start at the top.
            double theta = -Math.PI / 2;
            double dtheta = 4 * Math.PI / num_points;
            for (int i = 0; i < num_points; i++)
            {
                pts[i] = new PointF(
                    (float)(cx + rx * Math.Cos(theta)),
                    (float)(cy + ry * Math.Sin(theta)));
                theta += dtheta;
            }

            return pts;
        }

    }
}
