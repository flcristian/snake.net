using SFML.Graphics;

namespace snake_game_dotnet.Logic.Foods.Models;

public class FoodType
{
    public Color Color { get; set; }
    public bool Grow { get; set; }
    public bool Special { get; set; }

    public FoodType(Color color, bool grow, bool special)
    {
        Color = color;
        Grow = grow;
        Special = special;
    }
}