using SFML.Graphics;
using SFML.System;
using snake_game_dotnet.Logic.Utility;

namespace snake_game_dotnet.Logic.Snake.Models;

public class SnakeBody
{
    public Vector2i Position { get; set; }
    public Direction Facing { get; set; }
    public Color Color { get; set; }
    public SnakeBody? Previous { get; set; }

    public SnakeBody(int x, int y, Direction facing, Color color)
    {
        Position = new Vector2i(x, y);
        Facing = facing;
        Color = color;
        Previous = null;
    }
    
    public SnakeBody(int x, int y, Direction facing, Color color, SnakeBody previous)
    {
        Position = new Vector2i(x, y);
        Facing = facing;
        Color = color;
        Previous = previous;
    }
}