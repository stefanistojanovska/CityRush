using Microsoft.Win32;
using System;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityRush2._0
{
    public partial class CityRush : Form
    {

        Boolean gameStarted;
        CarDrawing drCar1;
        CarDrawing drCar2;
        CarDrawing drCar3;
  
        int speed = 3;
        int level = 1;
        int minutes = 2;
        int seconds = 30;
        static int score;
        public CityRush()
        {
            Image image1 = Image.FromFile("C:\\Users\\Stefani Stojanovska\\source\\repos\\CityRush2.0\\CityRush2.0\\cars\\yellow-resized-removebg-preview.png");
            Image image2 = Image.FromFile("C:\\Users\\Stefani Stojanovska\\source\\repos\\CityRush2.0\\CityRush2.0\\cars\\green-resized-removebg-preview.png");
            Image image3 = Image.FromFile("C:\\Users\\Stefani Stojanovska\\source\\repos\\CityRush2.0\\CityRush2.0\\cars\\blue-resized-removebg-preview.png");

         
            drCar1= new CarDrawing(image1, 217, 26);
            drCar2 = new CarDrawing(image2, 525, 26);
            drCar3 = new CarDrawing(image3, 525, 309);
            score = 0;
            gameStarted = false;

           
           
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, pnlGame, new object[] { true });
            lblScore.Parent = this;
            lblLvl.Parent = this;
            lblTimer.Parent = this;
            lblLbl.Parent = this;
            //lblTimer.Text = "jfvv";
       
        }

        private void button1_Click(object sender, EventArgs e)//btnStart
        {
            gameStarted = true;
            pnlMain.Visible = false;
        
            //pnlContainer.Visible = true;    
            pnlGame.Visible = true;
            countdownTimer.Interval = 1000;
            lblTimer.Visible = true;
            lblLbl.Visible = true;
            timer1.Enabled = true;
            countdownTimer.Enabled = true;
      
            
            
        }
      
       


        private void button2_Click(object sender, EventArgs e)//btnExit
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

     

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
          
            drCar1.drawCar(graphics);
            drCar2.drawCar(graphics);
            drCar3.drawCar(graphics);
            //drMain.drawCar(graphics);

            Point[] points = new Point[4];
            points[0] = new Point(0, 0);
            points[1] = new Point(120, 0);
            points[2] = new Point(35, 590);
            points[3] = new Point(0, 590);
            Brush brush = new SolidBrush(Color.Green);
            Pen pen = new Pen(Color.White,5);
            graphics.FillPolygon(brush, points);
            points[0] = new Point(783, 0);
            points[1] = new Point(908, 0);
            points[2] = new Point(920, 590);
            points[3] = new Point(860, 590);
            graphics.FillPolygon(brush, points);
            graphics.DrawLine(pen,120,-1,38,591 );
            graphics.DrawLine(pen, 783, -1, 859, 591);
            brush.Dispose();
            pen.Dispose();
          
         
        }

        private void pnlGame_MouseClick(object sender, MouseEventArgs e)
        {
            label4.Text = "X:" + e.X + "         Y:" + e.Y;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (score > (level)*12000) level++;
           
            lblScore.Text = "Score: " +score;
            lblLvl.Text = "Level " + level;
            moveCar(speed);
            moveLine(speed);
            score += speed;
            Invalidate(true);
            
           
        }
        void moveLine(int speed)
        {
            //Lane lines
            if (pictureBox2.Top >= 590)
                pictureBox2.Top = -80;
            
            else
                 pictureBox2.Top += speed;
            if (pictureBox3.Top >= 590)
                pictureBox3.Top = -80;
            else
                pictureBox3.Top += speed;
            if (pictureBox4.Top >= 590)
                pictureBox4.Top = -80;
            else
                pictureBox4.Top += speed;
            if (pictureBox5.Top >= 590)
                pictureBox5.Top = -80;

            else
                pictureBox5.Top += speed;

            if (pictureBox7.Top >= 590)
                pictureBox7.Top = -80;

            else
                pictureBox7.Top += speed;

           

        }

        Random r = new Random();
        int x, y;
        void moveCar(int speed)
        {
            //YELLOW CAR
          
            if (drCar1.getTop() >= 590)
            {
                y = -1;
                int tmp = r.Next(0, 1000);
                if (tmp <500)//left
                {
                    x = 217;
                }
                else x = 525;

                //OVERLAPPING CARS
                //NEMA OVERLAPPING PORADI RASPOREDOT!!
               /* if (drCar3.getTop() < 10 || drCar2.getTop() < 10)
                {
                    y = 300;
                    label4.Text = "300";
                }*/

                   
               
                drCar1.setLocation(x, y);

            }
            else
                drCar1.moveDown(speed);

            //GREEN CAR

            if (drCar2.getTop() >= 590)
            {
                y = -1;
                int tmp = r.Next(0, 1000);
                if (tmp < 500)//left
                {
                    x = 217;
                }
                else x = 525;
            
                drCar2.setLocation(x, y);

            }
            else
               
                drCar2.moveDown(speed);



            //BLUE CAR
            if (drCar3.getTop() >= 590)
            {
                y = -1;
                int tmp = r.Next(0, 1000);
                if (tmp < 500)//left
                {
                    x = 217;
                }
                else x = 525;
              
                drCar3.setLocation(x, y);

            }
            else
              
                drCar3.moveDown(speed);



        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {

            //COUTNDOWN IMPLEMENTATION
            if (minutes == 0 && seconds < 11)
                lblTimer.ForeColor = Color.Red;

            if (seconds == 1)
            {
                if (minutes > 0)
                {
                    minutes--;
                    seconds = 60;
                }
                else
                {
                    
                    lblTimer.Text = "0:00";
                    lblTimesUp.Visible = true;
                    countdownTimer.Stop();
                    timer1.Stop();
                }
                    
            }
            else
                seconds--;

            string tmp;

            if (seconds == 60)
                tmp = "00";
            else tmp = seconds.ToString("00");

            if(countdownTimer.Enabled)
                 lblTimer.Text = minutes + ":" + tmp;
        }

        private async void CityRush_KeyDown(object sender, KeyEventArgs e)
        {
            if(gameStarted)

            {
                
                if(e.KeyCode==Keys.Left && mainCar.Left==522)
                {
                    mainCar.Left -= 320;
                  
                    
                    
                }
                if (e.KeyCode == Keys.Right && mainCar.Left == 202)
                {
                    mainCar.Left += 320;
                }
                if (e.KeyCode == Keys.Up && speed<20)
                {
                    speed++;
                }
                if (e.KeyCode == Keys.Down && speed>2)
                {
                    speed--;
                }
                if (e.KeyCode == Keys.Space && mainCar.Top==477)
                {
                   
                    mainCar.Top -=  180;
                    await Task.Delay(600);
                    mainCar.Top+= 180;
                }
             
              
            }
        }
    }
}
