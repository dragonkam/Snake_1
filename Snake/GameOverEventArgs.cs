using System;

namespace SnakeGame
{
    public class GameOverEventArgs:EventArgs
    {
        public readonly int Scores;
        public GameOverEventArgs(int scores)
        {
            Scores = scores;
        }
    }
}
