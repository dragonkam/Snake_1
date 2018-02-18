using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    class RectObstacles:Obstacle,ILocalizable
    {

        public RectObstacles(int x, int y, Size size) : base(x,y)
        {
            this.location = new Point(x, y);
            bounds = new Rectangle(location, size);
        }
        public RectObstacles(Point location, Size size) : base(location)
        {
            this.location = location;
            bounds = new Rectangle(location, size);
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Gray, bounds);
            g.DrawRectangle(new Pen(Brushes.Green, 2), bounds);
        }

    }
}
