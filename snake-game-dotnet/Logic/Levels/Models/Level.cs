using SFML.Graphics;

namespace snake_game_dotnet.Logic.Levels.Models;

public class Level
{
    public string Name { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float TileSize { get; set; }
    public string BackgroundShader { get; set; }
    public string TileShader { get; set; }
}