using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class ship
    {
        public int size = 0;
        public Point[] body = new Point[0];
        public ship(int size)
        {
            this.size = size;
            Point[] body1 = new Point[size];
            body = body1;
        }
    }
}
