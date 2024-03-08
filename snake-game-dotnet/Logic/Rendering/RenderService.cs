using SFML.Graphics;
using SFML.System;
using snake_game_dotnet.System;

namespace snake_game_dotnet.GameLogic;

public class RenderService
{
    public static void DrawBackground(RenderWindow window, Shader shader)
    {
        shader.SetUniform("time", (float)DateTime.Now.TimeOfDay.TotalSeconds);
        shader.SetUniform("windowWidth", Constants.BASE_WIDTH * 1.0f);
        shader.SetUniform("windowHeight", Constants.BASE_HEIGHT * 1.0f);
        window.Draw(new RectangleShape(new Vector2f(window.Size.X, window.Size.Y)), new RenderStates(shader));
    }
}