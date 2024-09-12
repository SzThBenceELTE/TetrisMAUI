using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisModel.Model
{
    public class J_Block : Block
    {
        public J_Block()
        {
            tiles = new Position[][]
            {
                new Position[] {new Position(0,0), new Position(1, 0) , new Position(1, 1) , new Position(1, 2) },
                new Position[] {new Position(0,1), new Position(0, 2) , new Position(1, 1) , new Position(2, 1) },
                new Position[] {new Position(1,0), new Position(1, 1) , new Position(1, 2) , new Position(2, 2) },
                new Position[] {new Position(0,1), new Position(1, 1) , new Position(2, 1) , new Position(2, 2) },
            };

            offset = new Position(0, 0);
            id = 4;
            rot = Rotation.ZERO;
        }


        public J_Block(int x, int y)
        {
            tiles = new Position[][]
            {
                new Position[] {new Position(0,0), new Position(1, 0) , new Position(1, 1) , new Position(1, 2) },
                new Position[] {new Position(0,1), new Position(0, 2) , new Position(1, 1) , new Position(2, 1) },
                new Position[] {new Position(1,0), new Position(1, 1) , new Position(1, 2) , new Position(2, 2) },
                new Position[] {new Position(0,1), new Position(1, 1) , new Position(1, 2) , new Position(2, 1) },
            };

            offset = new Position(x, y);
            id = 4;
            rot = Rotation.ZERO;
        }
    }
}
