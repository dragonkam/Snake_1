using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Grapes : IFruits,ILocalizable
    {
        public Point Location => location;
        public Rectangle Bounds { get { return bounds; } }
        public int Points => points;

        public bool Timed => timed;

        private bool timed;
        private Point location;
        private Rectangle bounds;

        private Directions direct;
        private List<IFruits> fruitsList;
        private List<Obstacle> obstacles;
        private Snake snake;
        private Rectangle gameBounds;
        private Random myRandom;
        private int points = 50;

        private const int Distance = 5;


        public Grapes(List<IFruits> fruitsList, List<Obstacle> obstacles, Snake snake, Rectangle gameBounds,Random myRandom,Directions direct)
        {
            timed = false;
            
            bounds = new Rectangle(location, new Size(10, 10));

            this.myRandom = myRandom;
            this.direct = direct;
            this.fruitsList = fruitsList;
            this.obstacles = obstacles;
            this.snake = snake;
            this.gameBounds = gameBounds;

            switch (direct)
            {
                case Directions.Down:
                    this.location = new Point(myRandom.Next(5, gameBounds.Width - 15), 10);
                    break;
                case Directions.Up:
                    this.location = new Point(myRandom.Next(5, gameBounds.Width - 15), gameBounds.Height-15);
                    break;
                case Directions.Left:
                    this.location = new Point(bounds.Height-15,myRandom.Next(5, gameBounds.Height - 15));
                    break;
                case Directions.Right:
                    this.location = new Point(10, myRandom.Next(5, gameBounds.Height - 15));
                    break;
            }
            

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
            
            Point tmp = location;
            switch (direct)
            {
                case Directions.Down:
                    tmp.Y += Distance;
                    this.location = tmp;
                    bounds.Location = this.location;
                    if (CheckColision(this)) return false;
                    if (location.Y >= bounds.Height - 15) return false;
                    break;
                case Directions.Up:
                    tmp.Y -= Distance;
                    this.location = tmp;
                    bounds.Location = this.location;
                    if (CheckColision(this)) return false;
                    if (location.Y <= 15) return false;
                    break;
                case Directions.Left:
                    tmp.X -= Distance;
                    this.location = tmp;
                    bounds.Location = this.location;
                    if (CheckColision(this)) return false;
                    if (location.X <= 15) return false;
                    break;
                case Directions.Right:
                    tmp.X += Distance;
                    this.location = tmp;
                    bounds.Location = this.location;
                    if (CheckColision(this)) return false;
                    if (location.X >= gameBounds.Width-15) return false;
                    break;
            }
            

            

            return true;
        }


        public void Drawing(Graphics g)
        {


            g.FillEllipse(Brushes.Purple, Bounds);
            g.DrawEllipse(Pens.Green, Bounds);

        }

        protected bool CheckColision(ILocalizable localizable)
        {

            foreach (ILocalizable item in fruitsList)
            {
                if (item is Grapes)
                {
                    if (Object.ReferenceEquals(item, this)) continue;
                }
                if (item.Bounds.Contains(localizable.Location) || localizable.Bounds.Contains(item.Location)) return true;
            }

            foreach (ILocalizable item in obstacles)
                if (item.Bounds.Contains(localizable.Location) || localizable.Bounds.Contains(item.Location)) return true;

            if (this.Bounds.Contains(snake.SnakeHead.Location) || snake.SnakeHead.Contains(this.location)) return false;
            if (snake.CheckColsion(localizable)) return true;

            return false;
        }

    }
}
