﻿using snake_game_dotnet.Logic.Game.Services;

namespace snake_game_dotnet;

class Program
{
    static void Main(string[] args)
    {
        GameService service = new GameService();
        service.StartGame();
    }
    
}