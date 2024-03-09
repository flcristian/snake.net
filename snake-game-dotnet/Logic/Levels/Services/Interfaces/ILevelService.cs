using SFML.Graphics;
using snake_game_dotnet.Logic.Levels.Models;

namespace snake_game_dotnet.Logic.Levels.Interfaces;

public interface ILevelService
{
    void LoadLevel(RenderWindow window, string levelName);

    Level GetLevel(string levelName);
}