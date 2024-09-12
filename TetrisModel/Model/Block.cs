using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisModel.Model
{
    public class Block
    {
        protected Position[][] tiles { get; set; }

        protected Position startoffset { get; set; }
        protected Position offset { get; set; }
        protected int id { get; set; }
        public Rotation rot { get; set; }

        public Block()
        {
            startoffset = new Position(0, 0);
            offset = new Position(0, 0);
        }


        public Block(int x, int y)
        {
            startoffset = new Position(x, y);
            offset = new Position(x, y);
            
        }

        

        public int getId()
        {
            return id;
        }

        public Position getOffset()
        {
            return offset;
        }

        //public abstract bool isFullAt(int x, int y);

        public List<Position> tilePosition()
        {
            List<Position> result = new List<Position>();
            foreach (var tile in tiles[RotationFunctions.rotationValue(rot)])
            {
                result.Add(new Position(tile.row + offset.row, tile.column + offset.column));
            }
            return result;
        }



        public bool isThereInside(int x, int y)
        {
            int k = RotationFunctions.rotationValue(rot);
            bool b = false;
            foreach (Position p in tiles[k])
            {
                if ((x == p.row) && (y == p.column))
                {
                    b = true;
                }
            }
            return b;
        }

        

        

        public void moveLeft()
        {
            offset.column--;
        }

        public void moveRight()
        {
            offset.column++;
        }

        public void moveDown()
        {
            offset.row++;
        }

        public void moveUp()
        {
            offset.row--;
        }

        /*public void Move(Where w)
        {
            switch (w)
            {
                case (Where.DOWN):
                    moveDown();
                    break;
                case (Where.LEFT):
                    moveLeft();
                    break;
                case (Where.RIGHT):
                    moveRight(); 
                    break;


            }
        }*/

        public void RotateRight()
        {
            if (rot == Rotation.TWOSEVENTY)
            {
                rot = Rotation.ZERO;
            }
            else
            {
                rot++;
            }
        }

        public void RotateLeft()
        {
            if (rot == Rotation.ZERO)
            {
                rot = Rotation.TWOSEVENTY;
            }
            else
            {
                rot--;
            }
        }


        public void Reset()
        {
            offset = startoffset;
            rot = Rotation.ZERO;
        }




        



    }
}
