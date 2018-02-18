using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace SnakeGame
{
    partial class Game
    {
        public Point Snak => snake.SnakeHead.Location;
        public TimeSpan RoundTime => gameTime.Elapsed;
        public TimePointsBar ForFormBar { get; set; }
        public bool GameRuning { get; private set; }
        public bool Pausa { get; private set; }
        
        
        private int level;
        private Snake snake;
        private GameBoard gameBoard;
        private List<Obstacle> obstaclesList;
        private List<IFruits> fruitsList;
        private int fruitsOnLvl;
        private Random myRand;
        private List<Func<IFruits>> fruitsKindIngame;
        private int points;
        private Stopwatch gameTime;
        private bool timedGame;
        private int recuiredPoints;
        private TimeSpan roundTime;
        private int lvlPoints;
        private bool normalFruit;
        private bool speedUpDependsSnakeLength;
        private Speed speed;
        private bool colisionEnabled;
        private bool extraTextEnabled;
        private string extraText;

        private AccelerateSnake accelerateSnake;
        private ClockStartStop clockStartStop;
        public event EventHandler<GameOverEventArgs> GameOver;
        

       
        public Game(GameBoard gameBoard,ClockStartStop clockStartStop,AccelerateSnake accelerateSnake)
        {
            this.gameBoard = gameBoard;
            gameBoard.Paint += new PaintEventHandler(OnPaint);
            myRand = new Random();
            this.clockStartStop = clockStartStop;
            this.accelerateSnake = accelerateSnake;
            accelerateSnake = new AccelerateSnake(Accelerate);
            level = 0;
            points = 0;

        }

        public void Move(Directions direct) => snake.ChangeDirection(direct);

        public void GameStart()
        {
            LevelUp(0);
            GameRuning = true;
        }

        public void GameRun()
        {
            if(!snake.Move()) OnGameOver();
            if (CheckObstacleColision(snake.SnakeHead)) OnGameOver();

            if (normalFruit) CheckForNormalFruit();

            if (fruitsKindIngame.Count > 0)
            {
                if (!normalFruit && fruitsList.Count < fruitsOnLvl) FruitAdd(fruitsKindIngame[myRand.Next(0, fruitsKindIngame.Count)]);
                else if (normalFruit && fruitsList.Count < fruitsOnLvl + 1) FruitAdd(fruitsKindIngame[myRand.Next(0, fruitsKindIngame.Count)]);
            }

            for (int i = fruitsList.Count - 1; i > 0; i--)
                if (!fruitsList[i].Refresh()) fruitsList.RemoveAt(i);

            int tmp= snake.Eat(fruitsList);

            points += tmp;
            lvlPoints += tmp;

            if (speedUpDependsSnakeLength) Accelerate(snake.SnakeLength);

            if (timedGame)
            {
                if (gameTime.Elapsed >= roundTime)
                {
                    gameTime.Stop();
                    clockStartStop();
                    level++;
                    LevelUp(level);
                }
            }
            else
            {
                if (lvlPoints >= recuiredPoints)
                {
                    gameTime.Stop();
                    clockStartStop();
                    level++;
                    LevelUp(level);
                }
            }

        }

        

        private void OnPaint(object sender,PaintEventArgs e)
        {


            Graphics g = e.Graphics;
            using (Font font = new Font("Arial", 15, FontStyle.Regular))
                g.DrawString("Scores: "+points.ToString(), font, Brushes.Yellow, 25, 10);

            using (Font font = new Font("Arial", 12, FontStyle.Regular))
                g.DrawString("Lvl Scores: " +lvlPoints.ToString(), font, Brushes.Yellow, 30, 30);

            using (Font font = new Font("Arial", 8, FontStyle.Regular))
                    g.DrawString("Snake length: "+snake.SnakeLength, font, Brushes.Yellow,35, 50);

            if (extraTextEnabled)
            {
                using (Font font = new Font("Arial", 15, FontStyle.Regular))
                    g.DrawString(extraText, font, Brushes.Red, 150, 10);
            }

            if (!colisionEnabled) g.FillEllipse(Brushes.Red, gameBoard.Bounds.Width - 35, 15, 30, 30);
            snake.Drawing(g);

            foreach(IFruits item in fruitsList)
            {
                item.Drawing(g);
            }

            foreach (var item in obstaclesList)
                item.Draw(g);

        }
        
        private void CheckForNormalFruit()
        {
            foreach (var item in fruitsList)
                if (item is Strawberry && !item.Timed) return;
                 

            FruitAdd(() => new Strawberry());
        }
       

        private void FruitAdd(Func<IFruits> fruit)
        {
           
            IFruits tmpfruit = fruit();
            ILocalizable tmpFruit;
            

            do
            {
                Point tmp = new Point(myRand.Next(15, gameBoard.Width - 15), myRand.Next(15, gameBoard.Height - 15));
                tmpfruit.SetLocation(tmp);
                tmpFruit = tmpfruit as ILocalizable;

            }
            while (CheckColision(tmpFruit));

            fruitsList.Add(tmpfruit);
            
          
            
        }

        public void Pause()
        {

            if (GameRuning)
            {
                if (Pausa) Pausa = false;
                else Pausa = true;

                clockStartStop();
            }

        }

        private int PointsBar() =>Convert.ToInt16( (double)lvlPoints / (double)recuiredPoints * 100);
      

        private int TimeBar()
        {
            Double timeInMs = Convert.ToDouble(gameTime.ElapsedMilliseconds);
            Double rTimeInMs = Convert.ToDouble(roundTime.TotalMilliseconds);
            return (int)(timeInMs/rTimeInMs*100);
        }


       private bool CheckColision(ILocalizable localizable)
        {

            foreach (ILocalizable item in fruitsList)
                {                
                    if (item.Bounds.Contains(localizable.Location) || localizable.Bounds.Contains(item.Location)) return true; 
                }

            foreach (ILocalizable item in obstaclesList)
                    if (item.Bounds.Contains(localizable.Location) || localizable.Bounds.Contains(item.Location)) return true;
                

            if (snake.CheckColsion(localizable)) return true;

            return false;
        }

        private bool CheckObstacleColision(Rectangle localizable)
        {
                     
            foreach (ILocalizable item in obstaclesList)
                if (item.Bounds.Contains(localizable.Location) || localizable.Contains(item.Location)) return true;
            

            return false;
        }

        private void SetSnakeSpeed(Speed speed)
        {
            accelerateSnake((int)speed);
            this.speed = speed;
        }

        private void Accelerate(int snakeLength)
        {
            if (snakeLength >= 20 && snakeLength < 40)
            {
                if ((int)speed > (int)Speed.speed_2)
                    accelerateSnake((int)Speed.speed_2);
            }
            else if (snakeLength >= 40 && snakeLength < 60)
            {
                if (speed > Speed.speed_3)
                    accelerateSnake((int)Speed.speed_3);
            }

            else if (snakeLength >= 80 && snakeLength < 100)
            {
                if (speed > Speed.speed_4)
                    accelerateSnake((int)Speed.speed_4);
            }
            else if (snakeLength >= 100 && snakeLength < 120)
            {
                if (speed > Speed.speed_5)
                    accelerateSnake((int)Speed.speed_5);
            }
            else if (snakeLength >= 140 )
            {
                if (speed > Speed.speed_6)
                    accelerateSnake((int)Speed.speed_6);
            }

        }

        private void AddBox(bool addOrNot)
        {
            if (addOrNot)
            {
                obstaclesList.Add(new RectObstacles(new Point(0, 0), new Size(gameBoard.Width, 5)));
                obstaclesList.Add(new RectObstacles(new Point(gameBoard.Width - 5, 0), new Size(5, gameBoard.Height)));
                obstaclesList.Add(new RectObstacles(new Point(0, 0), new Size(5, gameBoard.Height)));
                obstaclesList.Add(new RectObstacles(new Point(0, gameBoard.Height - 5), new Size(gameBoard.Width, 5)));
            }
        }

        private void OnGameOver()
        {
            if (colisionEnabled)
            {
                gameBoard.Paint -= OnPaint;
                gameBoard.Points = points;
                gameBoard.GameOver = true;
                OnGameOver(new GameOverEventArgs(points));
                clockStartStop();
            }
            else
            {
                gameTime.Stop();
                clockStartStop();
                level++;
                LevelUp(level);
            }

        }

        protected virtual void OnGameOver(GameOverEventArgs e)
        {
            GameOver?.Invoke(this, e);
        }

        private void AddExtraText(bool enabled, string extraText)
        {
            this.extraText = extraText;
            this.extraTextEnabled = enabled;
        }

    }
}
