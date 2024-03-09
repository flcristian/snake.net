using SFML.Graphics;
using SFML.System;

namespace snake_game_dotnet.GameLogic;

public class RenderService
{
    public static void DrawBackground(RenderWindow window, Shader shader)
    {
        shader.SetUniform("time", (float)DateTime.Now.TimeOfDay.TotalSeconds);
        shader.SetUniform("windowWidth", 900 * 1.0f);
        shader.SetUniform("windowHeight", 900 * 1.0f);
        window.Draw(new RectangleShape(new Vector2f(window.Size.X, window.Size.Y)), new RenderStates(shader));
    }
}