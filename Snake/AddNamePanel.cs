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
    public partial class AddNamePanel : UserControl
    {
        
        private Action<string,int> close;
        private int points;

        public AddNamePanel(Action<string,int> close,int points,int position)
        {
            InitializeComponent();
            this.close = close;
            this.points = points;
            description.Text = $" => {position} :: ";
            scoresLabel.Text = " :: "+points.ToString()+ " ::  <=";
        }

        private void ok_Click(object sender, EventArgs e)
        {
            close(textBox1.Text,points);
        }
    }
}
