using SFML.Graphics;
using SFML.System;
using snake_game_dotnet.Logic.Levels.Models;

namespace snake_game_dotnet.Logic.Tiles;

public class TileService
{
    public static void DrawTileGrid(RenderWindow window, Level level, Shader shader)
    {
        RectangleShape tile = new RectangleShape(new Vector2f(level.TileSize, level.TileSize));
        
        for (float i = 0f; i < level.SizeX(); i++)
        {
            for (float j = 0f; j < level.SizeY(); j++)
            {
                shader.SetUniform("tileSize", level.TileSize * 1.0f);
                shader.SetUniform("tileX", i + 1f);
                shader.SetUniform("tileY", j + 1f);
                    
                RenderStates tileRenderStates = new RenderStates(shader);
            
                tile.FillColor = Color.White;
                tile.Position = new Vector2f(i * level.TileSize, (level.SizeY() - 1 - j) * level.TileSize);
                window.Draw(tile, tileRenderStates);
            }
        }
    }
}