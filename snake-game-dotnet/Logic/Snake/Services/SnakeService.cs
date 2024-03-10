using SFML.Graphics;
using SFML.System;
using snake_game_dotnet.Logic.Levels.Models;
using snake_game_dotnet.Logic.Snake.Models;
using snake_game_dotnet.Logic.Utility;
using snake_game_dotnet.System;

namespace snake_game_dotnet.Logic.Snake.Services;

public class SnakeService
{
    public SnakeHead? SnakeInstance { get; set; }
    
    public void SpawnSnake(Level level)
    {
        SnakeInstance = new SnakeHead(level.SizeX(), level.SizeY(), level.SnakeLength, level.SnakeHeadColor, level.SnakeBodyColor);
    }

    public void MoveSnake(Level level)
    {
        if (SnakeInstance == null)
        {
            throw new Exception(Constants.SNAKE_NOT_INITIATED);
        }

        MoveBody();
        switch (SnakeInstance.Facing)
        {
            case Direction.Up:
                SnakeInstance.Position = new Vector2i(SnakeInstance.Position.X, SnakeInstance.Position.Y + 1);
                break;
            case Direction.Right:
                SnakeInstance.Position = new Vector2i(SnakeInstance.Position.X + 1, SnakeInstance.Position.Y);
                break;
            case Direction.Down:
                SnakeInstance.Position = new Vector2i(SnakeInstance.Position.X, SnakeInstance.Position.Y - 1);
                break;
            case Direction.Left:
                SnakeInstance.Position = new Vector2i(SnakeInstance.Position.X - 1, SnakeInstance.Position.Y);
                break;
        }
    }

    private void MoveBody()
    {
        for (int i = 0; i < SnakeInstance!.Body.Count - 1; i++)
        {
            SnakeInstance.Body[i].Position = SnakeInstance.Body[i + 1].Position;
        }
        SnakeInstance.Body[^1].Position = SnakeInstance.Position;
    }
}