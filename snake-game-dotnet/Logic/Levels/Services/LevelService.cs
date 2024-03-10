using System.Timers;
using Newtonsoft.Json;
using SFML.Graphics;
using snake_game_dotnet.Logic.Levels.Models;
using snake_game_dotnet.Logic.Levels.Services.Interfaces;
using snake_game_dotnet.Logic.Rendering;
using snake_game_dotnet.Logic.Shaders.Services;
using snake_game_dotnet.Logic.Shaders.Services.Interfaces;
using snake_game_dotnet.Logic.Snake.Services;
using snake_game_dotnet.Logic.Tiles;
using snake_game_dotnet.System;

namespace snake_game_dotnet.Logic.Levels.Services;

public class LevelService : ILevelService
{
    private IShaderService _shaderService;
    private SnakeService _snakeService;
    
    public List<Level> Levels { get; set; }

    public LevelService()
    {
        _shaderService = ShaderServiceSingleton.Instance;
        _snakeService = SnakeServiceSingleton.Instance;
        LoadFromJson();
    }

    // PUBLIC METHODS
    public void LoadLevel(RenderWindow window, string levelName)
    {
        Level level = GetLevel(levelName);
        LoadShaders(level);
        
        Shader tileShader = _shaderService.GetShader(level.Name, "TILE");

        _snakeService.SpawnSnake(level);

        global::System.Timers.Timer timer = new global::System.Timers.Timer(1000);
        timer.Elapsed += (sender, e) => OnTimedEvent(sender!, e, level);
        timer.Enabled = true;
        
        while (window.IsOpen)
        {
            window.DispatchEvents();
            window.Clear(Color.Black);
            
            // RENDERING
            RenderService.DrawBackground(window, level, _shaderService.GetShader(level.Name, "BACKGROUND"));
            TileService.DrawTileGrid(window, level, tileShader);
            RenderService.DrawSnake(window, level, _snakeService.SnakeInstance!);
        
            window.Display();
        }

        timer.Enabled = false;
        UnloadShaders(level);
    }
    
    public Level GetLevel(string levelName)
    {
        Level level = Levels.Find(level => level.Name.Equals(levelName))!;

        if (level.Equals(null))
        {
            throw new Exception(Constants.LEVEL_NOT_FOUND);
        }

        return level;
    }

    // PRIVATE METHODS
    private void LoadFromJson()
    {
        string json = File.ReadAllText(Constants.LEVELS_FILE_PATH);

        Levels = JsonConvert.DeserializeObject<List<Level>>(json)!;
    }
    
    private void LoadShaders(Level level)
    {
        level.Shaders.ForEach(shader => _shaderService.AddShader(level.Name, shader));
    }

    private void UnloadShaders(Level level)
    {
        level.Shaders.ForEach(shader => _shaderService.DeleteShader(level.Name, shader));
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e, Level level)
    {
        _snakeService.MoveSnake(level);
    }
}