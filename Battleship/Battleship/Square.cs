using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public enum State
    {
        Hit,
        Miss,
        None
    }
    public class Square
    {
        public Brush color;
        public Rectangle Hitbox;
        public State state = State.None;
        public Square(Brush color, int x, int y)
        {
            this.color = color;
            Hitbox = new Rectangle(x, y, 38, 38);

        }
    }
}
