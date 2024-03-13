using Newtonsoft.Json;
using SFML.System;
using snake_game_dotnet.Logic.Foods.Models;
using snake_game_dotnet.Logic.Levels.Services;
using snake_game_dotnet.Logic.Snake.Services;
using snake_game_dotnet.System;

namespace snake_game_dotnet.Logic.Foods.FoodService;

public class FoodService
{
    private List<FoodType> _normalFoodTypes;
    private List<FoodType> _specialFoodTypes;
    private List<Food> _foodInstances;
    private LevelService _levelService;
    private SnakeService _snakeService;

    public FoodService()
    {
        _levelService = LevelServiceSingleton.Instance;
        _snakeService = SnakeServiceSingleton.Instance;
        LoadFoodTypesFromJson();
    }

    public void SpawnFood()
    {
        Vector2i position = GetRandomFoodPosition();
    }

    public bool CheckIfFoodOnPosition(Vector2i position)
    {
        foreach (Food food in _foodInstances)
        {
            if (food.Position.Equals(position))
            {
                return true;
            }
        }

        return false;
    }
    
    private void LoadFoodTypesFromJson()
    {
        string json = File.ReadAllText(Constants.LEVELS_FILE_PATH);

        List<FoodType> list = JsonConvert.DeserializeObject<List<FoodType>>(json)!;

        _normalFoodTypes = new List<FoodType>();
        _specialFoodTypes = new List<FoodType>();

        foreach (FoodType ft in list)
        {
            if (ft.Special)
            {
                _specialFoodTypes.Add(ft);
            }
            else
            {
                _normalFoodTypes.Add(ft);
            }
        }
    }

    private Vector2i GetRandomFoodPosition()
    {
        Random random = new Random();

        Vector2i position = new Vector2i(random.Next(0, _levelService.LevelInstance.Width), random.Next(0, _levelService.LevelInstance.Height));
        
        while (_snakeService.CheckIfSnakeOnPosition(position) || CheckIfFoodOnPosition(position))
        {
            position.X = random.Next(0, _levelService.LevelInstance.Width);
            position.Y = random.Next(0, _levelService.LevelInstance.Height);
        }

        return position;
    }
}