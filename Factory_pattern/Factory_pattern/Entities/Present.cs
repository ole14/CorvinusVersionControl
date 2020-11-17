using Factory_pattern.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_pattern.Entities
{
    public class Present : Toy
    {
        public SolidBrush BoxColor { get; private set; }
        public SolidBrush RibbonColor { get; private set; }

        public Present (Color box, Color ribbon)
        {
            BoxColor = new SolidBrush(box);
            RibbonColor = new SolidBrush(ribbon);
        }

        public Color box;
        protected override void DrawImage(Graphics g)
        {
            g.FillRectangle(BoxColor, 1, 1, Width, Height);
            g.FillRectangle(RibbonColor, 20, 1, Width / 5, Height);
            g.FillRectangle(RibbonColor, 1, 20, Width, Height/5);
        }
    }
}
