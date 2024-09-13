using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class player//4532 Gaviota Ct Encino CA 91436
    {
        public ship[] Ships = new ship[5];
        public Point Point;
        public player()
        {
            Ships[0] = new ship(2);
            Ships[1] = new ship(3);
            Ships[2] = new ship(3);
            Ships[3] = new ship(4);
            Ships[4] = new ship(5);
        }
        public void Setter(Point stpoint, Point epoint)
        {
            if(stpoint.X == epoint.X)
            {
                int index = stpoint.Y = epoint.Y;
                for (int i = 0; i < Ships[index].size; i++)
                {
                    Ships[index].body[i] = new Point(stpoint.X, stpoint.Y + i);
                }
            }
            else if (stpoint.Y == epoint.Y)
            {
                int index = stpoint.X = epoint.X;
                for (int i = 0; i < Ships[index].size; i++)
                {
                    Ships[index].body[i] = new Point(stpoint.X + i, stpoint.Y);
                }
            }
        }
    }
}
