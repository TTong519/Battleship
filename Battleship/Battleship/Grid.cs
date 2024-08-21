using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Grid
    {
        public Square[,] Squares = new Square[8, 8];
        public Grid()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Squares[i, j] = new(Brushes.White, 2 + 100 * j, 2 + 100 * i);
                }
            }
        }
    }
}
