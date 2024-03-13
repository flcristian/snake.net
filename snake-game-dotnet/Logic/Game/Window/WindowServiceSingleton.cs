namespace snake_game_dotnet.Logic.Game.Window;

public class WindowServiceSingleton
{
    private static readonly Lazy<WindowService> _instance = new (() => new WindowService());

    public static WindowService Instance => _instance.Value;

    private WindowServiceSingleton() { }
}