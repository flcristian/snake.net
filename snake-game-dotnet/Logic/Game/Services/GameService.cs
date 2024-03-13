using SFML.Graphics;
using snake_game_dotnet.Logic.Levels.Services;
using Timer = System.Timers.Timer;

namespace snake_game_dotnet.Logic.Game.Services;

public class GameService
{
    private RenderWindow _window;
    private LevelService _levelService;

    public GameService()
    {
        _levelService = LevelServiceSingleton.Instance;
    }
    
    public void StartGame()
    {
        _levelService.LoadLevel("LEVEL_1");
    }
}