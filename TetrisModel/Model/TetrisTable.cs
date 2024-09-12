using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisModel.Model
{
    public class TetrisTable
    {
        protected int[,] table;

        public int rows { get; set; }
        public int columns { get; set; }

        protected int points = 0;

        public TetrisTable()
        {
            rows = 18;           //felso 2 csak spawn, ellenorzes
            columns = 4;
            table = new int[rows, columns];
            points = 0;
        }

        public TetrisTable (int x, int y)
        {
            rows = x + 2;           //felso 2 csak spawn, ellenorzes
            columns = y;
            table = new int[rows, columns];
            points = 0;
        }
        
       /* public TetrisTable(int[,] m)
        {
           for (int i = 0; i < m.GetLength(0); i++)
           {
                
           }
        }*/

        public int getPoints()
        {
            return points;
        }


        public int this[int x, int y]
        {
            get => table[x, y];
            set => table[x, y] = value;
        }

        public bool isInside(int x, int y)
        {
            return ((x >= 0 && x < rows) && (y >= 0 && y < columns));
        }
        
        public bool isRealRow(int x)
        {
            return (x >= 0 && x < rows);        //felso 2 jojjon ki?
        }

        public bool isRealColumn(int y)
        {
            return (y >= 0 && y < columns);
        }

        public int getElement(int x, int y)
        {
            return table[x, y];
        }

        public bool isFullElement(int x, int y)
        {
            if (!isInside(x,y))
            {
                return false;
            }
            return table[x, y] != 0;
        }

        public bool isEmptyElement(int x, int y)
        {
            if (!isInside(x, y))
            {
                return false;
            }
            return table[x, y] == 0;
        }


        public bool isFullRow(int x)
        {
           
            bool b = true;
            for (int i = 0; i < columns; i++)
            {
                b = b && isFullElement(x, i);
            }
            return b;
        }

        public bool isEmptyRow(int x)
        {
            bool b = true;
            for (int i = 0; i < columns; i++)
            {
                b = b && isEmptyElement(x, i);
            }
            return b;
        }

        public void moveRowDown(int x)
        {
            for (int i = 0; i < columns; i++)
            {
                table[x,i] = table[x - 1,i];
            }
        }

        public void RemoveRow(int x)
        {
            for (int i = x; i >= 2 ; i--)
            {
                moveRowDown(i);    
            }
        }


        public void checkTable()
        {
            for (int i = rows - 1; i >= 0; i--)     //ezen lehet javitani, felsoket nem muszaly megnezni
            {
                if (isFullRow(i))
                {
                    RemoveRow(i);
                    i++;
                    points++;
                }
            }
        }

        public bool isGameOver()
        {
            return ((!(isEmptyRow(0))) && (!(isEmptyRow(1))));
        }

        public void resetTable()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    table[i, j] = 0;
                }
            }
            points = 0;

        }

        public int getRows()
        {
            return rows;
        }

        public int getColums()
        {
            return columns;
        }




    }
}
