using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Banana:IFruits,ILocalizable
    {
        public Point Location => location;
        public Rectangle Bounds { get { return bounds; } }
        public int Points => points;

        public bool Timed => timed;

        private bool timed;
        private Point location;
        private Rectangle bounds;
        private Stopwatch countLiveTime;
        private long jumpTime;

        private List<IFruits> fruitsList;
        private List<Obstacle> obstacles;
        private Snake snake;
        private Random myRand;
        private Rectangle gameBounds;

        private int points = 20;



        public Banana(Random myRand, List<IFruits> fruitsList,List<Obstacle> obstacles,Snake snake,Rectangle gameBounds,long jumpTime)
        {
            timed = false;
            this.location = new Point(20, 20);
            bounds = new Rectangle(location, new Size(10, 10));

            this.myRand = myRand;
            this.fruitsList = fruitsList;
            this.obstacles = obstacles;
            this.snake = snake;
            this.gameBounds = gameBounds;
            this.jumpTime = jumpTime;

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

        public virtual bool Refresh()
        {
            
            countLiveTime.Stop();

            if (countLiveTime.ElapsedMilliseconds % jumpTime >= 0 && countLiveTime.ElapsedMilliseconds % jumpTime <= 50)
            {
                int x, y;
                do
                {
                    x = myRand.Next(20, gameBounds.Width-15);
                    y = myRand.Next(20, gameBounds.Height-15);
                    this.SetLocation(new Point(x, y));
                }
                while (CheckColision(this));

            }
            countLiveTime.Start();

            return true;
        }


        public void Drawing(Graphics g)
        {


            g.FillEllipse(Brushes.Yellow, Bounds);
            g.DrawEllipse(Pens.White, Bounds);

        }

        protected bool CheckColision(ILocalizable localizable)
        {

            foreach (ILocalizable item in fruitsList)
            {
                if(item is Banana)
                {
                    if (Object.ReferenceEquals(item, this)) continue;
                }
                if (item.Bounds.Contains(localizable.Location) || localizable.Bounds.Contains(item.Location)) return true;
            }

            foreach (ILocalizable item in obstacles)
                if (item.Bounds.Contains(localizable.Location) || localizable.Bounds.Contains(item.Location)) return true;


            if (snake.CheckColsion(localizable)) return true;

            return false;
        }
    
    }
}
