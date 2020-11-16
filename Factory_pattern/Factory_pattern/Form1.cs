using Factory_pattern.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factory_pattern
{
    public partial class Form1 : Form
    {
        private List<Ball> _balls = new List<Ball>();
        public int fwidth;

        private BallFactory _factory;
        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }
            
        public Form1()
        {
            InitializeComponent();
            mainPanel.Width = this.Width;
            fwidth = this.Width - 200;
            mainPanel.BackColor = Color.White;
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var balls = Factory.CreateNew();
            _balls.Add(balls);
            balls.Left = -balls.Width;
            mainPanel.Controls.Add(balls);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            mainPanel.Width = this.Width;
            fwidth = this.Width - 200;
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach(var ball in _balls)
            {
                ball.MoveBall();
                if (ball.Left > maxPosition)
                {
                    maxPosition = ball.Left;
                }
            }


            if (maxPosition > fwidth)
            {
                var oldestBall = _balls[0];
                mainPanel.Controls.Remove(oldestBall);
                _balls.Remove(oldestBall);

            }
        }
    }
}
