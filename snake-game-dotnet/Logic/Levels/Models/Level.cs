using SFML.Graphics;

namespace snake_game_dotnet.Logic.Levels.Models;

public class Level
{
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int TileSize { get; set; }
    public int SnakeLength { get; set; }
    public Color SnakeHeadColor { get; set; }
    public Color SnakeBodyColor { get; set; }
    public List<string> Shaders { get; set; }
} 