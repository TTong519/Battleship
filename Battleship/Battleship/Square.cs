using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Square
    {
        public Brush color;
        public Rectangle Hitbox;
        public Square(Brush color, int x, int y)
        {
            this.color = color;
            Hitbox = new Rectangle(x, y, 48, 48);

        }
    }
}
