using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisModel.Model
{
    public class T_Block : Block
    {
        public T_Block(int sx, int sy)
        {
            tiles = new Position[][]
            {
                new Position[] {new Position(0,1), new Position(1, 0) , new Position(1, 1) , new Position(1, 2) },
                new Position[] {new Position(1,2), new Position(0, 1) , new Position(1, 1) , new Position(2, 1) },
                new Position[] {new Position(2,1), new Position(1, 2) , new Position(1, 1) , new Position(1, 0) },
                new Position[] {new Position(1,0), new Position(0, 1) , new Position(1, 1) , new Position(2, 1) }
            };

            offset = new Position(sx, sy);
            id = 4;
            rot = Rotation.ZERO;
        }

        public T_Block()
        {
            tiles = new Position[][]
            {
                new Position[] {new Position(0,1), new Position(1, 0) , new Position(1, 1) , new Position(1, 2) },
                new Position[] {new Position(1,2), new Position(0, 1) , new Position(1, 1) , new Position(2, 1) },
                new Position[] {new Position(2,1), new Position(1, 2) , new Position(1, 1) , new Position(1, 0) },
                new Position[] {new Position(1,0), new Position(0, 1) , new Position(1, 1) , new Position(2, 1) }
            };

            offset = new Position(0, 0);
            id = 5;
            rot = Rotation.ZERO;
        }
    }
}
