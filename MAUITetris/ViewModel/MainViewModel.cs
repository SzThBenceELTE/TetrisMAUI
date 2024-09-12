using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisModel.Model;

namespace MAUITetris.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string pauseText = "Pause";
        private Color pauseColor = Colors.Red;

        private State _model;

        private bool canSaveLoad = false;


        public DelegateCommand NewGameCommand { get; private set; }

        public DelegateCommand LoadGameCommand { get; private set; }

        public DelegateCommand SaveGameCommand { get; private set; }

        public DelegateCommand ExitCommand { get; private set; }

        public DelegateCommand PauseCommand { get; private set; }

        public DelegateCommand ResumeCommand { get; private set; }

        public DelegateCommand DownMove { get; private set; }

        public DelegateCommand LeftMove { get; private set; }

        public DelegateCommand RightMove { get; private set; }

        public DelegateCommand RotateMove { get; private set; }

        public DelegateCommand SmallTableCommand { get; private set; }

        public DelegateCommand MediumTableCommand { get; private set; }

        public DelegateCommand LargeTableCommand { get; private set; }

        public DelegateCommand HelpCommand { get; private set; }



        public int Points { get { return _model.getPoints(); } }

        public int Time { get { return _model.getTime(); } }

        public int Rows
        {
            get { return _model.table.getRows(); }
            set
            {
                _model.table.rows = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(GameTableRows));
            }
        }

        public int Columns
        {
            get { return _model.table.getColums(); }
            set
            {
                _model.table.columns = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(GameTableColumns));
            }
        }

        public RowDefinitionCollection GameTableRows
        {
            get => new RowDefinitionCollection(Enumerable.Repeat(new RowDefinition(GridLength.Star), Rows).ToArray());
        }

        public ColumnDefinitionCollection GameTableColumns
        {
            get => new ColumnDefinitionCollection(Enumerable.Repeat(new ColumnDefinition(GridLength.Star), Columns).ToArray());
        }

        public String Pausetext
        {
            get { return pauseText; }
            set { pauseText = value; OnPropertyChanged(); }
        }
        public bool CanSaveLoad
        {
            get { return canSaveLoad; }
            set { canSaveLoad = value; OnPropertyChanged(); }
        }

        public Color PauseColor
        {
            get { return pauseColor; }
            set { pauseColor = value; OnPropertyChanged(); }
        }

        //public Random Rand = new Random();

        public TetrisTable Table { get { return _model.table; } }
        public ObservableCollection<TetrisField> Fields { get; set; }
        //public NextBlock Generator { get { return _model.generator; } }

        public Block Current { get { return _model.current; } }

        public bool GameOver { get { return _model.IsGameOver(); } }




        public event EventHandler? NewGame;

        /// <summary>
        /// Játék betöltésének eseménye.
        /// </summary>
        public event EventHandler? LoadGame;

        /// <summary>
        /// Játék mentésének eseménye.
        /// </summary>
        public event EventHandler? SaveGame;

        /// <summary>
        /// Játékból való kilépés eseménye.
        /// </summary>
        public event EventHandler? ExitGame;

        public event EventHandler? ResumeGame;

        public event EventHandler? PauseGame;

        public event EventHandler? SmallTable;

        public event EventHandler? MediumTable;

        public event EventHandler? LargeTable;

        public event EventHandler? Help;

        public MainViewModel(State model)
        {
            _model = model;

            NewGameCommand = new DelegateCommand(param => OnNewGame());
            LoadGameCommand = new DelegateCommand(param => OnLoadGame());
            SaveGameCommand = new DelegateCommand(param => OnSaveGame());
            PauseCommand = new DelegateCommand(param => OnPauseGame());
            ExitCommand = new DelegateCommand(param => OnExitGame());
            //ResumeCommand = new DelegateCommand(param => OnResumeGame());

            SmallTableCommand = new DelegateCommand(param => OnSmallTable());
            MediumTableCommand = new DelegateCommand(param => OnMediumTable());
            LargeTableCommand = new DelegateCommand(param => OnLargeTable());

            HelpCommand = new DelegateCommand(param => OnHelp());

            DownMove = new DelegateCommand(param => OnDownMove());
            LeftMove = new DelegateCommand(param => OnLeftMove());
            RightMove = new DelegateCommand(param => OnRightMove());
            RotateMove = new DelegateCommand(param => OnRotateMove());



            /*Fields = new ObservableCollection<TetrisField>();
            Fields.Clear();


            for (int i = 2; i < _model.table.getRows(); i++)
            {
                for (int j = 0; j < _model.table.getColums(); j++)
                {
                    Fields.Add(new TetrisField
                    {
                        Color = Colors.White,
                        Id = 0,
                        Text = "kesz",
                        X = i,
                        Y = j,
                        Number = i * _model.table.getRows() + j,
                        

                    });
                }
            }*/
            TableGenerator();
            RefreshTable();

        }

        private void OnExitGame()
        {
            ExitGame?.Invoke(_model, EventArgs.Empty);
        }

        public void RefreshTable()
        {



            foreach (TetrisField field in Fields) // inicializálni kell a mezőket is
            {
                field.Id = _model.table[field.X, field.Y];
                field.Text = _model.table[field.X, field.Y].ToString();
                switch (field.Id)
                {
                    case 0:
                        field.Color = Colors.White;
                        break;
                    case 1:
                        field.Color = Colors.Red;
                        break;
                    case 2:
                        field.Color = Colors.Orange;
                        break;
                    case 3:
                        field.Color = Colors.Yellow;
                        break;
                    case 4:
                        field.Color = Colors.Green;
                        break;
                    case 5:
                        field.Color = Colors.Blue;
                        break;
                    case 6:
                        field.Color = Colors.Purple;
                        break;
                    case 7:
                        field.Color = Colors.LightBlue;
                        break;
                }

                foreach (Position pos in _model.current.tilePosition())
                {
                    if ((field.X == pos.row) && (field.Y == pos.column))
                    {
                        field.Id = _model.current.getId();
                        field.Text = _model.current.getId().ToString();
                        switch (field.Id)
                        {
                            case 0:
                                field.Color = Colors.White;
                                break;
                            case 1:
                                field.Color = Colors.Red;
                                break;
                            case 2:
                                field.Color = Colors.Orange;
                                break;
                            case 3:
                                field.Color = Colors.Yellow;
                                break;
                            case 4:
                                field.Color = Colors.Green;
                                break;
                            case 5:
                                field.Color = Colors.Blue;
                                break;
                            case 6:
                                field.Color = Colors.Purple;
                                break;
                            case 7:
                                field.Color = Colors.LightBlue;
                                break;
                        }
                    }
                }

                OnPropertyChanged(nameof(field.Color));

            }

            /*foreach (Position pos in _model.current.tilePosition())       //meg a blokk jelen helyet ird ki, utana minden jo
            {
                pos.Id = _model.table[field.X, field.Y];
                pos.Text = _model.table[field.X, field.Y].ToString();
            }*/

            OnPropertyChanged(nameof(Time));
            OnPropertyChanged(nameof(Points));
            OnPropertyChanged();

        }

        public void TableGenerator()
        {
            Fields = new ObservableCollection<TetrisField>();
            Fields.Clear();

            for (int i = 2; i < _model.table.getRows(); i++)
            {
                for (int j = 0; j < _model.table.getColums(); j++)
                {
                    Fields.Add(new TetrisField
                    {
                        Color = Colors.White,
                        Id = 0,
                        Text = "kesz",
                        X = i,
                        Y = j,
                        Number = i * _model.table.getRows() + j,


                    });
                }
            }

            OnPropertyChanged(nameof(Fields));
            RefreshTable();
        }


        public bool IsGameOver()
        {
            return _model.IsGameOver();
        }


        public void OnNewGame()
        {
            NewGame?.Invoke(this, EventArgs.Empty);

        }


        private void OnSaveGame()
        {
            SaveGame?.Invoke(this, EventArgs.Empty);
        }

        private void OnLoadGame()
        {
            LoadGame?.Invoke(this, EventArgs.Empty);
            TableGenerator();
            RefreshTable();

        }

        public void OnPauseGame()
        {
            if (Pausetext.Equals("Pause"))
            {
                Pausetext = "Continue";
                CanSaveLoad = true;
                PauseColor = Colors.Green;
                PauseGame?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                Pausetext = "Pause";
                CanSaveLoad = false;
                PauseColor = Colors.Red;
                ResumeGame?.Invoke(this, EventArgs.Empty);
            }
            OnPropertyChanged(nameof(PauseColor));
            OnPropertyChanged(nameof(Pausetext));
        }



        public void OnDownMove()
        {
            _model.moveDown();
            RefreshTable();
        }

        public void OnLeftMove()
        {
            _model.secureMoveLeft();
            RefreshTable();
        }

        public void OnRightMove()
        {
            _model.secureMoveRight();
            RefreshTable();
        }

        public void OnRotateMove()
        {
            _model.SecureRotateRight();
            RefreshTable();
        }

        public void OnSmallTable()
        {
            //_model = new State(16, 4);


            SmallTable?.Invoke(this, EventArgs.Empty);

            OnPropertyChanged(nameof(Rows));
            OnPropertyChanged(nameof(Columns));

            Pausetext = "Continue";
            CanSaveLoad = true;
            PauseGame?.Invoke(this, EventArgs.Empty);
        }

        public void OnMediumTable()
        {
            MediumTable?.Invoke(this, EventArgs.Empty);

            OnPropertyChanged(nameof(Rows));
            OnPropertyChanged(nameof(Columns));

            Pausetext = "Continue";
            CanSaveLoad = true;
            PauseGame?.Invoke(this, EventArgs.Empty);
        }

        public void OnLargeTable()
        {
            LargeTable?.Invoke(this, EventArgs.Empty);

            OnPropertyChanged(nameof(Rows));
            OnPropertyChanged(nameof(Columns));

            Pausetext = "Continue";
            CanSaveLoad = true;
            PauseGame?.Invoke(this, EventArgs.Empty);
        }

        public void OnHelp()
        {
            Help?.Invoke(this, EventArgs.Empty);
        }

    }
}
