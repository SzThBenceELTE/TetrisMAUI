using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisModel.Model
{
    public class NextBlock
    {
        public Block next { get; set; }
        //public Block current { get; set; }
        public Random random { get; set; }

        int x;

        public NextBlock()
        {
            random = new Random();
            x = 0;
            generateNext();
        }

        public NextBlock(int xs)
        {
            random = new Random();
            x = xs;
            generateNext();
        }

        public void generateNext()
        {

            int r = random.Next(7);
            switch(r)
            {
                case 0:
                    next = new O_Block();
                    break;
                case 1:
                    next = new I_Block();
                    break;
                case 2:
                    next = new L_Block();
                    break;
                case 3:
                    next = new J_Block();
                    break;
                case 4:
                    next = new T_Block();
                    break;
                case 5:
                    next = new S_Block();
                    break;
                case 6:
                    next = new Z_Block();
                    break;


            }
            
        }

        public Block getNext()
        {
            return next;
        }

        public Block getNextAndGenerate()
        {
            Block block = getNext();

            generateNext();

            return block;
            
        }
    }
}
