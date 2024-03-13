using SFML.System;
using snake_game_dotnet.Logic.Levels.Models;
using snake_game_dotnet.Logic.Levels.Services;
using snake_game_dotnet.Logic.Snake.Models;
using snake_game_dotnet.Logic.Utility;
using snake_game_dotnet.System;

namespace snake_game_dotnet.Logic.Snake.Services;

public class SnakeService
{
    private SnakeHead? _snakeInstance;

    public SnakeHead? SnakeInstance => _snakeInstance;

    public void SpawnSnake()
    {
        Level level = LevelServiceSingleton.Instance.LevelInstance;
        _snakeInstance = new SnakeHead(level.Width, level.Height, level.SnakeLength, level.SnakeHeadColor, level.SnakeBodyColor);
    }

    public void MoveSnake()
    {
        if (_snakeInstance == null)
        {
            throw new Exception(Constants.SNAKE_NOT_INITIATED);
        }
        
        MoveBody();
        _snakeInstance.Position = NextHeadPosition(_snakeInstance.Facing);
    }

    public void SnakeGrow()
    {
        if (_snakeInstance == null)
        {
            throw new Exception(Constants.SNAKE_NOT_INITIATED);
        }

        SnakeBody add = new SnakeBody(_snakeInstance.Body[0].Position.X, _snakeInstance.Body[0].Position.Y, _snakeInstance.Body[0].Facing, _snakeInstance.Body[0].Color);
        MoveBody();
        _snakeInstance.Body.Insert(0, add);
        _snakeInstance.Position = NextHeadPosition(_snakeInstance.Facing);
    }

    public bool CheckIfSnakeOnPosition(Vector2i position)
    {
        if (_snakeInstance == null)
        {
            return false;
        }
        
        if (_snakeInstance.Position.Equals(position))
        {
            return true;
        }

        foreach (SnakeBody body in _snakeInstance.Body)
        {
            if (body.Position.Equals(position))
            {
                return true;
            }
        }

        return false;
    }

    private Vector2i NextHeadPosition(Direction direction)
    {
        if (_snakeInstance == null)
        {
            throw new Exception(Constants.SNAKE_NOT_INITIATED);
        }
        
        switch (direction)
        {
            case Direction.Up:
                return new Vector2i(_snakeInstance.Position.X, ClampToGrid(false, _snakeInstance.Position.Y + 1));
            case Direction.Right:
                return new Vector2i(ClampToGrid(true, _snakeInstance.Position.X + 1), _snakeInstance.Position.Y);
            case Direction.Down:
                return new Vector2i(_snakeInstance.Position.X, ClampToGrid(false, _snakeInstance.Position.Y - 1));
            default:
                return new Vector2i(ClampToGrid(true, _snakeInstance.Position.X - 1), _snakeInstance.Position.Y);
        }
    }
    
    private void MoveBody()
    {
        for (int i = 0; i < _snakeInstance!.Body.Count - 1; i++)
        {
            _snakeInstance.Body[i].Position = _snakeInstance.Body[i + 1].Position;
        }
        _snakeInstance.Body[^1].Position = _snakeInstance.Position;
    }

    private int ClampToGrid(bool horizontal, int value)
    {
        Level level = LevelServiceSingleton.Instance.LevelInstance;
        if (value < 0) return (horizontal ? level.Width : level.Height) - 1;

        return value % (horizontal ? level.Width : level.Height);
    }

    public void ChangeFacingDirection(Direction direction, bool inverted)
    {
        if (_snakeInstance == null)
        {
            throw new Exception(Constants.SNAKE_NOT_INITIATED);
        }

        if (NextHeadPosition(direction) == _snakeInstance.Body.Last().Position)
        {
            return;
        }

        if (inverted)
        {
            _snakeInstance.Facing = OppositeDirection(direction);
            return;
        }

        _snakeInstance.Facing = direction;
    }

    private Direction OppositeDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return Direction.Down;
            case Direction.Right:
                return Direction.Left;
            case Direction.Down:
                return Direction.Up;
            default:
                return Direction.Right;
        }
    }
}