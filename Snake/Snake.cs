using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    public class Snake
    {
        public Rectangle SnakeHead => snakeBody[0];
        public int SnakeLength => snakeBody.Count;

        private Rectangle boundaries;
        private int snakeLength;
        private List<Rectangle> snakeBody;
        private Directions movingDirection;
        private Directions lastDirect;

        private const int distance = 10;
        private const int rectangleSize = 10;
        

        public Snake(int snakeLength,Point startingLocation, Rectangle boundaries)
        {
            this.boundaries = boundaries;
            this.snakeLength = snakeLength;
            CreateSnake(startingLocation);
            movingDirection = Directions.Right;
            lastDirect = Directions.Right;
        }

        private void CreateSnake(Point startingLocation)
        {
           
            snakeBody = new List<Rectangle>();
            for(int i = 0; i < snakeLength; i++)
            {
                snakeBody.Add(new Rectangle(new Point(startingLocation.X - (i * rectangleSize), startingLocation.Y), new Size(rectangleSize, rectangleSize)));
            }
        }

        public bool CheckColsion(ILocalizable locItem)
        {
            foreach (Rectangle item in snakeBody)
            {
                if(item.Contains(locItem.Location) || locItem.Bounds.Contains(item.Location))
                {
                    return true;
                }
            }

            return false;
        }
      

        public bool Move()
        {
            Rectangle rect=snakeBody[0];
            Point tmp = snakeBody[0].Location;             
            
            switch (movingDirection)
            {
                case Directions.Up:
                    if (lastDirect == Directions.Down)
                    {
                        movingDirection = Directions.Down;
                        break;
                    }
                    rect.Y -= distance;
                    if (rect.Y <=-1)
                        rect.Y = boundaries.Size.Height;
                    snakeBody[0] = rect;
                    lastDirect = Directions.Up;

                    break;
                case Directions.Down:
                    if (lastDirect == Directions.Up)
                    {
                        movingDirection = Directions.Up;
                        break;
                    }
                    rect.Y += distance;
                    if (rect.Y >= boundaries.Size.Height)
                        rect.Y = 0;
                    snakeBody[0] = rect;
                    lastDirect = Directions.Down;
                    break;
                case Directions.Right:
                    if (lastDirect == Directions.Left)
                    {
                        movingDirection = Directions.Left;
                        break;
                    }
                    rect.X += distance;
                    if (rect.X >= boundaries.Right)
                        rect.X = boundaries.Left;
                    snakeBody[0] = rect;
                    lastDirect = Directions.Right;
                    break;
                case Directions.Left:
                    if (lastDirect == Directions.Right)
                    {
                        movingDirection = Directions.Right;
                        break;
                    }
                    rect.X -= distance;
                    if (rect.X <= -1)
                        rect.X = boundaries.Right;
                    snakeBody[0] = rect;
                    lastDirect = Directions.Left;
                    break;
            }

           if (CheckForBodyColision()) return false;

            for (int i = snakeBody.Count-1; i > 0; i--)
            {
                if (i == 1)
                {
                    Rectangle tmpRec = snakeBody[i];
                    tmpRec.Location = tmp;
                    snakeBody[i] = tmpRec;
                }
                else
                {
                    Rectangle tmpRec = snakeBody[i];
                    tmpRec.Location = snakeBody[i - 1].Location;
                    snakeBody[i] = tmpRec;
                }
            }

            return true;
        }

        public void Drawing(Graphics g)
        {
           for(int i = 0; i < snakeBody.Count; i++)
            {
                if (i == 0) g.FillRectangle(Brushes.Red, snakeBody[i]);
                else
                g.FillRectangle(Brushes.CadetBlue, snakeBody[i]);
                g.DrawRectangle(Pens.GreenYellow, snakeBody[i]);        
                
            }

        }

        private bool CheckForBodyColision()
        {
            for(int i = 1; i < snakeBody.Count; i++)
            {
                if (snakeBody[i].Location == snakeBody[0].Location) return true;
            }
            return false;
        }

        public void ChangeDirection(Directions direction)
        {
            this.movingDirection = direction;
        }

        public int Eat(List<IFruits> fruitList)
        {
            for(int i = fruitList.Count; i > 0; i--)
            {
                if (SnakeHead.Contains(fruitList[i-1].Location) || fruitList[i-1].Bounds.Contains(SnakeHead.Location))
                {
                    snakeBody.Add(new Rectangle(snakeBody[snakeBody.Count-1].Location, new Size(rectangleSize, rectangleSize)));
                    snakeBody.Add(new Rectangle(snakeBody[snakeBody.Count - 1].Location, new Size(rectangleSize, rectangleSize)));
                    int tmp = fruitList[i-1].Points;
                    fruitList.RemoveAt(i-1);
                    return tmp;

                }
               
            }
            return 0;
        }

        public override string ToString()
        {

            return "Snake length : "+snakeLength;
        }

    }
}
