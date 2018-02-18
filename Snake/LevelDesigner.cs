using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    partial class Game
    {

        //new Banana(myRand, fruitsList, obstaclesList, snake, gameBoard.Bounds,3000)
        //new Strawberry(new TimeSpan(0, 0, 5), 100)
        //new Grapes(fruitsList, obstaclesList, snake, gameBoard.Bounds, myRand, (Directions)myRand.Next(0, 4))

            /*
        fruitsKindIngame.Add(() => new Grapes(fruitsList, obstaclesList, snake, gameBoard.Bounds, myRand, (Directions) myRand.Next(0, 4)));
        fruitsKindIngame.Add(() => new Strawberry(new TimeSpan(0, 0, 5), 100));
                    */


        /*
         * 2 squers on the middle
         * 
           obstaclesList.Add(new Square40(gameBoard.Width / 4 - 20, gameBoard.Height /2  - 20,50));
           obstaclesList.Add(new Square40(gameBoard.Width*3 / 4 - 20, gameBoard.Height / 2 - 20,50));
         

        */
        private void LevelUp(int level)
        {
            //level = 8;
            switch (level)
            {
                case 0:
                    obstaclesList = new List<Obstacle>();
                    fruitsKindIngame = new List<Func<IFruits>>();
                    fruitsList = new List<IFruits>();

                    recuiredPoints = 0;   //when pkt game choicen otherwise 0
                    lvlPoints = 0;   //pkt in lvl
                    fruitsOnLvl = 1;  
                    normalFruit = true;  //normal fruit in lvl

                    

                    AddBox(false);  //game in closed box
                    
                    snake = new Snake(10, new Point(300, 300), gameBoard.Bounds);
                    roundTime = new TimeSpan(0, 2, 0); //if timed game, lvl time
                    ForFormBar = new TimePointsBar(TimeBar); //TimeBar for timed game, otherwise PointBar

                    SetSnakeSpeed(Speed.speed_2);//set up snake speed, 
                    speedUpDependsSnakeLength = true;  // if true snake speed depends snakeLength
                    colisionEnabled = true;

                    timedGame = true;   
                    gameTime = new Stopwatch();
                    gameTime.Start();
                    clockStartStop();
                    break;
                case 1:
                    obstaclesList = new List<Obstacle>();
                    fruitsKindIngame = new List<Func<IFruits>>();
                    fruitsList = new List<IFruits>();

                    recuiredPoints = 0;   //when pkt game choicen otherwise 0
                    lvlPoints = 0;   //pkt in lvl
                    fruitsOnLvl = 1;
                    normalFruit = true;  //normal fruit in lvl


                    fruitsKindIngame.Add(() => new Strawberry(new TimeSpan(0, 0, 5), 100));

                    AddBox(false);  //game in closed box

                    snake = new Snake(10, new Point(300, 300), gameBoard.Bounds);
                    roundTime = new TimeSpan(0, 2, 0); //if timed game, lvl time
                    ForFormBar = new TimePointsBar(TimeBar); //TimeBar for timed game, otherwise PointBar

                    SetSnakeSpeed(Speed.speed_2);//set up snake speed, 
                    speedUpDependsSnakeLength = true;  // if true snake speed depends snakeLength
                    colisionEnabled = true;
                    timedGame = true;
                    gameTime = new Stopwatch();
                    gameTime.Start();
                    clockStartStop();

                    break;
                case 2:
                    obstaclesList = new List<Obstacle>();
                    fruitsKindIngame = new List<Func<IFruits>>();
                    fruitsList = new List<IFruits>();

                    recuiredPoints = 0;   //when pkt game choicen otherwise 0
                    lvlPoints = 0;   //pkt in lvl
                    fruitsOnLvl = 1;
                    normalFruit = true;  //normal fruit in lvl

                    fruitsKindIngame.Add(() => new Strawberry(new TimeSpan(0, 0, 5), 100));

                    AddBox(true);  //game in closed box

                    snake = new Snake(10, new Point(300, 300), gameBoard.Bounds);
                    roundTime = new TimeSpan(0, 2, 0); //if timed game, lvl time
                    ForFormBar = new TimePointsBar(TimeBar); //TimeBar for timed game, otherwise PointBar

                    SetSnakeSpeed(Speed.speed_2);//set up snake speed, 
                    speedUpDependsSnakeLength = true;  // if true snake speed depends snakeLength
                    colisionEnabled = true;
                    timedGame = true;
                    gameTime = new Stopwatch();
                    gameTime.Start();
                    clockStartStop();
                    break;
                case 3:
                    obstaclesList = new List<Obstacle>();
                    fruitsKindIngame = new List<Func<IFruits>>();
                    fruitsList = new List<IFruits>();

                    recuiredPoints = 500;   //when pkt game choicen otherwise 0
                    lvlPoints = 0;   //pkt in lvl
                    fruitsOnLvl = 1;
                    normalFruit = true;  //normal fruit in lvl

                    fruitsKindIngame.Add(() => new Banana(myRand,fruitsList,obstaclesList,snake,gameBoard.Bounds,2000));

                    AddBox(false);  //game in closed box

                    snake = new Snake(100, new Point(300, 300), gameBoard.Bounds);
                    //roundTime = new TimeSpan(0, 2, 0); //if timed game, lvl time
                    ForFormBar = new TimePointsBar(PointsBar); //TimeBar for timed game, otherwise PointBar

                    SetSnakeSpeed(Speed.speed_4);//set up snake speed, 
                    speedUpDependsSnakeLength = false;  // if true snake speed depends snakeLength
                    colisionEnabled = true;
                    timedGame = false;
                    //gameTime = new Stopwatch();
                    //gameTime.Start();
                    clockStartStop();
                    break;
                case 4:

                    obstaclesList = new List<Obstacle>();
                    fruitsKindIngame = new List<Func<IFruits>>();
                    fruitsList = new List<IFruits>();

                    recuiredPoints = 0;   //when pkt game choicen otherwise 0
                    lvlPoints = 0;   //pkt in lvl
                    fruitsOnLvl = 10;
                    normalFruit = false;  //normal fruit in lvl

                    fruitsKindIngame.Add(() => new Banana(myRand, fruitsList, obstaclesList, snake, gameBoard.Bounds, 2000));
                    fruitsKindIngame.Add(() => new Banana(myRand, fruitsList, obstaclesList, snake, gameBoard.Bounds, 1000));
                    fruitsKindIngame.Add(() => new Grapes(fruitsList, obstaclesList, snake, gameBoard.Bounds, myRand, (Directions)myRand.Next(0, 4)));
                    fruitsKindIngame.Add(() => new Grapes(fruitsList, obstaclesList, snake, gameBoard.Bounds, myRand, (Directions)myRand.Next(0, 4)));
                    fruitsKindIngame.Add(() => new Grapes(fruitsList, obstaclesList, snake, gameBoard.Bounds, myRand, (Directions)myRand.Next(0, 4)));
                    fruitsKindIngame.Add(() => new Banana(myRand, fruitsList, obstaclesList, snake, gameBoard.Bounds, 1000));
                    fruitsKindIngame.Add(() => new Grapes(fruitsList, obstaclesList, snake, gameBoard.Bounds, myRand, (Directions)myRand.Next(0, 4)));
                    fruitsKindIngame.Add(() => new Grapes(fruitsList, obstaclesList, snake, gameBoard.Bounds, myRand, (Directions)myRand.Next(0, 4)));

                    AddBox(false);  //game in closed box

                    snake = new Snake(50, new Point(300, 300), gameBoard.Bounds);
                    roundTime = new TimeSpan(0,0 , 40); //if timed game, lvl time
                    ForFormBar = new TimePointsBar(TimeBar); //TimeBar for timed game, otherwise PointBar

                    SetSnakeSpeed(Speed.speed_4);//set up snake speed, 
                    speedUpDependsSnakeLength = false;  // if true snake speed depends snakeLength
                    colisionEnabled = false;
                    AddExtraText(true, "Bonus round");

                    timedGame = true;
                    gameTime = new Stopwatch();
                    gameTime.Start();
                    clockStartStop();
                    break;
                case 5:
                    obstaclesList = new List<Obstacle>();
                    fruitsKindIngame = new List<Func<IFruits>>();
                    fruitsList = new List<IFruits>();

                    recuiredPoints = 0;   //when pkt game choicen otherwise 0
                    lvlPoints = 0;   //pkt in lvl
                    fruitsOnLvl = 2;
                    normalFruit = true;  //normal fruit in lvl

                    fruitsKindIngame.Add(() => new Grapes(fruitsList, obstaclesList, snake, gameBoard.Bounds, myRand, (Directions)myRand.Next(0, 4)));

                    obstaclesList.Add(new RectObstacles(100, gameBoard.Height / 2 - 20, new Size(gameBoard.Width - 200, 40)));

                    AddBox(false);  //game in closed box

                    snake = new Snake(10, new Point(300, 300), gameBoard.Bounds);
                    roundTime = new TimeSpan(0, 2, 0); //if timed game, lvl time
                    ForFormBar = new TimePointsBar(TimeBar); //TimeBar for timed game, otherwise PointBar

                    SetSnakeSpeed(Speed.speed_3);//set up snake speed, 
                    speedUpDependsSnakeLength = true;  // if true snake speed depends snakeLength
                    colisionEnabled = true;
                    AddExtraText(false, "");

                    timedGame = true;
                    gameTime = new Stopwatch();
                    gameTime.Start();
                    clockStartStop();
                    break;
                case 6:
                    obstaclesList = new List<Obstacle>();
                    fruitsKindIngame = new List<Func<IFruits>>();
                    fruitsList = new List<IFruits>();

                    recuiredPoints = 500;   //when pkt game choicen otherwise 0
                    lvlPoints = 0;   //pkt in lvl
                    fruitsOnLvl = 2;
                    normalFruit = true;  //normal fruit in lvl

                    fruitsKindIngame.Add(() => new Grapes(fruitsList, obstaclesList, snake, gameBoard.Bounds, myRand, (Directions)myRand.Next(0, 4)));

                    obstaclesList.Add(new RectObstacles(100, gameBoard.Height / 2 - 20, new Size(gameBoard.Width - 200, 40)));

                    AddBox(true);  //game in closed box

                    snake = new Snake(10, new Point(300, 300), gameBoard.Bounds);
                    roundTime = new TimeSpan(0, 2, 0); //if timed game, lvl time
                    ForFormBar = new TimePointsBar(PointsBar); //TimeBar for timed game, otherwise PointBar

                    SetSnakeSpeed(Speed.speed_5);//set up snake speed, 
                    speedUpDependsSnakeLength = false;  // if true snake speed depends snakeLength
                    colisionEnabled = true;
                    AddExtraText(false, "");

                    timedGame = false;
                    //gameTime = new Stopwatch();
                    //gameTime.Start();
                    clockStartStop();
                    break;
                case 7:
                    obstaclesList = new List<Obstacle>();
                    fruitsKindIngame = new List<Func<IFruits>>();
                    fruitsList = new List<IFruits>();

                    recuiredPoints = 0;   //when pkt game choicen otherwise 0
                    lvlPoints = 0;   //pkt in lvl
                    fruitsOnLvl = 2;
                    normalFruit = true;  //normal fruit in lvl

                    fruitsKindIngame.Add(() => new Grapes(fruitsList, obstaclesList, snake, gameBoard.Bounds, myRand, (Directions)myRand.Next(0, 4)));

                    obstaclesList.Add(new RectObstacles(100, gameBoard.Height / 2 - 20, new Size(gameBoard.Width - 200, 40)));
                    obstaclesList.Add(new Square40(gameBoard.Width / 4 - 20, gameBoard.Height / 2 +100, 50));
                    obstaclesList.Add(new Square40(gameBoard.Width * 3 / 4 - 20, gameBoard.Height / 2 +100, 50));

                    AddBox(false);  //game in closed box

                    snake = new Snake(100, new Point(300, 300), gameBoard.Bounds);
                    roundTime = new TimeSpan(0, 1, 0); //if timed game, lvl time
                    ForFormBar = new TimePointsBar(TimeBar); //TimeBar for timed game, otherwise PointBar

                    SetSnakeSpeed(Speed.speed_5);//set up snake speed, 
                    speedUpDependsSnakeLength = false;  // if true snake speed depends snakeLength
                    colisionEnabled = true;
                    AddExtraText(false, "");

                    timedGame = true;
                    gameTime = new Stopwatch();
                    gameTime.Start();
                    clockStartStop();
                    break;
                case 8:
                    obstaclesList = new List<Obstacle>();
                    fruitsKindIngame = new List<Func<IFruits>>();
                    fruitsList = new List<IFruits>();

                    recuiredPoints = 0;   //when pkt game choicen otherwise 0
                    lvlPoints = 0;   //pkt in lvl
                    fruitsOnLvl = 2;
                    normalFruit = true;  //normal fruit in lvl

                    fruitsKindIngame.Add(() => new Grapes(fruitsList, obstaclesList, snake, gameBoard.Bounds, myRand, (Directions)myRand.Next(0, 4)));

                    obstaclesList.Add(new RectObstacles(100, gameBoard.Height / 2 - 20, new Size(gameBoard.Width - 200, 40)));
                    obstaclesList.Add(new Square40(gameBoard.Width / 4 - 20, gameBoard.Height / 2 + 100, 50));
                    obstaclesList.Add(new Square40(gameBoard.Width * 3 / 4 - 20, gameBoard.Height / 2 + 100, 50));

                    AddBox(true);  //game in closed box

                    snake = new Snake(100, new Point(300, 300), gameBoard.Bounds);
                    roundTime = new TimeSpan(0, 1, 0); //if timed game, lvl time
                    ForFormBar = new TimePointsBar(TimeBar); //TimeBar for timed game, otherwise PointBar

                    SetSnakeSpeed(Speed.speed_4);//set up snake speed, 
                    speedUpDependsSnakeLength = false;  // if true snake speed depends snakeLength
                    colisionEnabled = true;
                    AddExtraText(false, "");

                    timedGame = true;
                    gameTime = new Stopwatch();
                    gameTime.Start();
                    clockStartStop();
                    break;

            }
        }

    }
}
