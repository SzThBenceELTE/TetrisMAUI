using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisModel.Model;

namespace TetrisModel.Persistence
{
    public class SaveToFile : ISaveTo
    {
        string file;
        //StreamWriter sw;
        public SaveToFile (string _file)
        {
            file = _file;
        }

        public void WriteState(State s)
        {
            try
            {

                StreamWriter sw = new StreamWriter(file);

                sw.WriteLine((s.table.getRows()) - 2);
                sw.WriteLine(s.table.getColums());

                for (int i = 0; i < s.table.getRows(); i++)
                {
                    for (int j = 0; j < s.table.getColums(); j++)
                    {
                        sw.WriteLine(s.table[i, j]);
                    }
                }
                sw.WriteLine(s.getPoints());
                sw.WriteLine(s.getTime());
                sw.WriteLine(s.getGameOver());

                sw.Close();
            }
            catch (Exception ex)
            {
                throw new FileManagerException(ex.Message, ex);
            }

        }


        public State ReadState()
        {
            try
            {
                State s;


                StreamReader sr = new StreamReader(file);

                int r = Convert.ToInt32(sr.ReadLine());
                int c = Convert.ToInt32(sr.ReadLine());

                s = new State(r, c);



                for (int i = 0; i < r + 2; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        s.table[i, j] = Convert.ToInt32(sr.ReadLine());
                    }
                }

                s.points = Convert.ToInt32(sr.ReadLine());
                s.time = Convert.ToInt32(sr.ReadLine());
                s.gameOver = Convert.ToBoolean(sr.ReadLine());

                sr.Close();

                return s;
            }
            catch (Exception ex)
            {
                throw new FileManagerException(ex.Message, ex);
            }

        }
    }
}
