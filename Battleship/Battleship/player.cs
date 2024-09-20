using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Player//4532 Gaviota Ct Encino CA 91436
    {
        public Ship[] Ships = new Ship[5];
        public Point Point;
        public bool vzcxv = false;
        public Player()
        {
            Ships[0] = new Ship(1);
            Ships[1] = new Ship(2);
            Ships[2] = new Ship(3);
            Ships[3] = new Ship(4);
            Ships[4] = new Ship(5);
        }
        public void Setter(Point stpoint, Point epoint)
        {
            if(stpoint.X == epoint.X)
            {
                int index = Math.Abs(stpoint.Y - epoint.Y);
                for (int i = 0; i < Ships[index].size; i++)
                {
                    Ships[index].body[i] = new Point(stpoint.X, stpoint.Y + i);
                    Ships[index].inited = true;
                }
            }
            else if (stpoint.Y == epoint.Y)
            {
                int index = Math.Abs(stpoint.X - epoint.X);
                for (int i = 0; i < Ships[index].size; i++)
                {
                    Ships[index].body[i] = new Point(stpoint.X + i, stpoint.Y);
                    Ships[index].inited = true;
                }
            }
        }
    }
}
