using snake_game_dotnet.Logic.Game;

class Program
{
    static void Main(string[] args)
    {
        GameService service = new GameService();
        service.StartGame();
    }
    
}