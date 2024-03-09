using SFML.Graphics;
using snake_game_dotnet.Logic.Levels.Models;
using snake_game_dotnet.Logic.Snake.Models;

namespace snake_game_dotnet.Logic.Snake.Services;

public class SnakeService
{
    public SnakeHead SnakeInstance { get; set; }
    
    public void SpawnSnake(Level level)
    {
        SnakeInstance = new SnakeHead(level.SizeX(), level.SizeY(), level.SnakeLength, level.SnakeHeadColor, level.SnakeBodyColor);
    }
}