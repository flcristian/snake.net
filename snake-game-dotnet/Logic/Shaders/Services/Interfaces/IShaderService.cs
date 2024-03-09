using SFML.Graphics;

namespace snake_game_dotnet.Logic.Shaders.Services.Interfaces;

public interface IShaderService
{
    void AddShader(string levelName, string shaderName);

    void DeleteShader(string levelName, string shaderName);

    Shader GetShader(string levelName, string shaderName);
}