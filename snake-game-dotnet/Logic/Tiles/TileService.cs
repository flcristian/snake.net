using SFML.Graphics;
using SFML.System;
using snake_game_dotnet.Logic.Game.Window;
using snake_game_dotnet.Logic.Levels.Models;
using snake_game_dotnet.Logic.Levels.Services;
using snake_game_dotnet.Logic.Shaders.Services;

namespace snake_game_dotnet.Logic.Tiles;

public class TileService
{
    private static RenderWindow _window = WindowServiceSingleton.Instance.WindowInstance;
    
    public static void DrawTileGrid()
    {
        Level level = LevelServiceSingleton.Instance.LevelInstance;
        Shader shader = ShaderServiceSingleton.Instance.GetShader(level.Name, "TILE");
        RectangleShape tile = new RectangleShape(new Vector2f(level.TileSize, level.TileSize));
        
        shader.SetUniform("tileSize", level.TileSize * 1.0f);
        for (int i = 0; i < level.Width; i++)
        {
            for (int j = 0; j < level.Height; j++)
            {
                shader.SetUniform("tileX", i + 1.0f);
                shader.SetUniform("tileY", j + 1.0f);
                    
                RenderStates tileRenderStates = new RenderStates(shader);
            
                tile.FillColor = Color.White;
                tile.Position = new Vector2f(i * level.TileSize, (level.Height - j - 1) * level.TileSize);
                _window.Draw(tile, tileRenderStates);
            }
        }
    }
}