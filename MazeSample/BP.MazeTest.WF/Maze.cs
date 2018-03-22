using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BP.MazeTest.WF
{
    public class Maze : Control
    {
        int Rows;
        int Columns;
        int cellWidth;
        int cellHeight;
        Dictionary<string, Cell> cells = new Dictionary<string, Cell>();
        Stack<Cell> stack = new Stack<Cell>();

        public Image MazeImage;
        public event MazeCompleteEventHandler MazeComplete;
        public delegate void MazeCompleteEventHandler(Image Maze);
        private event CallCompleteEventHandler CallComplete;
        private delegate void CallCompleteEventHandler(Image Maze);
        public new Rectangle Bounds
        {
            get
            {
                Rectangle rect = new Rectangle(0, 0, Width, Height);
                return rect;
            }
        }
        private System.Drawing.Printing.PrintDocument withEventsField_printDoc = new System.Drawing.Printing.PrintDocument();
        public System.Drawing.Printing.PrintDocument printDoc
        {
            get { return withEventsField_printDoc; }
            set
            {
                if (withEventsField_printDoc != null)
                {
                    withEventsField_printDoc.PrintPage -= PrintImage;
                }
                withEventsField_printDoc = value;
                if (withEventsField_printDoc != null)
                {
                    withEventsField_printDoc.PrintPage += PrintImage;
                }
            }
        }
        private void PrintImage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            List<string> nonprinters = new string[] { "Send To OneNote 2013", "PDFCreator", "PDF Architect 4", "Microsoft XPS Document Writer", "Microsoft Print to PDF", "Fax", "-" }.ToList();
            string printerName = "none";
            foreach (string a in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (nonprinters.IndexOf(a) > -1)
                    continue;
                printerName = a;
            }
            if (printerName == "none")
                return;
            printDoc.PrinterSettings.PrinterName = printerName;
            int imageLeft = Convert.ToInt32(e.PageBounds.Width / 2) - Convert.ToInt32(MazeImage.Width / 2);
            int imageTop = Convert.ToInt32(e.PageBounds.Height / 2) - Convert.ToInt32(MazeImage.Height / 2);
            e.Graphics.DrawImage(MazeImage, imageLeft, imageTop);
        }
        public void PrintMaze()
        {
            printDoc.Print();
        }
        public void Generate()
        {
            int c = 0;
            int r = 0;
            for (int y = 0; y <= Height; y += cellHeight)
            {
                for (int x = 0; x <= Width; x += cellWidth)
                {
                    Cell cell = new Cell(new Point(x, y), new Size(cellWidth, cellHeight), ref cells, r, c, (Rows - 1), (Columns - 1));
                    c += 1;
                }
                c = 0;
                r += 1;
            }
            System.Threading.Thread thread = new System.Threading.Thread(Dig);
            thread.Start();
        }
        private void Dig()
        {
            int r = 0;
            int c = 0;
            string key = "c" + 5 + "r" + 5;
            Cell startCell = cells[key];
            stack.Clear();
            startCell.Visited = true;
            while ((startCell != null))
            {
                startCell = startCell.Dig(ref stack);
                if (startCell != null)
                {
                    startCell.Visited = true;
                    startCell.Pen = Pens.Black;
                }
            }
            stack.Clear();
            Bitmap Maze = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(Maze))
            {
                g.Clear(Color.White);
                if (cells.Count > 0)
                {
                    for (r = 0; r <= this.Rows - 1; r++)
                    {
                        for (c = 0; c <= this.Columns - 1; c++)
                        {
                            Cell cell = cells["c" + c + "r" + r];
                            cell.draw(g);
                        }
                    }
                }
            }
            this.MazeImage = Maze;

            if (CallComplete != null)
            {
                CallComplete(Maze);
            }
        }
        public delegate void dComplete(Image maze);
        private void Call_Complete(Image maze)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new dComplete(Call_Complete), maze);
            }
            else
            {
                if (MazeComplete != null)
                {
                    MazeComplete(maze);
                }
            }
        }
        public Maze(int rows, int columns, int cellWidth, int cellHeight)
        {
            CallComplete += Call_Complete;
            this.Rows = rows;
            this.Columns = columns;
            this.cellWidth = cellWidth;
            this.cellHeight = cellHeight;
            this.Width = (this.Columns * this.cellWidth) + 1;
            this.Height = (this.Rows * this.cellHeight) + 1;
            this.CreateHandle();
        }
    }
}
