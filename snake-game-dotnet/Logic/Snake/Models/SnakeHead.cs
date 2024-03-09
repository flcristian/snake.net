using System.Collections;
using SFML.Graphics;
using SFML.System;
using snake_game_dotnet.Logic.Utility;

namespace snake_game_dotnet.Logic.Snake.Models;

public class SnakeHead
{
    public Vector2i Position { get; set; }
    public Direction Facing { get; set; }
    public Queue<SnakeBody> Body { get; set; }
    public Color Color { get; set; }

    public SnakeHead(float levelSizeX, float levelSizeY, int length, Color headColor, Color bodyColor)
    {
        Position = new Vector2i((int)levelSizeX / 2, (int)levelSizeY / 2);
        Facing = Direction.Left;

        Body = new Queue<SnakeBody>();
        
        Body.Enqueue(new SnakeBody(Position.X + length - 1, Position.Y, Direction.Left, bodyColor));

        while (Body.Count < length - 1)
        {
            SnakeBody previous = Body.Peek();
            Body.Enqueue(new SnakeBody(previous.Position.X - 1, Position.Y, Direction.Left, bodyColor, previous));
        }
        
        Color = headColor;
    }
}