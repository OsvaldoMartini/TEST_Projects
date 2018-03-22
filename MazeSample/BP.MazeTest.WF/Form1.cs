using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BP.MazeTest.WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void doLayout()
        {
            //panel2.Top = 100;
            //panel2.Left = 0;
            //panel2.Height = this.ClientRectangle.Height - panel2.Top;
            //panel2.Width = this.ClientRectangle.Width;
            //panel2.BorderStyle = BorderStyle.FixedSingle;
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            Maze maze = new Maze(Convert.ToInt32(nudRows.Value), Convert.ToInt32(nudCols.Value), Convert.ToInt32(nudWidth.Value), Convert.ToInt32(nudHeight.Value)); 
            maze.MazeComplete += (Image m) =>{ 
                panel1.BackgroundImage = m; 
                panel1.BackgroundImageLayout = ImageLayout.None; 
                panel1.Width = m.Width; 
                panel1.Height = m.Height; 
                //maze.PrintMaze() 
            }; 
            maze.Generate(); 
       
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            doLayout(); 
        }
    }
}
