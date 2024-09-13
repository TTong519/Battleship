using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class ship//I hate this but it won't let me rename so :( -Nikita
    {
        public int size = 0;
        public Point[] body = new Point[0];
        public ship(int size)
        {
            this.size = size;
            Point[] body1 = new Point[size];
            body = body1;
        }
        public void Draw(Grid grd, Graphics gfx, Brush b)
        {
            for(int i = 0; i < size; i++)
            {
                gfx.FillRectangle(b, grd.Squares[body[i].X, body[i].Y].Hitbox);
            }
        }
    }
}
