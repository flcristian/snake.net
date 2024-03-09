using Newtonsoft.Json;
using SFML.Graphics;
using snake_game_dotnet.GameLogic;
using snake_game_dotnet.Logic.Levels.Interfaces;
using snake_game_dotnet.Logic.Levels.Models;
using snake_game_dotnet.Logic.Shaders;
using snake_game_dotnet.Logic.Shaders.Interfaces;
using snake_game_dotnet.Logic.Tiles;
using snake_game_dotnet.System;

namespace snake_game_dotnet.Logic.Levels;

public class LevelService : ILevelService
{
    private IShaderService _shaderService;
    
    public List<Level> Levels { get; set; }

    public LevelService()
    {
        _shaderService = ShaderServiceSingleton.Instance;
        LoadFromJson();
    }

    // PUBLIC METHODS
    public void LoadLevel(RenderWindow window, string levelName)
    {
        Level level = GetLevel(levelName);
        LoadShaders(level);
        
        Shader tileShader = _shaderService.GetShader(level.Name, level.TileShader);
            
        float tileSize = level.TileSize * 1.0f;
        float sizeX = level.Width / tileSize;
        float sizeY = level.Height / tileSize;
        
        while (window.IsOpen)
        {
            window.DispatchEvents();
            window.Clear(Color.Black);
            
            RenderService.DrawBackground(window, _shaderService.GetShader(level.Name, level.BackgroundShader));
            TileService.DrawTileGrid(sizeX, sizeY, tileSize, tileShader, window);
        
            window.Display();
        }
        
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
        _shaderService.AddShader(level.Name, level.BackgroundShader);
        _shaderService.AddShader(level.Name, level.TileShader);
    }

    private void UnloadShaders(Level level)
    {
        _shaderService.DeleteShader(level.Name, level.BackgroundShader);
        _shaderService.DeleteShader(level.Name, level.TileShader);
    }
}