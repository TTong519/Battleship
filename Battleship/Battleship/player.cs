using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
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
        bool Collision(int index, int i)
        {
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < j + 1; k++)
                {
                    if (Ships[j].body[k] == Ships[index].body[i] && Ships[j].inited && j != index)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool Setter(Point stpoint, Point epoint)
        {
            if (stpoint == epoint)
            {
                Ships[0].body[0] = stpoint;
            }
            if(stpoint.X == epoint.X)
            {
                int index = Math.Abs(stpoint.Y - epoint.Y);
                if(index > 5)
                {
                    return false;
                }
                for (int i = 0; i < Ships[index].size; i++)
                {
                    if (stpoint.Y > epoint.Y)
                    {
                        Ships[index].body[i] = new Point(stpoint.X, stpoint.Y - i);
                        if(!Collision(index, i))
                        {
                            return false;
                        }
                    }
                    if (stpoint.Y < epoint.Y)
                    {
                        Ships[index].body[i] = new Point(stpoint.X, stpoint.Y + i);
                        if (!Collision(index, i))
                        {
                            return false;
                        }
                    }
                    Ships[index].inited = true;
                }
                return true;
            }
            else if (stpoint.Y == epoint.Y)
            {
                int index = Math.Abs(stpoint.X - epoint.X);
                if (index >= 5)
                {
                    return false;
                }
                for (int i = 0; i < Ships[index].size; i++)
                {
                    if (stpoint.X > epoint.X)
                    {
                        Ships[index].body[i] = new Point(stpoint.X - i, stpoint.Y);
                        if (!Collision(index, i))
                        {
                            return false;
                        }
                    }
                    if (stpoint.X < epoint.X)
                    {
                        Ships[index].body[i] = new Point(stpoint.X + i, stpoint.Y);
                        if (!Collision(index, i))
                        {
                            return false;
                        }
                    }
                    Ships[index].inited = true;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
