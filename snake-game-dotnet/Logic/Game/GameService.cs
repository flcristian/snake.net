using SFML.Graphics;
using SFML.System;
using SFML.Window;
using snake_game_dotnet.Logic.Levels;
using snake_game_dotnet.Logic.Levels.Services;
using snake_game_dotnet.Logic.Levels.Services.Interfaces;
using snake_game_dotnet.System;

namespace snake_game_dotnet.Logic.Game;

public class GameService
{
    private RenderWindow _window;
    private ILevelService _levelService;

    public GameService()
    {
        _levelService = LevelServiceSingleton.Instance;
        Initialize();
    }
    
    public void StartGame()
    {
        _levelService.LoadLevel(_window, "LEVEL_1");
    }
    
    public void ResizeWindow(uint width, uint height)
    {
        _window.Size = new Vector2u(width, height);
    }
    
    private void Initialize()
    {
        _window = new RenderWindow(new VideoMode(900, 900), Constants.GAME_TITLE);

        _window.Resized += OnWindowResized;
    }
    
    private void OnWindowResized(object sender, SizeEventArgs e)
    {
        FloatRect visibleArea = new FloatRect(0, 0, e.Width, e.Height);
        View view = new View(visibleArea);

        view.Center = new Vector2f(e.Width / 2f, e.Height / 2f);

        _window.SetView(view);
    }
}