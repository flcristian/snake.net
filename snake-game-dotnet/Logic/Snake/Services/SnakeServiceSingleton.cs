namespace snake_game_dotnet.Logic.Snake.Services;

public class SnakeServiceSingleton
{
    private static readonly Lazy<SnakeService> _instance = new (() => new SnakeService());

    public static SnakeService Instance => _instance.Value;

    private SnakeServiceSingleton() { }
}