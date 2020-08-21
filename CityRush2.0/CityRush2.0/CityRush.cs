
using System;

using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace CityRush2._0
{
    public partial class CityRush : Form
    {

        Boolean gameStarted;
        CarDrawing drCar1;
        CarDrawing drCar2;
        CarDrawing drCar3;
        Boolean gamePaused;
        Boolean gameOver;
        Boolean jumped = false;
       

        int speed;
        int level;
        int minutes;
        int seconds;
        static int score;
        public CityRush()
        {


            Image image1 = Resources.Yellow;
            Image image2 = Resources.Green;
            Image image3 = Resources.Blue;

            drCar1 = new CarDrawing(image1, 217, 26);
            drCar2 = new CarDrawing(image2, 525, 26);
            drCar3 = new CarDrawing(image3, 525, 309);

            gameStarted = false;
            gamePaused = false;
            gameOver = false;

            score = 0;
            speed = 8;
            level = 1;
            minutes = 2;
            seconds = 30;

            InitializeComponent();

            lblStatus.Visible = false;
            newGame.Visible = false;



            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, pnlGame, new object[] { true });
            lblScore.Parent = this;
            lblLvl.Parent = this;
            lblTimer.Parent = this;
            lblLbl.Parent = this;
            mainCar.Image = Resources.Main;
            newGame.Visible = false;
            
       
        }

        private void button1_Click(object sender, EventArgs e)//btnStart
        {
            startGame();
                    
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

  

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (score > (level)*6000) level++;
           
            lblScore.Text = "Score: " +score;
            lblLvl.Text = "Level " + level;
            moveCar(speed);
            moveLine(speed);
            score += speed;
            if (!jumped && (carIntersects(drCar1) || carIntersects(drCar2) || carIntersects(drCar3)))
            {
                gameOver = true;
                lblStatus.Text = "GAME OVER";
                timer1.Enabled = false;
                countdownTimer.Enabled = false;
            }
            if (gameOver)
            {
                newGame.Visible = true;
                lblStatus.Visible = true;
                crush();
               
            }
               
            //
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
        
                    lblStatus.Text = "Time's up!";
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

                if(e.KeyCode==Keys.Escape )
                {
                    if(!gameOver)
                    {
                        if(!gamePaused)
                        {
                            timer1.Stop();
                            countdownTimer.Stop();
                            gamePaused = true; 
                            lblStatus.Visible = true;
                            lblStatus.Text = "    PAUSED";
                            //label4.Text = "pause!!!!";
                        }
                        else
                        {
                            timer1.Start();
                            countdownTimer.Start();
                            gamePaused = false;
                            lblStatus.Text = "";
                            //label4.Text = "unpause";
                        }
                    }
                    else
                    {
                        CityRush newForm = new CityRush();
                        newForm.Visible = true;
                        this.Dispose(false);
                    }
                    
                   
                }
           
                if(e.KeyCode==Keys.Left && mainCar.Left==522 && !gamePaused && !gameOver)
                {
                    mainCar.Left -= 320;
                  
                    
                    
                }
                if (e.KeyCode == Keys.Right && mainCar.Left == 202 && !gamePaused && !gameOver)
                {
                    mainCar.Left += 320;
                }
                if (e.KeyCode == Keys.Up && speed<25)
                {
                    speed++;
                
                }
                if (e.KeyCode == Keys.Down && speed>8)
                {
                    speed--;
                }
                if (e.KeyCode == Keys.Space && mainCar.Top== 477 )
                {
                    //space unpause disabled
                    if(gamePaused || gameOver)
                        e.SuppressKeyPress = true;
                    else
                    {
                       
                        jumped = true;
                       
                        for (int i = 0; i < 50; i++)
                        {
                           await Task.Delay(8000/(speed*100));//ne e najoptimalna formula
                            mainCar.Top -=1;
                        }
                            
                        for (int i = 0; i < 50; i++)
                        {
                            await Task.Delay(8000/(speed*100));
                            mainCar.Top += 1;
                        }
                            
                        jumped = false;
                    }
                  
                }
               
             
              
            }
        }

        private Boolean carIntersects(CarDrawing car)
        {
            if ((mainCar.Bottom >= car.getTop() && mainCar.Bottom <= car.getTop() + 20))
                return false;
            
          
            if ((mainCar.Top < car.getBottom() - 45)  && sameLane(car))
                return true;
               
            return false ;
        }

      

        private void newGame_Click(object sender, EventArgs e)
        {
            CityRush newForm = new CityRush();
            newForm.Visible = true;
            this.Dispose(false);
            newForm.startGame();

        }

        private Boolean sameLane(CarDrawing car)
        {
            if (mainCar.Left < 450 && car.getLane().Equals("Left"))
                return true;
            if (mainCar.Left > 450 && car.getLane().Equals("Right"))
                return true;
            return false;

        }

        private void startGame()
        {
            gameStarted = true;
            pnlMain.Visible = false;
            pnlGame.Visible = true;
            countdownTimer.Interval = 1000;
            lblTimer.Visible = true;
            lblLbl.Visible = true;
            timer1.Enabled = true;
            countdownTimer.Enabled = true;
        }

        private void crush()
        {
            System.IO.Stream str = Properties.Resources.hit;
            System.Media.SoundPlayer player= new System.Media.SoundPlayer(str);
            player.Play();
        }
    }
}
