using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITetris.ViewModel
{
    public class TetrisField : ViewModelBase
    {

        private int id;
        private string text;
        private Color color;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged(); }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; OnPropertyChanged(); }
        }


        public int X { get; set; }
        public int Y { get; set; }

        public int Number { get; set; }



    }
}
