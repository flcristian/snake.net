using SFML.System;

namespace snake_game_dotnet.Logic.Foods.Models;

public class Food
{
    public Vector2i Position { get; set; }
    public FoodType Type { get; set; }
    
    public Food(int x, int y, FoodType type)
    {
        Position = new Vector2i(x, y);
        Type = type;
    }
    
    public virtual void OnEat()
    {
        
    }
}