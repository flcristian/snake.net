using SFML.Graphics;
using SFML.System;
using snake_game_dotnet.Logic.Levels.Models;
using snake_game_dotnet.Logic.Snake.Models;
using snake_game_dotnet.System;

namespace snake_game_dotnet.Logic.Rendering;

public class RenderService
{
    public static void DrawBackground(RenderWindow window, Level level, Shader shader)
    {
        shader.SetUniform("time", (float)DateTime.Now.TimeOfDay.TotalSeconds * 1.0f);
        shader.SetUniform("windowWidth", level.Width);
        shader.SetUniform("windowHeight", level.Height);
        window.Draw(new RectangleShape(new Vector2f(window.Size.X, window.Size.Y)), new RenderStates(shader));
    }

    public static void DrawSnake(RenderWindow window, Level level, SnakeHead? snake)
    {
        if (snake == null)
        {
            throw new Exception(Constants.SNAKE_NOT_INITIATED);
        }
        
        RectangleShape snakeRectangle = new RectangleShape(new Vector2f(level.TileSize, level.TileSize));
        snakeRectangle.Position = new Vector2f(snake.Position.X * level.TileSize, snake.Position.Y * level.TileSize);
        snakeRectangle.FillColor = snake.Color;
        window.Draw(snakeRectangle);

        foreach (SnakeBody body in snake.Body)
        {
            snakeRectangle.Position = new Vector2f(body.Position.X * level.TileSize, body.Position.Y * level.TileSize);
            snakeRectangle.FillColor = body.Color;
            window.Draw(snakeRectangle);
        }
    }
}