using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisModel.Model
{
    public class State
    {
        public int points { get; set; }
        public int time { get; set; }

        Random r = new Random();

        public TetrisTable table { get; set; }
        NextBlock generator { get; set; }

        public Block current { get; set; }

        public bool gameOver { get; set; }
        


        public State()
        {
            table = new TetrisTable();
            generator = new NextBlock();

            current = generator.getNextAndGenerate();
            current.Reset();

            points = 0;
            time = 0;
            gameOver = false;
        }

        public State(int x, int y)
        {
            table = new TetrisTable(x,y);
            generator = new NextBlock();
            //current = new Block();

            current = generator.getNextAndGenerate();
            
            current.Reset();
            
            points = 0;
            time = 0;
            gameOver = false;
        }

        public void AddTime()
        {
            time++;
        }

        public void AddPoints()
        {
            points++;
        }

        public int getTime()
        {
            return time;
        }

        public int getPoints()
        {
            return points;
        }

        public Block getCurrent()
        {
            return current;
        }

        

        public bool blockFits()
        {
            //bool b = true;
            foreach (var pos in current.tilePosition())
            {
                //b = b && (table.isEmptyElement(pos.row, pos.column));
                if (!table.isEmptyElement(pos.row, pos.column))
                {
                    return false;
                }
            }
            return true;
        }

        public void SecureRotateRight()
        {
            current.RotateRight();
            if (!blockFits())
            {
                current.RotateLeft();
            }
        }

        public void SecureRotateLeft()
        {
            current.RotateLeft();
            if (!blockFits())
            {
                current.RotateLeft();
            }
        }

        public void secureMoveLeft()
        {
            current.moveLeft();
            if (!blockFits())
            {
                current.moveRight();
            }
       
        }

        public void secureMoveRight()
        {
            current.moveRight();
            if (!blockFits())
            {
                current.moveLeft();
            }

        }

        public bool getGameOver()
        {
            return gameOver;
        }

        public bool IsGameOver()
        {
            return table.isGameOver();
        }

        public void Place()
        {
            foreach (var pos in current.tilePosition())
            {
                table[pos.row, pos.column] = current.getId();
            }
            
            table.checkTable();

            gameOver = gameOver || IsGameOver();

            if (!gameOver)
            {
                points = table.getPoints();
                current = generator.getNextAndGenerate();
                if (!blockFits())
                {
                    gameOver = true;
                }    
            }
        }

        public void moveDown()
        {
            current.moveDown();

            if (!blockFits())
            {
                current.moveUp();
                Place();
            }

        }

        public void ResetGame()
        {
            points = 0;
            time = 0;
            table.resetTable();
            current = generator.getNextAndGenerate();
            gameOver = false;

        }

    }
}
