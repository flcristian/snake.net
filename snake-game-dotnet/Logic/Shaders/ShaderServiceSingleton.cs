namespace snake_game_dotnet.Logic.Shaders;

public class ShaderServiceSingleton
{
    private static readonly Lazy<ShaderService> _instance = new (() => new ShaderService());

    public static ShaderService Instance => _instance.Value;

    private ShaderServiceSingleton() { }
}