using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;


namespace Maze
{
    /// <summary>
    /// Summary Maze Generate and Solver
    /// Version 1.0
    /// Developed by: Osvaldo Martini
    /// Email: osvaldo.martini@gmail.com
    /// </summary>
    public class frmMain : System.Windows.Forms.Form
    {
        MazeSolver.MazeSolver m_Maze;
        int[,] _mIMaze;
        readonly int m_iSize = 20;
        int _mIRowDimensions = 16;
        int _mIColDimensions = 20;
        int _iStartPointX, _iStartPointY, _iExitPointX, _iExitPointY;


        private System.Windows.Forms.PictureBox pictureMaze;
        private System.Windows.Forms.Label lblCoordinates;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.RadioButton bDraw;
        private System.Windows.Forms.RadioButton bFind;
        private System.Windows.Forms.Label lblTextGeneral;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.CheckBox chkDiagonal;
        private MenuStrip menuStrip1;
        private NumericUpDown NumRows;
        private NumericUpDown NumCols;
        private Label label1;
        private Label label2;
        private RadioButton SetStartPoint;
        private Label lblBuilded;
        private RadioButton SetExitPoint;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmMain()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureMaze = new System.Windows.Forms.PictureBox();
            this.lblCoordinates = new System.Windows.Forms.Label();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.SetExitPoint = new System.Windows.Forms.RadioButton();
            this.SetStartPoint = new System.Windows.Forms.RadioButton();
            this.bFind = new System.Windows.Forms.RadioButton();
            this.bDraw = new System.Windows.Forms.RadioButton();
            this.lblTextGeneral = new System.Windows.Forms.Label();
            this.cmdReset = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.chkDiagonal = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.NumRows = new System.Windows.Forms.NumericUpDown();
            this.NumCols = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBuilded = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.pictureMaze)).BeginInit();
            this.grpAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.NumRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.NumCols)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureMaze
            // 
            this.pictureMaze.BackColor = System.Drawing.Color.White;
            this.pictureMaze.Location = new System.Drawing.Point(29, 18);
            this.pictureMaze.Name = "pictureMaze";
            this.pictureMaze.Size = new System.Drawing.Size(483, 399);
            this.pictureMaze.TabIndex = 0;
            this.pictureMaze.TabStop = false;
            this.pictureMaze.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureMaze.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureMaze.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // lblCoordinates
            // 
            this.lblCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblCoordinates.Location = new System.Drawing.Point(562, 246);
            this.lblCoordinates.Name = "lblCoordinates";
            this.lblCoordinates.Size = new System.Drawing.Size(154, 18);
            this.lblCoordinates.TabIndex = 3;
            this.lblCoordinates.Text = "Coordinates";
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.SetExitPoint);
            this.grpAction.Controls.Add(this.SetStartPoint);
            this.grpAction.Controls.Add(this.bFind);
            this.grpAction.Controls.Add(this.bDraw);
            this.grpAction.Location = new System.Drawing.Point(566, 18);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(144, 173);
            this.grpAction.TabIndex = 4;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "Action";
            // 
            // SetExitPoint
            // 
            this.SetExitPoint.AutoSize = true;
            this.SetExitPoint.Location = new System.Drawing.Point(10, 133);
            this.SetExitPoint.Name = "SetExitPoint";
            this.SetExitPoint.Size = new System.Drawing.Size(112, 21);
            this.SetExitPoint.TabIndex = 3;
            this.SetExitPoint.TabStop = true;
            this.SetExitPoint.Text = "Set Exit Point";
            this.SetExitPoint.UseVisualStyleBackColor = true;
            this.SetExitPoint.CheckedChanged += new System.EventHandler(this.SetExitPoint_CheckedChanged);
            // 
            // SetStartPoint
            // 
            this.SetStartPoint.AutoSize = true;
            this.SetStartPoint.Location = new System.Drawing.Point(10, 95);
            this.SetStartPoint.Name = "SetStartPoint";
            this.SetStartPoint.Size = new System.Drawing.Size(120, 21);
            this.SetStartPoint.TabIndex = 2;
            this.SetStartPoint.TabStop = true;
            this.SetStartPoint.Text = "Set Start Point";
            this.SetStartPoint.UseVisualStyleBackColor = true;
            this.SetStartPoint.CheckedChanged += new System.EventHandler(this.setBallStart_CheckedChanged);
            // 
            // bFind
            // 
            this.bFind.Location = new System.Drawing.Point(10, 61);
            this.bFind.Name = "bFind";
            this.bFind.Size = new System.Drawing.Size(124, 28);
            this.bFind.TabIndex = 1;
            this.bFind.Text = "Find Path";
            this.bFind.CheckedChanged += new System.EventHandler(this.bFind_CheckedChanged);
            // 
            // bDraw
            // 
            this.bDraw.Checked = true;
            this.bDraw.Location = new System.Drawing.Point(10, 28);
            this.bDraw.Name = "bDraw";
            this.bDraw.Size = new System.Drawing.Size(124, 27);
            this.bDraw.TabIndex = 0;
            this.bDraw.TabStop = true;
            this.bDraw.Text = "Draw Walls";
            this.bDraw.CheckedChanged += new System.EventHandler(this.bDraw_CheckedChanged);
            // 
            // lblTextGeneral
            // 
            this.lblTextGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F,
                System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblTextGeneral.Location = new System.Drawing.Point(562, 228);
            this.lblTextGeneral.Name = "lblTextGeneral";
            this.lblTextGeneral.Size = new System.Drawing.Size(120, 18);
            this.lblTextGeneral.TabIndex = 5;
            this.lblTextGeneral.Text = "Current Path";
            // 
            // cmdReset
            // 
            this.cmdReset.Location = new System.Drawing.Point(542, 267);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(125, 28);
            this.cmdReset.TabIndex = 6;
            this.cmdReset.Text = "&Reset Maze";
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "&About";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(542, 400);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(125, 28);
            this.cmdExit.TabIndex = 8;
            this.cmdExit.Text = "E&xit";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // chkDiagonal
            // 
            this.chkDiagonal.Location = new System.Drawing.Point(566, 197);
            this.chkDiagonal.Name = "chkDiagonal";
            this.chkDiagonal.Size = new System.Drawing.Size(135, 28);
            this.chkDiagonal.TabIndex = 9;
            this.chkDiagonal.Text = "Allow Diagonals";
            this.chkDiagonal.CheckedChanged += new System.EventHandler(this.chkDiagonal_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(716, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // NumRows
            // 
            this.NumRows.Location = new System.Drawing.Point(585, 352);
            this.NumRows.Maximum = new decimal(new int[]
            {
                20,
                0,
                0,
                0
            });
            this.NumRows.Minimum = new decimal(new int[]
            {
                5,
                0,
                0,
                0
            });
            this.NumRows.Name = "NumRows";
            this.NumRows.Size = new System.Drawing.Size(82, 22);
            this.NumRows.TabIndex = 11;
            this.NumRows.Value = new decimal(new int[]
            {
                15,
                0,
                0,
                0
            });
            // 
            // NumCols
            // 
            this.NumCols.Location = new System.Drawing.Point(585, 372);
            this.NumCols.Maximum = new decimal(new int[]
            {
                20,
                0,
                0,
                0
            });
            this.NumCols.Minimum = new decimal(new int[]
            {
                5,
                0,
                0,
                0
            });
            this.NumCols.Name = "NumCols";
            this.NumCols.Size = new System.Drawing.Size(82, 22);
            this.NumCols.TabIndex = 12;
            this.NumCols.Value = new decimal(new int[]
            {
                15,
                0,
                0,
                0
            });
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(542, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Rows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(545, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Cols";
            // 
            // lblBuilded
            // 
            this.lblBuilded.AutoSize = true;
            this.lblBuilded.Location = new System.Drawing.Point(545, 298);
            this.lblBuilded.Name = "lblBuilded";
            this.lblBuilded.Size = new System.Drawing.Size(55, 17);
            this.lblBuilded.TabIndex = 16;
            this.lblBuilded.Text = "Builded";
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(716, 446);
            this.Controls.Add(this.lblBuilded);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumCols);
            this.Controls.Add(this.NumRows);
            this.Controls.Add(this.chkDiagonal);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.lblTextGeneral);
            this.Controls.Add(this.grpAction);
            this.Controls.Add(this.lblCoordinates);
            this.Controls.Add(this.pictureMaze);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Maze Solver by Syed MazeSolver Alam";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize) (this.pictureMaze)).EndInit();
            this.grpAction.ResumeLayout(false);
            this.grpAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.NumRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.NumCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private int iX;
        private int iY;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.Run(new frmMain());
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(
                    "An unhandled exception '" + exp.Message +
                    "' has occurred. \nPlease tell me at sMazeSolveralam@yahoo.com so that I can fix this bug. Thank you",
                    "Error");
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            _mIRowDimensions = (int) NumRows.Value;
            _mIColDimensions = (int) NumCols.Value;
            _iExitPointX = (int) NumRows.Value - 1;
            _iExitPointY = (int) NumCols.Value - 1;
            m_Maze = new MazeSolver.MazeSolver(_mIRowDimensions, _mIColDimensions);
            this.pictureMaze.Size =
                new System.Drawing.Size(_mIColDimensions * m_iSize + 3, _mIRowDimensions * m_iSize + 3);
            _mIMaze = m_Maze.GetMaze;
            this.lblCoordinates.Visible = true;
            this.lblTextGeneral.Visible = false;

            GenerateMaze();
        }

        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _mIRowDimensions = (int) NumRows.Value;
            _mIColDimensions = (int) NumCols.Value;

            Graphics myGraphics = e.Graphics;
            string measureString = "X";
            Font stringFont = new Font("Arial", 16);
            SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));

            for (int i = 0; i < _mIRowDimensions; i++)
            for (int j = 0; j < _mIColDimensions; j++)
            {
                // print grids
                Rectangle rect = new Rectangle(j * m_iSize, i * m_iSize, m_iSize, m_iSize);

                myGraphics.DrawRectangle(new Pen(Color.Black), rect);
                // print walls
                if (_mIMaze[i, j] == 1)
                {
                    myGraphics.FillRectangle(brush, j * m_iSize + 1, i * m_iSize + 1, m_iSize - 1,
                        m_iSize - 1);
                    // Draw string to screen.
                    myGraphics.DrawString(measureString, stringFont, Brushes.Black, rect);

                } //print path

                if (_mIMaze[i, j] == 100)
                    myGraphics.FillRectangle(new SolidBrush(Color.Cyan), j * m_iSize + 1, i * m_iSize + 1, m_iSize - 1,
                        m_iSize - 1);
            }

            //print Start Point
            myGraphics.FillEllipse(new SolidBrush(Color.Red), this._iStartPointX * m_iSize + 5,
                this._iStartPointY * m_iSize + 5, m_iSize - 10, m_iSize - 10);

            //print Exit Point
            myGraphics.FillEllipse(new SolidBrush(Color.DeepSkyBlue), this._iExitPointX * m_iSize + 5,
                this._iExitPointY * m_iSize + 5, m_iSize - 10, m_iSize - 10);

        }

        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _mIRowDimensions = (int) NumRows.Value;
            _mIColDimensions = (int) NumCols.Value;

            iX = e.X / m_iSize;
            iY = e.Y / m_iSize;
            if (iX < _mIColDimensions && iX >= 0 && iY < _mIRowDimensions && iY >= 0)
            {
                if (this.bDraw.Checked == true)
                {
                    _mIMaze = m_Maze.GetMaze;
                    if (_mIMaze[iY, iX] == 0)
                        _mIMaze[iY, iX] = 1;
                    else
                        _mIMaze[iY, iX] = 0;
                    this.Refresh();
                }
                else if (this.bFind.Checked == true)
                {

                    if (_mIMaze[iY, iX] == 100) //if path exists
                    {
                        //move step by step until the required position is achieved
                        while (this._iStartPointX != iX || this._iStartPointY != iY)
                        {
                            _mIMaze[this._iStartPointY, this._iStartPointX] = 0;

                            if (this._iStartPointX - 1 >= 0 && this._iStartPointX - 1 < _mIColDimensions &&
                                _mIMaze[this._iStartPointY, this._iStartPointX - 1] == 100)
                                this._iStartPointX--;
                            else if (this._iStartPointX + 1 >= 0 && this._iStartPointX + 1 < _mIColDimensions &&
                                     _mIMaze[this._iStartPointY, this._iStartPointX + 1] == 100)
                                this._iStartPointX++;
                            else if (this._iStartPointY - 1 >= 0 && this._iStartPointY - 1 < _mIRowDimensions &&
                                     _mIMaze[this._iStartPointY - 1, this._iStartPointX] == 100)
                                this._iStartPointY--;
                            else if (this._iStartPointY + 1 >= 0 && this._iStartPointY + 1 < _mIRowDimensions &&
                                     _mIMaze[this._iStartPointY + 1, this._iStartPointX] == 100)
                                this._iStartPointY++;

                            // move diagonal
                            else if (this._iStartPointY + 1 >= 0 && this._iStartPointY + 1 < _mIRowDimensions &&
                                     this._iStartPointX + 1 >= 0 && this._iStartPointX + 1 < _mIColDimensions &&
                                     _mIMaze[this._iStartPointY + 1, this._iStartPointX + 1] == 100)
                            {
                                this._iStartPointX++;
                                this._iStartPointY++;
                            }
                            else if (this._iStartPointY - 1 >= 0 && this._iStartPointY - 1 < _mIRowDimensions &&
                                     this._iStartPointX + 1 >= 0 && this._iStartPointX + 1 < _mIColDimensions &&
                                     _mIMaze[this._iStartPointY - 1, this._iStartPointX + 1] == 100)
                            {
                                this._iStartPointX++;
                                this._iStartPointY--;
                            }
                            else if (this._iStartPointY + 1 >= 0 && this._iStartPointY + 1 < _mIRowDimensions &&
                                     this._iStartPointX - 1 >= 0 && this._iStartPointX - 1 < _mIColDimensions &&
                                     _mIMaze[this._iStartPointY + 1, this._iStartPointX - 1] == 100)
                            {
                                this._iStartPointX--;
                                this._iStartPointY++;
                            }
                            else if (this._iStartPointY - 1 >= 0 && this._iStartPointY - 1 < _mIRowDimensions &&
                                     this._iStartPointX - 1 >= 0 && this._iStartPointX - 1 < _mIColDimensions &&
                                     _mIMaze[this._iStartPointY - 1, this._iStartPointX - 1] == 100)
                            {
                                this._iStartPointX--;
                                this._iStartPointY--;
                            }

                            this.Refresh();
                        }
                    }
                }
                else if (this.SetStartPoint.Checked == true)
                {
                    this._iStartPointX = iX;
                    this._iStartPointY = iY;
                    _mIMaze[iY, iX] = 0;
                    this.Refresh();
                }
                else if (this.SetExitPoint.Checked == true)
                {
                    this._iExitPointX = iX;
                    this._iExitPointY = iY;
                    _mIMaze[iY, iX] = 0;
                    this.Refresh();

                }
                ReCountWalls();
            }


        }

        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _mIRowDimensions = (int) NumRows.Value;
            _mIColDimensions = (int) NumCols.Value;

            iY = e.Y / m_iSize;
            iX = e.X / m_iSize;
            if (this.bFind.Checked == true)
            {
                if (iX < _mIColDimensions && iX >= 0 && iY < _mIRowDimensions && iY >= 0)
                {
                    _mIMaze = m_Maze.GetMaze;
                    if (this.bDraw.Checked == false)
                    {
                        int[,] iSolvedMaze = m_Maze.FindPath(_iStartPointY, _iStartPointX, iY, iX);
                        if (iSolvedMaze != null)
                        {
                            _mIMaze = iSolvedMaze;
                            this.lblCoordinates.Text =
                                "" + _iStartPointY + "," + _iStartPointX + " to " + (iY + 1) + "," + (iX + 1);
                        }
                        else
                            this.lblCoordinates.Text = "No Way Out Path Found";

                        this.Refresh();
                    }
                }
            }
            else
            {
                this.lblCoordinates.Text = "Coordinates: " + (iY + 1) + "," + (iX + 1);
            }

        }

        private void bDraw_CheckedChanged(object sender, System.EventArgs e)
        {
            _mIMaze = m_Maze.GetMaze;
            this.lblCoordinates.Visible = true;
            this.lblTextGeneral.Visible = false;
            this.Refresh();
        }

        private void bFind_CheckedChanged(object sender, System.EventArgs e)
        {
            this.m_Maze.AllowDiagonals = this.chkDiagonal.Checked;
            this.lblCoordinates.Visible = true;
            this.lblTextGeneral.Visible = true;
            this.lblTextGeneral.Text = "Current Path";
        }

        private void chkDiagonal_CheckedChanged(object sender, System.EventArgs e)
        {
            m_Maze.AllowDiagonals = chkDiagonal.Checked;
            this.lblCoordinates.Visible = true;
            this.lblTextGeneral.Visible = true;
        }

        private void setBallStart_CheckedChanged(object sender, EventArgs e)
        {
            this.m_Maze.AllowDiagonals = this.chkDiagonal.Checked;
            this.lblCoordinates.Visible = true;
            this.lblTextGeneral.Visible = true;
            this.lblTextGeneral.Text = "Set Start Point";
        }

        private void SetExitPoint_CheckedChanged(object sender, EventArgs e)
        {
            this.m_Maze.AllowDiagonals = this.chkDiagonal.Checked;
            this.lblCoordinates.Visible = true;
            this.lblTextGeneral.Visible = true;
            this.lblTextGeneral.Text = "Set Exit Point";

        }


        private void cmdReset_Click(object sender, System.EventArgs e)
        {
            _mIRowDimensions = (int) NumRows.Value;
            _mIColDimensions = (int) NumCols.Value;
            if (_iStartPointX > (int) NumRows.Value - 1 || _iStartPointY > (int) NumCols.Value - 1)
            {
                _iStartPointX = _iStartPointY = 0;
            }

            if (_iExitPointX > (int) NumRows.Value - 1 || _iExitPointY > (int) NumCols.Value - 1)
            {

                _iExitPointX = (int) NumRows.Value - 1;
                _iExitPointY = (int) NumCols.Value - 1;
            }

            m_Maze = new MazeSolver.MazeSolver(_mIRowDimensions, _mIColDimensions);
            m_Maze.AllowDiagonals = this.chkDiagonal.Checked;
            _mIMaze = m_Maze.GetMaze;
            pictureMaze.Width = (_mIColDimensions + 1) * 20;
            pictureMaze.Height = (_mIRowDimensions + 1) * 20;
            this.Refresh();

            GenerateMaze();
        }

        private void GenerateMaze()
        {

            //Criar Property in Class
            var centerOfMaze = CreateCenterOfMaze().ToList();
            int counterList = 0;
            //Starting Point 'S'
            //Exit Point located opossite from Start Point
            //My Creiteria only to be easy to Identity the Exit Point
            //Building Maze
            for (int x = 0; x < NumRows.Value; x++)
            {
                for (int y = 0; y < NumCols.Value; y++)
                {
                    var defStartPoint = ((_iStartPointX != y) || (_iStartPointY != x));
                    var defExitPoint = ((_iExitPointX != y) || (_iExitPointY != x));
                    if ((defStartPoint) && (defExitPoint) &&
                        (y == 0 || x == 0 || x == NumRows.Value - 1 || y == NumCols.Value - 1))
                    {
                        _mIMaze[x, y] = 1;
                    }
                    else if ((defStartPoint) && (defExitPoint))
                    {
                        _mIMaze[x, y] = centerOfMaze[counterList];
                        counterList++;
                    }
                }
            }

            this.Refresh();
            ReCountWalls();

        }

        public void ReCountWalls()
        {
            int countWalls = 0, countSpaces = 0;

            for (int x = 0; x < NumRows.Value; x++)
            {
                for (int y = 0; y < NumCols.Value; y++)
                    if (_mIMaze[x, y] == 1)
                        countWalls++;
                    else
                        countSpaces++;
            }

            lblBuilded.Text = String.Format("Walls :{0} Spaces: {1}", countWalls, countSpaces);

        }


	    private void button1_Click(object sender, System.EventArgs e)
		{
			
			MessageBox.Show(
			  " Maze Generate and Solver" + 
			"\n              by" + 
			"\n Osvaldo Martini" + 
			"\n Email: osvaldo.martini@gmail.com" 
			, "About this program" );
		}

		private void cmdExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	
	    public int[] CreateCenterOfMaze()
	    {
	        int[] possib =
	        {
	            0,
	            1
	        };

	        Random rnd = new Random();
	        int cellsTot = ((int) NumRows.Value * (int) NumCols.Value);
	        int middlePosition = ((int)NumRows.Value * 2) + ((int)NumCols.Value - 1) * 2;
	        cellsTot = cellsTot - middlePosition + 2;
            int[] arryMaz = new int[cellsTot];
            for (int i = 0; i < cellsTot; i++)
	        {
	            arryMaz[i] = possib[rnd.Next(0,2)];
            }

            return arryMaz;
	    }


       


	}



}
