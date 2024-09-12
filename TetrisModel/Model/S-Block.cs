using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisModel.Model
{
    public class S_Block : Block
    {
        public S_Block()
        {
            tiles = new Position[][]
            {
                new Position[] {new Position(0,1), new Position(0, 2) , new Position(1, 0) , new Position(1, 1) },
                new Position[] {new Position(0,1), new Position(1, 1) , new Position(1, 2) , new Position(2, 2) },
                new Position[] {new Position(1,1), new Position(1, 2) , new Position(2, 0) , new Position(2, 1) },
                new Position[] {new Position(0,0), new Position(1, 0) , new Position(1, 1) , new Position(2, 1) },
            };

            offset = new Position(0, 0);
            id = 6;
            rot = Rotation.ZERO;
        }


        public S_Block(int x, int y)
        {
            tiles = new Position[][]
             {
                new Position[] {new Position(0,1), new Position(0, 2) , new Position(1, 0) , new Position(1, 1) },
                new Position[] {new Position(0,1), new Position(1, 1) , new Position(1, 2) , new Position(2, 2) },
                new Position[] {new Position(1,1), new Position(1, 2) , new Position(2, 0) , new Position(2, 1) },
                new Position[] {new Position(0,0), new Position(1, 0) , new Position(1, 1) , new Position(2, 1) },
             };

            offset = new Position(x, y);
            id = 6;
            rot = Rotation.ZERO;
        }
    }
}
