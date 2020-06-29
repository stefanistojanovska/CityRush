using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityRush2._0
{
    public partial class CityRush : Form
    {
        private Scene scene;
        private Boolean gameStarted;
        public CityRush()
        {
            gameStarted = false;
            scene = new Scene();
            DoubleBuffered = true;
            
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)//btnStart
        {
            gameStarted = true;
            pnlMain.Visible = false;
            pnlGame.Visible = true;
            timer1.Enabled = true;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//btnExit
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            Point[] points = new Point[4];
            points[0] = new Point(0, 0);
            points[1] = new Point(177, 0);
            points[2] = new Point(35, 490);
            points[3] = new Point(0, 490);
            Brush brush = new SolidBrush(Color.Green);
            Pen pen = new Pen(Color.White,5);
            graphics.FillPolygon(brush, points);
            points[0] = new Point(723, 0);
            points[1] = new Point(908, 0);
            points[2] = new Point(910, 490);
            points[3] = new Point(862, 490);
            graphics.FillPolygon(brush, points);
            graphics.DrawLine(pen,181,-1,38,491 );
            graphics.DrawLine(pen, 720, -1, 859, 491);
        }

        private void pnlGame_MouseClick(object sender, MouseEventArgs e)
        {
            label4.Text = "X:" + e.X + "         Y:" + e.Y;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveLine(7);
        }
        void moveLine(int speed)
        {
            if (pictureBox2.Top >= 530)
                pictureBox2.Top = -80;
            else
                 pictureBox2.Top += speed;
            if (pictureBox3.Top >= 530)
                pictureBox3.Top = -80;
            else
                pictureBox3.Top += speed;
            if (pictureBox4.Top >= 530)
                pictureBox4.Top = -80;
            else
                pictureBox4.Top += speed;
            if (pictureBox5.Top >= 530)
                pictureBox5.Top = -80;

            else
                pictureBox5.Top += speed;

            if (pictureBox6.Top >= 530)
                pictureBox6.Top = -80;

            else
                pictureBox6.Top += speed;
        }

        private void CityRush_KeyDown(object sender, KeyEventArgs e)
        {
            if(gameStarted)
            {
                if(e.KeyCode==Keys.Left && mainCar.Left==500 )
                {
                    mainCar.Left -= 400;
                }
                if (e.KeyCode == Keys.Right && mainCar.Left == 100)
                {
                    mainCar.Left += 400;
                }
            }
        }
    }
}
