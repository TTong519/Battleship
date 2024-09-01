using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class player
    {
        public ship[] ships = new ship[5];
        public player()
        {
            ships[0] = new ship(2);
            ships[1] = new ship(3);
            ships[2] = new ship(3);
            ships[3] = new ship(4);
            ships[4] = new ship(5);
        }
    }
}
