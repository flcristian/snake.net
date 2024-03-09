namespace snake_game_dotnet.Logic.Levels.Services;

public class LevelServiceSingleton
{
    private static readonly Lazy<LevelService> _instance = new (() => new LevelService());

    public static LevelService Instance => _instance.Value;

    private LevelServiceSingleton() { }
}