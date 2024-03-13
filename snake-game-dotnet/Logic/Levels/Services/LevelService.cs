using System.Timers;
using Newtonsoft.Json;
using SFML.Graphics;
using SFML.Window;
using snake_game_dotnet.Logic.Game.Window;
using snake_game_dotnet.Logic.Levels.Models;
using snake_game_dotnet.Logic.Rendering;
using snake_game_dotnet.Logic.Shaders.Services;
using snake_game_dotnet.Logic.Shaders.Services.Interfaces;
using snake_game_dotnet.Logic.Snake.Services;
using snake_game_dotnet.Logic.Tiles;
using snake_game_dotnet.Logic.Utility;
using snake_game_dotnet.System;
using Timer = System.Timers.Timer;

namespace snake_game_dotnet.Logic.Levels.Services;

public class LevelService
{
    private Level _levelInstance;
    private List<Level> _levels { get; set; }
    private WindowService _windowService;
    private IShaderService _shaderService;
    private SnakeService _snakeService;
    private Timer _timer;
    private bool _paused;
    private bool _inverted;

    public Level LevelInstance => _levelInstance;

    public LevelService()
    {
        _shaderService = ShaderServiceSingleton.Instance;
        _snakeService = SnakeServiceSingleton.Instance;
        _windowService = WindowServiceSingleton.Instance;
        LoadLevelsFromJson();
    }

    // PUBLIC METHODS
    public void LoadLevel(string levelName)
    {
        _levelInstance = GetLevel(levelName);
        LoadShaders();
        
        _windowService.ResizeWindow(_levelInstance.Width * _levelInstance.TileSize, _levelInstance.Height * _levelInstance.TileSize);

        _snakeService.SpawnSnake();

        _timer = new Timer(500);
        _timer.Elapsed += OnTimedEvent!;
        _timer.Enabled = true;
        
        _windowService.WindowInstance.KeyPressed += WindowKeyPressed!;
        
        while (_windowService.WindowInstance.IsOpen)
        {
            _windowService.WindowInstance.DispatchEvents();
            _windowService.WindowInstance.Clear(Color.Black);
            
            // RENDERING
            RenderService.DrawBackground();
            TileService.DrawTileGrid();
            RenderService.DrawSnake();
        
            _windowService.WindowInstance.Display();
        }

        _timer.Enabled = false;
        UnloadShaders();
    }
    
    private Level GetLevel(string levelName)
    {
        Level level = _levels.Find(level => level.Name.Equals(levelName))!;

        if (level.Equals(null))
        {
            throw new Exception(Constants.LEVEL_NOT_FOUND);
        }

        return level;
    }

    // PRIVATE METHODS
    private void LoadLevelsFromJson()
    {
        string json = File.ReadAllText(Constants.LEVELS_FILE_PATH);

        _levels = JsonConvert.DeserializeObject<List<Level>>(json)!;
    }
    
    private void LoadShaders()
    {
        _levelInstance.Shaders.ForEach(shader => _shaderService.AddShader(_levelInstance.Name, shader));
    }

    private void UnloadShaders()
    {
        _levelInstance.Shaders.ForEach(shader => _shaderService.DeleteShader(_levelInstance.Name, shader));
    }
    
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        _snakeService.MoveSnake();
    }
    
    private void WindowKeyPressed(object sender, KeyEventArgs e)
    {
        if (e.Code == Keyboard.Key.Space)
        {
            if (_paused)
            {
                UnpauseGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (!_paused)
        {
            switch (e.Code)
            {
                case Keyboard.Key.W:
                    _snakeService.ChangeFacingDirection(Direction.Up, _inverted);
                    break;
                case Keyboard.Key.D:
                    _snakeService.ChangeFacingDirection(Direction.Right, _inverted);
                    break;
                case Keyboard.Key.S:
                    _snakeService.ChangeFacingDirection(Direction.Down, _inverted);
                    break;
                case Keyboard.Key.A:
                    _snakeService.ChangeFacingDirection(Direction.Left, _inverted);
                    break;
            }
        }
    }

    private void PauseGame()
    {
        _timer.Enabled = false;
        _paused = true;
    }

    private void UnpauseGame()
    {
        _timer.Enabled = true;
        _paused = false;
    }
}