using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace SnakeGame
{
    public partial class Form1 : Form
    {
        
        private ClockStartStop clockStartStop;
        private AccelerateSnake accelerateSnake;
        private Game game;
        private List<Tuple<string, int>> scoresList;
        private AddNamePanel addScores;

        public Form1()
        {
            InitializeComponent();
            clockStartStop = new ClockStartStop(EnDisableClock);
            accelerateSnake = new AccelerateSnake(SetSnakeSpeed);
            LoadPoints();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            gameBoard1.Refresh();
            
        }

        private void gameTimer_Tick(object sender, EventArgs e) 
        {
            game.GameRun();

            toolStripStatusLabel1.Text = game.Snak.ToString() + "  " + gameTimer.Interval.ToString() ;
            LevelProgress.Value = game.ForFormBar();
            statusStrip1.Refresh();
        }

        private void nowaGraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Controls.Contains(addScores))  this.Controls.Remove(addScores);
            gameBoard1.GameOver = false;
            game = new Game(gameBoard1,clockStartStop,accelerateSnake);
            game.GameOver += GameOver;
            game.GameStart();
            
            Focus();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q) Application.Exit();
            if (e.KeyCode == Keys.N) nowaGraToolStripMenuItem.PerformClick();
            if (e.KeyCode == Keys.P)
            {
                if(!(game is null))
                game.Pause();
            }
            

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {


            if (game != null)
            {
                if (e.KeyCode == Keys.Up)
                {
                    game.Move(Directions.Up);
                    return;
                }
                if (e.KeyCode == Keys.Down)
                {
                    game.Move(Directions.Down);
                    return;
                }
                if (e.KeyCode == Keys.Right)
                {
                    game.Move(Directions.Right);
                    return;
                }
                if (e.KeyCode == Keys.Left)
                {
                    game.Move(Directions.Left);
                    return;
                }
            }
        }

        

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
           
        }

        private void EnDisableClock()
        {
            if (gameTimer.Enabled) gameTimer.Enabled = false;
            else gameTimer.Enabled = true;
        }

        private void pausaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!(game is null))
            game.Pause();
        }



        private void Form1_Resize(object sender, EventArgs e)
        {
           
            if(WindowState==FormWindowState.Minimized)
            {
                if (!(game is null))
                {
                    if(!game.Pausa)
                    game.Pause();
                }
            }
        }

        private void LoadPoints()
        {

            System.Runtime.Serialization.IFormatter formatter = new BinaryFormatter();
            scoresList = new List<Tuple<string, int>>();
            if (File.Exists("bestPoints.pnt"))
            {
                using(FileStream file = File.OpenRead("bestPoints.pnt"))
                {
                    scoresList = (List<Tuple<string, int>>)formatter.Deserialize(file);
                }

            }
        }

        private void SavePoints()
        {
            System.Runtime.Serialization.IFormatter formatter = new BinaryFormatter();

            using(FileStream file = File.Create("bestPoints.pnt"))
            {
                formatter.Serialize(file, scoresList);
            }

        }

        private void GameOver(object sender, GameOverEventArgs e)
        {
            
            if (scoresList.Count==0 || e.Scores > scoresList[scoresList.Count - 1].Item2 || scoresList.Count<10)
            {
                
                Action<string,int> addPoints = new Action<string,int>(AddPointsToList);

                int position = 1;
                foreach(var item in scoresList)
                {
                    if (e.Scores >= item.Item2) break;
                    else position++;
                }

                addScores = new AddNamePanel(addPoints,e.Scores,position);
                this.Controls.Add(addScores);
                addScores.BringToFront();
                this.Refresh();
            }
        }

        private void AddPointsToList(string name,int points)
        {
            scoresList.Add(new Tuple<string, int>(name,points));
            scoresList.OrderBy(a => a.Item2);
            if (scoresList.Count > 10)
                scoresList.RemoveAt(10);

            SavePoints();
            Controls.Remove(addScores);
            addScores = null;
        }
        
        private void SetSnakeSpeed(int speed)
        {
            gameTimer.Interval = speed;

        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void wynikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string t = "";
            int position = 0;
            foreach(var item in scoresList)
            {
                t += $"                => {position} :: {item.Item1} :: {item.Item2} ||                            \n";
                position++;
            }

            MessageBox.Show(t);
        }
    }
}
