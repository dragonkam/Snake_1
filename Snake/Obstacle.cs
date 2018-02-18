using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    abstract class Obstacle: ILocalizable
    {
        public Point Location => location;
        public Rectangle Bounds => bounds;

        protected Rectangle bounds;
        protected Point location;

        
        public Obstacle(Point location)
        {
            this.location = location;
            bounds = new Rectangle(location, new Size(40, 40));
        }
        public Obstacle(int x,int y)
        {
            this.location = new Point(x,y);
            bounds = new Rectangle(location, new Size(40, 40));
        }



        public abstract void Draw(Graphics g);
        




    }
}
