using TetrisModel.Model;
using TetrisModel.Persistence;
using MAUITetris.View;
using MAUITetris.ViewModel;
using MAUITetris.Persistence;

namespace MAUITetris;

 
public partial class App : Application
{

    private const string SuspendedGameSavePath = "SuspendedGame";

    private readonly AppShell _appShell;
	private readonly State _model;
	private readonly MainViewModel _viewModel;
	//private MainPage _view;

	ISaveTo _saver;
	IStore _store;

	public App()
	{
		InitializeComponent();

		_store = new TetrisStore();
		_saver = new SaveToFile(Path.Combine(FileSystem.Current.AppDataDirectory,"save.txt"));

		_model = new State();
		_viewModel = new MainViewModel(_model);

		_appShell = new AppShell(_store, _saver, _model, _viewModel)
		{
			BindingContext = _viewModel
		};
		MainPage = _appShell;



		//_appShell = new AppShell();
	}

    protected override Window CreateWindow(IActivationState? activationState)
    {
        Window window = base.CreateWindow(activationState);

        window.Created += (s, e) =>
        {
            // új játékot indítunk
            _model.ResetGame();
            _appShell.StartTimer();
        };

        window.Activated += (s, e) =>
        {
            if (!File.Exists(Path.Combine(FileSystem.AppDataDirectory, SuspendedGameSavePath)))
                return;

            Task.Run(() =>
            {
                // betöltjük a felfüggesztett játékot, amennyiben van
                try
                {
                    _saver.ReadState();

                    // csak akkor indul az időzítő, ha sikerült betölteni a játékot
                    _appShell.StartTimer();
                }
                catch
                {
                }
            });
        };

        window.Stopped += (s, e) =>
        {
            Task.Run(() =>
            {
                try
                {
                    // elmentjük a jelenleg folyó játékot
                    _appShell.StopTimer();
                    _saver.WriteState(_model);
                }
                catch
                {
                }
            });
        };

        return window;
    }
}
