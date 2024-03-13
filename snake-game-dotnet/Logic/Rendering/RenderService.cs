using SFML.Graphics;
using SFML.System;
using snake_game_dotnet.Logic.Game.Window;
using snake_game_dotnet.Logic.Levels.Models;
using snake_game_dotnet.Logic.Levels.Services;
using snake_game_dotnet.Logic.Shaders.Services;
using snake_game_dotnet.Logic.Snake.Models;
using snake_game_dotnet.Logic.Snake.Services;
using snake_game_dotnet.System;

namespace snake_game_dotnet.Logic.Rendering;

public class RenderService
{
    private static RenderWindow _window = WindowServiceSingleton.Instance.WindowInstance;
    
    public static void DrawBackground()
    {
        Level level = LevelServiceSingleton.Instance.LevelInstance;
        Shader shader = ShaderServiceSingleton.Instance.GetShader(level.Name, "BACKGROUND");
        
        shader.SetUniform("time", (float)DateTime.Now.TimeOfDay.TotalSeconds * 1.0f);
        shader.SetUniform("windowWidth", _window.Size.X);
        shader.SetUniform("windowHeight", _window.Size.Y);
        _window.Draw(new RectangleShape(new Vector2f(_window.Size.X, _window.Size.Y)), new RenderStates(shader));
    }

    public static void DrawSnake()
    {
        Level level = LevelServiceSingleton.Instance.LevelInstance;
        SnakeHead? snake = SnakeServiceSingleton.Instance.SnakeInstance; 
        
        if (snake == null)
        {
            throw new Exception(Constants.SNAKE_NOT_INITIATED);
        }
        
        RectangleShape snakeRectangle = new RectangleShape(new Vector2f(level.TileSize, level.TileSize));
        snakeRectangle.Position = new Vector2f(snake.Position.X * level.TileSize, (level.Height - snake.Position.Y - 1) * level.TileSize);
        snakeRectangle.FillColor = snake.Color;
        _window.Draw(snakeRectangle);

        for (int i = 0; i < snake.Body.Count; i++)
        {
            SnakeBody body = snake.Body[i];
            snakeRectangle.Position = new Vector2f(body.Position.X * level.TileSize, (level.Height - body.Position.Y - 1) * level.TileSize);
            snakeRectangle.FillColor = body.Color;
            _window.Draw(snakeRectangle);
        }
    }
}