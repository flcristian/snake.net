using SFML.Graphics;
using snake_game_dotnet.Logic.Shaders.Interfaces;
using snake_game_dotnet.System;

namespace snake_game_dotnet.Logic.Shaders;

public class ShaderService : IShaderService
{
    public Dictionary<string, Shader> Shaders { get; set; }

    public ShaderService()
    {
        Shaders = new Dictionary<string, Shader>();
    }

    public void AddShader(string levelName, string shaderName)
    {
        Shader shader = new Shader(null, null, $"{Constants.SHADERS_FOLDER_PATH}/{levelName}/{shaderName}.frag");

        if (shader.Equals(null))
        {
            throw new Exception(Constants.SHADER_NOT_FOUND);
        }
        
        Shaders.Add($"{levelName}/{shaderName}", shader);
    }

    public void DeleteShader(string levelName, string shaderName)
    {
        Shader shader = Shaders.GetValueOrDefault($"{levelName}/{shaderName}")!;

        if (shader.Equals(null))
        {
            throw new Exception(Constants.SHADER_NOT_LOADED);
        }

        Shaders.Remove($"{levelName}/{shaderName}");
    }

    public Shader GetShader(string levelName, string shaderName)
    {
        Shader shader = Shaders.GetValueOrDefault($"{levelName}/{shaderName}")!;

        if (shader.Equals(null))
        {
            throw new Exception(Constants.SHADER_NOT_LOADED);
        }

        return shader;
    }
}