using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Grid
    {
        public Square[,] Squares = new Square[10, 10];
        public Grid()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Squares[i, j] = new(Brushes.White, 2 + 40 * j, 2 + 40 * i);
                }
            }
        }
    }
}
