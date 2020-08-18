using System;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityRush2._0
{
    public partial class CityRush : Form
    {

        private Boolean gameStarted;
        CarDrawing drCar1;
        CarDrawing drCar2;
        CarDrawing drCar3;
        int speed = 3;
        public CityRush()
        {
            Image main = Image.FromFile("C:\\Users\\Stefani Stojanovska\\source\\repos\\CityRush2.0\\CityRush2.0\\cars\\main-resized-removebg-preview.png");
            Image image1 = Image.FromFile("C:\\Users\\Stefani Stojanovska\\source\\repos\\CityRush2.0\\CityRush2.0\\cars\\yellow-resized-removebg-preview.png");
            Image image2 = Image.FromFile("C:\\Users\\Stefani Stojanovska\\source\\repos\\CityRush2.0\\CityRush2.0\\cars\\green-resized-removebg-preview.png");
            Image image3 = Image.FromFile("C:\\Users\\Stefani Stojanovska\\source\\repos\\CityRush2.0\\CityRush2.0\\cars\\blue-resized-removebg-preview.png");

            //drMain = new CarDrawing(main,159,320);
            drCar1= new CarDrawing(image1, 217, 26);
            drCar2 = new CarDrawing(image2, 495, 26);
            drCar3 = new CarDrawing(image3, 495, 309);

            gameStarted = false;
          
          
           
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
     BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
     null, pnlGame, new object[] { true });
            // mainCar.Visible = false;
         
            
       
        }

        private void button1_Click(object sender, EventArgs e)//btnStart
        {
            gameStarted = true;
            pnlMain.Visible = false;
            pnlGame.Visible = true;
            timer1.Enabled = true;
            
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
            points[2] = new Point(35, 490);
            points[3] = new Point(0, 490);
            Brush brush = new SolidBrush(Color.Green);
            Pen pen = new Pen(Color.White,5);
            graphics.FillPolygon(brush, points);
            points[0] = new Point(783, 0);
            points[1] = new Point(908, 0);
            points[2] = new Point(910, 490);
            points[3] = new Point(862, 490);
            graphics.FillPolygon(brush, points);
            graphics.DrawLine(pen,120,-1,38,491 );
            graphics.DrawLine(pen, 783, -1, 859, 491);
            brush.Dispose();
            pen.Dispose();
          
         
        }

        private void pnlGame_MouseClick(object sender, MouseEventArgs e)
        {
            label4.Text = "X:" + e.X + "         Y:" + e.Y;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveLine(speed);
            
            moveCar(speed);
           Invalidate(true);
            
           
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
                else x = 495;
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
                else x = 495;
            
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
                else x = 495;
              
                drCar3.setLocation(x, y);

            }
            else
              
                drCar3.moveDown(speed);






        }







        private async void CityRush_KeyDown(object sender, KeyEventArgs e)
        {
            if(gameStarted)

            {
                
                if(e.KeyCode==Keys.Left && mainCar.Left==516)
                {
                    mainCar.Left -= 320;
                  
                    
                    
                }
                if (e.KeyCode == Keys.Right && mainCar.Left == 196)
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
                if (e.KeyCode == Keys.Space && mainCar.Top==359)
                {
                   
                    mainCar.Top -=  200;
                    await Task.Delay(300);
                    mainCar.Top+= 200;
                }
             
              
            }
        }
    }
}
