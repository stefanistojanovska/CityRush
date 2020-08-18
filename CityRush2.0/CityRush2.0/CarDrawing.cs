using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CityRush2._0
{
   
    class CarDrawing
    {
        Image image;
        Rectangle rect;
       
        public CarDrawing(Image image,int x, int y)
        {
            this.image = image;
            rect = new Rectangle(x, y, 180, 120);
            
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

    
