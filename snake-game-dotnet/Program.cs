using SFML.Graphics;
using SFML.System;
using SFML.Window;
using snake_game_dotnet.Logic.Game;
using snake_game_dotnet.System;

class Program
{
    static void Main(string[] args) {
        GameService game = new GameService();
        game.StartGame();
    }
    
}