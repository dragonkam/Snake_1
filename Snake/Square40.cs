using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Square40 : Obstacle, ILocalizable
    {

        public Square40(int x,int y,int size) : base(x,y)
        {
            this.location = new Point(x,y);
            bounds = new Rectangle(location, new Size(size, size));
        }
        public Square40(Point location,int size) : base(location)
        {
            this.location = location;
            bounds = new Rectangle(location, new Size(size, size));
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Gray, bounds);
            g.DrawRectangle(new Pen(Brushes.DarkGray, 2), bounds);
        }

      
    }
}
