using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    public interface IFruits
    {
        Point Location { get;  }
        int Points { get; }
        bool Timed { get; }
        Rectangle Bounds { get; }

        bool Refresh();
        void SetLocation(Point location);
        void Drawing(Graphics g);
    }
}
