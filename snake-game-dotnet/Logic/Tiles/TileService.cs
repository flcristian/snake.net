using SFML.Graphics;
using SFML.System;

namespace snake_game_dotnet.Logic.Tiles;

public class TileService
{
    public static void DrawTileGrid(float sizeX, float sizeY, float tileSize, Shader shader, RenderWindow window)
    {
        RectangleShape tile = new RectangleShape(new Vector2f(tileSize, tileSize));
        
        for (float i = 0f; i < sizeX; i++)
        {
            for (float j = 0f; j < sizeY; j++)
            {
                shader.SetUniform("tileSize", tileSize);
                shader.SetUniform("tileX", i + 1f);
                shader.SetUniform("tileY", j + 1f);
                    
                RenderStates tileRenderStates = new RenderStates(shader);
            
                tile.FillColor = Color.White;
                tile.Position = new Vector2f(i * tileSize, (sizeY - 1 - j) * tileSize);
                window.Draw(tile, tileRenderStates);
            }
        }
    }
}