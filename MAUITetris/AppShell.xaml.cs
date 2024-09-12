using TetrisModel.Persistence;
using TetrisModel.Model;
using MAUITetris.View;
using MAUITetris.ViewModel;

namespace MAUITetris;

public partial class AppShell : Shell
{
    private AppShell _appShell;
    private State _model;
    private MainViewModel _viewModel;
    //private MainPage _view;

    ISaveTo _saver;

    private readonly IDispatcherTimer _timer;

    private IStore _store;
    private readonly StoredGameBrowserModel _storedGameBrowserModel;
    private readonly StoredGameBrowserViewModel _storedGameBrowserViewModel;

    public AppShell(IStore store, ISaveTo saver, State model, MainViewModel viewModel)
    {
        InitializeComponent();

        _store = store;
        _saver = saver;
        _model = model;
        _viewModel = viewModel;

        _timer = Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromMilliseconds(700);
        _timer.Tick += Timer_Tick;

        _viewModel.NewGame += ViewModel_NewGame;
        _viewModel.PauseGame += ViewModel_PauseGame;
        _viewModel.ResumeGame += ViewModel_ResumeGame;
        _viewModel.LoadGame += ViewModel_LoadGame;
        _viewModel.SaveGame += ViewModel_SaveGame;
        _viewModel.SmallTable += ViewModel_SmallTable;
        _viewModel.MediumTable += ViewModel_MediumTable;
        _viewModel.LargeTable += ViewModel_LargeTable;
        _viewModel.Help += ViewModel_Help;
        _viewModel.ExitGame += ViewModel_ExitGame;

        // a játékmentések kezelésének összeállítása
        _storedGameBrowserModel = new StoredGameBrowserModel(_store);
        _storedGameBrowserViewModel = new StoredGameBrowserViewModel(_storedGameBrowserModel);
        _storedGameBrowserViewModel.GameLoading += StoredGameBrowserViewModel_GameLoading;
        _storedGameBrowserViewModel.GameSaving += StoredGameBrowserViewModel_GameSaving;


    }

    private async void ViewModel_ExitGame(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage
        {
            BindingContext = _viewModel
        }); // átnavigálunk a beállítások lapra
    }

    private void ViewModel_NewGame(object sender, EventArgs e)
    {
        _model.ResetGame();
        _timer.Start();
        _viewModel.Pausetext = "Pause";
    }

    private void ViewModel_PauseGame(object sender, EventArgs e)
    {
        _timer.Stop();
        _viewModel.Pausetext = "Continue";
    }

    private void ViewModel_ResumeGame(object sender, EventArgs e)
    {
        _timer.Start();
        _viewModel.Pausetext = "Pause";
    }

    private void ViewModel_LoadGame(object sender, EventArgs e)
    {
        _model = _saver.ReadState();

        _viewModel = new ViewModel.MainViewModel(_model);
        _viewModel.NewGame += ViewModel_NewGame;
        _viewModel.PauseGame += ViewModel_PauseGame;
        _viewModel.ResumeGame += ViewModel_ResumeGame;
        _viewModel.LoadGame += ViewModel_LoadGame;
        _viewModel.SaveGame += ViewModel_SaveGame;
        _viewModel.SmallTable += ViewModel_SmallTable;
        _viewModel.MediumTable += ViewModel_MediumTable;
        _viewModel.LargeTable += ViewModel_LargeTable;
        _viewModel.Help += ViewModel_Help;
        _viewModel.ExitGame += ViewModel_ExitGame;

        BindingContext = _viewModel;

        _viewModel.TableGenerator();
        //_timer.Start();
        _viewModel.Pausetext = "Pause";
        _viewModel.RefreshTable();
    }

    private void ViewModel_SaveGame(object sender, EventArgs e)
    {
        _timer.Stop();
        _saver.WriteState(_model);
        _viewModel.Pausetext = "Pause";
        //_timer.Start();
    }

    private void ViewModel_SmallTable(object sender, EventArgs e)
    {
        _model = new State(16, 4);

        _viewModel = new MainViewModel(_model);
        _viewModel.NewGame += ViewModel_NewGame;
        _viewModel.PauseGame += ViewModel_PauseGame;
        _viewModel.ResumeGame += ViewModel_ResumeGame;
        _viewModel.LoadGame += ViewModel_LoadGame;
        _viewModel.SaveGame += ViewModel_SaveGame;
        _viewModel.SmallTable += ViewModel_SmallTable;
        _viewModel.MediumTable += ViewModel_MediumTable;
        _viewModel.LargeTable += ViewModel_LargeTable;
        _viewModel.Help += ViewModel_Help;
        _viewModel.ExitGame += ViewModel_ExitGame;

        BindingContext = _viewModel;

        _model.ResetGame();
        _viewModel.TableGenerator();
        _viewModel.RefreshTable();
    }

    private void ViewModel_MediumTable(object sender, EventArgs e)
    {
        _model = new State(16, 8);

        _viewModel = new MainViewModel(_model);
        _viewModel.NewGame += ViewModel_NewGame;
        _viewModel.PauseGame += ViewModel_PauseGame;
        _viewModel.ResumeGame += ViewModel_ResumeGame;
        _viewModel.LoadGame += ViewModel_LoadGame;
        _viewModel.SaveGame += ViewModel_SaveGame;
        _viewModel.SmallTable += ViewModel_SmallTable;
        _viewModel.MediumTable += ViewModel_MediumTable;
        _viewModel.LargeTable += ViewModel_LargeTable;
        _viewModel.Help += ViewModel_Help;
        _viewModel.ExitGame += ViewModel_ExitGame;

        BindingContext = _viewModel;

        _model.ResetGame();
        _viewModel.TableGenerator();
        _viewModel.RefreshTable();
    }

    private void ViewModel_LargeTable(object sender, EventArgs e)
    {
        _model = new State(16, 12);

        _viewModel = new MainViewModel(_model);
        _viewModel.NewGame += ViewModel_NewGame;
        _viewModel.PauseGame += ViewModel_PauseGame;
        _viewModel.ResumeGame += ViewModel_ResumeGame;
        _viewModel.LoadGame += ViewModel_LoadGame;
        _viewModel.SaveGame += ViewModel_SaveGame;
        _viewModel.SmallTable += ViewModel_SmallTable;
        _viewModel.MediumTable += ViewModel_MediumTable;
        _viewModel.LargeTable += ViewModel_LargeTable;
        _viewModel.Help += ViewModel_Help;
        _viewModel.ExitGame += ViewModel_ExitGame;

        BindingContext = _viewModel;

        _model.ResetGame();
        _viewModel.TableGenerator();
        _viewModel.RefreshTable();
    }

    private void ViewModel_Help(object sender, EventArgs e)
    {
        _timer.Stop();
        _viewModel.Pausetext = "Continue";
        _viewModel.PauseColor = Colors.Green;
        DisplayAlert("Help", "A,D - Movement, W - Rotation, S - Drop 1 Row", "OK");
    }

    private async void Timer_Tick(object sender, EventArgs e)
    {
        _model.AddTime();
        _model.moveDown();

        _viewModel.RefreshTable();

        if (_model.IsGameOver())
        {
            _timer.Stop();
            await DisplayAlert("Game Over", "Game Over! \n Points gathered: " + _model.points + "\n Time survived: " + _model.time, "OK");
        }
    }
    /// <summary>
    ///     Elindtja a játék léptetéséhez használt időzítőt.
    /// </summary>
    internal void StartTimer() => _timer.Start();

    /// <summary>
    ///     Megállítja a játék léptetéséhez használt időzítőt.
    /// </summary>
    internal void StopTimer() => _timer.Stop();

    /// <summary>
    ///     Betöltés végrehajtásának eseménykezelője.
    /// </summary>
    private async void StoredGameBrowserViewModel_GameLoading(object? sender, StoredGameEventArgs e)
    {
        await Navigation.PopAsync(); // visszanavigálunk

        // betöltjük az elmentett játékot, amennyiben van
        try
        {
            _saver.ReadState();

            // sikeres betöltés
            await Navigation.PopAsync(); // visszanavigálunk a játék táblára
            await DisplayAlert("Sudoku játék", "Sikeres betöltés.", "OK");

            // csak akkor indul az időzítő, ha sikerült betölteni a játékot
            StartTimer();
        }
        catch
        {
            await DisplayAlert("Sudoku játék", "Sikertelen betöltés.", "OK");
        }
    }

    /// <summary>
    ///     Mentés végrehajtásának eseménykezelője.
    /// </summary>
    private async void StoredGameBrowserViewModel_GameSaving(object? sender, StoredGameEventArgs e)
    {
        await Navigation.PopAsync(); // visszanavigálunk
        StopTimer();

        try
        {
            // elmentjük a játékot
            _saver.WriteState(_model);
            await DisplayAlert("Sudoku játék", "Sikeres mentés.", "OK");
        }
        catch
        {
            await DisplayAlert("Sudoku játék", "Sikertelen mentés.", "OK");
        }
    }

}
