using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisModel.Model
{
    public class Z_Block : Block
    {
        public Z_Block(int sx, int sy)
        {
            tiles = new Position[][]
            {
                new Position[] {new Position(0,0), new Position(0, 1) , new Position(1, 1) , new Position(1, 2) },
                new Position[] {new Position(0,2), new Position(1, 1) , new Position(1, 2) , new Position(2, 1) },
                new Position[] {new Position(1,0), new Position(1, 1) , new Position(2, 1) , new Position(2, 2) },
                new Position[] {new Position(1,0), new Position(0, 1) , new Position(1, 1) , new Position(2, 0) }
            };

            offset = new Position(sx, sy);
            id = 7;
            rot = Rotation.ZERO;
        }

        public Z_Block()
        {
            tiles = new Position[][]
            {
                new Position[] {new Position(0,0), new Position(0, 1) , new Position(1, 1) , new Position(1, 2) },
                new Position[] {new Position(0,2), new Position(1, 1) , new Position(1, 2) , new Position(2, 1) },
                new Position[] {new Position(1,0), new Position(1, 1) , new Position(2, 1) , new Position(2, 2) },
                new Position[] {new Position(1,0), new Position(0, 1) , new Position(1, 1) , new Position(2, 0) }
            };

            offset = new Position(0, 0);
            id = 7;
            rot = Rotation.ZERO;
        }
    }
}

