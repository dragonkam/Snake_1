using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SnakeGame
{
    class Strawberry : IFruits,ILocalizable
    {
        public Point Location => location;
        public Rectangle Bounds { get { return bounds; } }
        public int Points => points;

        public bool Timed => timed;

        private bool timed;
        private Point location;
        private Rectangle bounds;
        private Stopwatch countLiveTime;
        private TimeSpan liveTime;

        private  int points = 20;

        

        public Strawberry()
        {
            timed = false;
            this.location = new Point(20,20);
            bounds = new Rectangle(location, new Size(10, 10));
            
        }
        public Strawberry(TimeSpan liveTime,int pointsForEat)
        {
            timed = true;
            this.location = new Point(20, 20);
            bounds = new Rectangle(location, new Size(10, 10));

            points = pointsForEat;
            this.liveTime = liveTime;
            this.countLiveTime = new Stopwatch();
            this.countLiveTime.Start();
        }

        public void SetLocation(Point location)
        {
            this.location = location;
            Rectangle tmp = bounds;
            tmp.Location = location;
            bounds = tmp;
        }

        public bool Refresh()
        {
            if (timed)
            {
                countLiveTime.Stop();
                if (countLiveTime.Elapsed >= liveTime)
                {
                    return false;
                }
                else
                {
                    countLiveTime.Start();
                    return true; }
            }
            else
            return true;
        }

        
        public void Drawing(Graphics g)
        {
            if (!timed)
            {
                g.FillEllipse(Brushes.Red, Bounds);
                g.DrawEllipse(Pens.White, Bounds);
            }
            else
            {
                g.FillEllipse(Brushes.Red, Bounds);
                g.DrawEllipse(new Pen(Brushes.Pink,2), Bounds);
            }
          
        }

       
    }
}
