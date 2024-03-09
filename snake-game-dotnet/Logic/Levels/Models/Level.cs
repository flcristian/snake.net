using SFML.Graphics;

namespace snake_game_dotnet.Logic.Levels.Models;

public class Level
{
    public string Name { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float TileSize { get; set; }
    public int SnakeLength { get; set; }
    public Color SnakeHeadColor { get; set; }
    public Color SnakeBodyColor { get; set; }
    public List<string> Shaders { get; set; }

    public int SizeX()
    {
        return (int)Width / (int)TileSize;
    }

    public int SizeY()
    {
        return (int)Height / (int)TileSize;
    }
} 