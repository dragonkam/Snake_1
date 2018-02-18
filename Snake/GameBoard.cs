using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class GameBoard : UserControl
    {
        public Snake PlayersSnake { get; set; }
        public int Points { get; set; }
        public bool GameOver { get; set; }

        public GameBoard()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }



        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (GameOver)
            {
                using (Font font = new Font("Vani", 60, FontStyle.Regular))
                    g.DrawString("Game Over", font, Brushes.ForestGreen, 50, 200);

                using (Font font = new Font("Arial", 30, FontStyle.Regular))
                    g.DrawString(Points.ToString(), font, Brushes.Purple, 150, 280);

            }



        }

        private void GameBoard_Load(object sender, EventArgs e)
        {
            
        }
    }
}
