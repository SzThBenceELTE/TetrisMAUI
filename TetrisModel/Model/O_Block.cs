using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisModel.Model
{
    public class O_Block : Block
    {
        public O_Block()
        {
            tiles = new Position[][]
            {
                new Position[] {new Position(0,0), new Position(0, 1) , new Position(1, 0) , new Position(1, 1) },
                new Position[] {new Position(0,0), new Position(0, 1) , new Position(1, 0) , new Position(1, 1) },
                new Position[] {new Position(0,0), new Position(0, 1) , new Position(1, 0) , new Position(1, 1) },
                new Position[] {new Position(0,0), new Position(0, 1) , new Position(1, 0) , new Position(1, 1) },
            };

            offset = new Position(0, 0);
            id = 1;
            rot = Rotation.ZERO;
        }


        public O_Block(int x, int y)
        {
            tiles = new Position[][]
            {
                new Position[] {new Position(0,0), new Position(0, 1) , new Position(1, 0) , new Position(1, 1) },
                new Position[] {new Position(0,0), new Position(0, 1) , new Position(1, 0) , new Position(1, 1) },
                new Position[] {new Position(0,0), new Position(0, 1) , new Position(1, 0) , new Position(1, 1) },
                new Position[] {new Position(0,0), new Position(0, 1) , new Position(1, 0) , new Position(1, 1) },
            };

            offset = new Position(x, y);
            id = 1;
            rot = Rotation.ZERO;
        }

    }
}
