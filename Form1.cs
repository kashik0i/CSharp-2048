using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{

    public partial class Form1 : Form
    {
        int steps = 0;
        Graphics window;
        Bitmap off;
        /*
         * grid is 4*4
         [....]
         [....]
         [....]    
         [....]    
             */
        Grid grid = new Grid();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            KeyDown += Form1_KeyDown;
            Paint += Form1_Paint;
            off = new Bitmap(Width, Height);
            window = CreateGraphics();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(window);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:

                    grid.MoveLeft(ref steps);
                    Text = "" + steps;
                    DrawDubb(window);
                    break;
                case Keys.Right:
                    grid.MoveRight(ref steps);
                    Text = "" + steps;
                    DrawDubb(window);
                    break;
                case Keys.Up:
                    grid.MoveUp(ref steps);
                    Text = "" + steps;
                    DrawDubb(window);
                    break;
                case Keys.Down:
                    grid.MoveDown(ref steps);
                    Text = "" + steps;
                    DrawDubb(window);
                    break;
            }
        }
        void DrawDubb(Graphics g)
        {

            DrawScene(Graphics.FromImage(off));
            g.DrawImage(off, 0, 0);
        }
        SolidBrush BeigeBrush = new SolidBrush(Color.Beige);
        SolidBrush BlackBrush = new SolidBrush(Color.Black);
        Pen BlackThickPen = new Pen(Color.Black, 15);
        Font Arial = new Font(new FontFamily("Arial"), 24);
        List<SolidBrush> Brushes = new List<SolidBrush> {
            new SolidBrush(Color.Beige), new SolidBrush(Color.Red), new SolidBrush(Color.Green), new SolidBrush(Color.DarkBlue),
            new SolidBrush(Color.SaddleBrown),new SolidBrush(Color.Silver),new SolidBrush(Color.Gold),new SolidBrush(Color.Indigo)};
        void DrawScene(Graphics g)
        {
            int w = ClientSize.Width / 10;
            int h = ClientSize.Height / 10;
            g.Clear(Color.White);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var sq = grid.squire[i][j];
                    var x = w * j;
                    var y = h * i;
                    g.FillRectangle(Brushes[sq.value%8], x, y, w, h);
                    g.DrawRectangle(BlackThickPen, x, y, w, h);
                    g.DrawString(sq.value.ToString(), Arial, BlackBrush, x + w / 2 - 15, y + h / 2 - 15);
                }
            }
        }
    }
}
