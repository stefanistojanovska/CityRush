using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityRush2._0
{
   
    class CarDrawing
    {
        Image image;
        Rectangle rect;
      
       
        public CarDrawing(Image image,int x, int y)
        {
            this.image = image;
            rect = new Rectangle(x, y, 180, 110);
            
        }

        public int getBottom()
        {
            return rect.Bottom;
        }

        public String getLane()
        {
            if (rect.X < 450) return "Left";
            return "Right";
        }
        public int getTop()
        {
            return rect.Top;
        }
        
        public void drawCar(Graphics g)
        {
          
            g.DrawImage(image,rect);
           
        }
        public void moveDown(int speed)
        {
            rect.Y += speed;
            //if (this.rect.X < 450)
             //   rect.X -= 1;
          //  if(rect.X>450)
               // rect.X += 1;
        

        }
        public Rectangle getRect()
        {
            return rect;
        }
        public void setLocation(int x,int y)
        {
            this.rect.X = x;
            this.rect.Y = y;
        }
}
    }

    
