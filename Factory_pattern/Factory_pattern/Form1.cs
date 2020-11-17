using Factory_pattern.Abstractions;
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
        private List<Toy> _toys = new List<Toy>();
        public int fwidth;
        private Toy _nextToy;

        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set { 
                _factory = value;
                DisplayNext();
                }
        }
            
        public Form1()
        {
            InitializeComponent();
            mainPanel.Width = this.Width;
            fwidth = this.Width - 200;
            mainPanel.BackColor = Color.White;
            Factory = new CarFactory();
        }

        private void DisplayNext()
        {
            if (_nextToy != null)
                Controls.Remove(_nextToy);
                _nextToy = Factory.CreateNew();
                _nextToy.Top = label1.Top + label1.Left + 20;
                _nextToy.Left = label1.Left + 50;
                Controls.Add(_nextToy);
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var toy = Factory.CreateNew();
            _toys.Add(toy);
            toy.Left = -toy.Width;
            mainPanel.Controls.Add(toy);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            mainPanel.Width = this.Width;
            fwidth = this.Width - 200;
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach(var toy in _toys)
            {
                toy.MoveToy();
                if (toy.Left > maxPosition)
                {
                    maxPosition = toy.Left;
                }
            }


            if (maxPosition > fwidth)
            {
                var oldestBall = _toys[0];
                mainPanel.Controls.Remove(oldestBall);
                _toys.Remove(oldestBall);

            }
        }

        private void car_butt_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void ball_butt_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory
            {
                BallColor = button1.BackColor
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            ColorDialog cd = new ColorDialog();
            cd.Color = button1.BackColor;
            if (cd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                button1.BackColor = cd.Color;
            }
        }

        private void presentButton_Click(object sender, EventArgs e)
        {
            Factory = new PresentFactory
            {
                BoxColor = box_c_butt.BackColor,
                RibbonColor = ribb_c_butt.BackColor
            };
        }

        private void box_c_butt_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            ColorDialog cd = new ColorDialog();
            cd.Color = box_c_butt.BackColor;
            if (cd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                box_c_butt.BackColor = cd.Color;
            }
        }

        private void ribb_c_butt_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            ColorDialog cd = new ColorDialog();
            cd.Color = ribb_c_butt.BackColor;
            if (cd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                ribb_c_butt.BackColor = cd.Color;
            }
        }
    }
}
