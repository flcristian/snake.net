using SFML.Graphics;
using SFML.System;
using SFML.Window;
using snake_game_dotnet.GameLogic;
using snake_game_dotnet.System;

namespace snake_game_dotnet.Logic.Game;

public class GameService
{
    private RenderWindow _window;
    private Dictionary<string, Shader> _shaders;

    public GameService()
    {
        LoadShaders();
    }
    
    public void StartGame()
    {
        Initialize();
        
        while (_window.IsOpen)
        {
            _window.DispatchEvents();
            _window.Clear(Color.Black);
            
            RenderService.DrawBackground(_window, _shaders.GetValueOrDefault("BACKGROUND")!);
            
            float tileSize = Constants.BASE_TILE_SIZE * 1.0f;
            float sizeX = _window.Size.X / tileSize;
            float sizeY = _window.Size.Y / tileSize;
            RectangleShape tile = new RectangleShape(new Vector2f(tileSize, tileSize));
            
            for (float i = 0f; i < sizeX; i++)
            {
                for (float j = 0f; j < sizeY; j++)
                {
                    Shader tileShader = new Shader(null, null, $"../../../Shaders/tile.frag");

                    tileShader.SetUniform("tileSize", tileSize);
                    tileShader.SetUniform("tileX", i + 1f);
                    tileShader.SetUniform("tileY", j + 1f);
                    
                    RenderStates tileRenderStates = new RenderStates(tileShader);
            
                    tile.FillColor = Color.White;
                    tile.Position = new Vector2f(i * tileSize, (sizeY - 1 - j) * tileSize);
                    _window.Draw(tile, tileRenderStates);
                }
            }
            
            
            _window.Display();
        }
    }
    
    public void ResizeWindow(uint width, uint height)
    {
        _window.Size = new Vector2u(width, height);
    }
    private void Initialize()
    {
        _window = new RenderWindow(new VideoMode(Constants.BASE_WIDTH, Constants.BASE_HEIGHT), Constants.GAME_TITLE);

        _window.Resized += OnWindowResized;
    }
    private void OnWindowResized(object sender, SizeEventArgs e)
    {
        FloatRect visibleArea = new FloatRect(0, 0, e.Width, e.Height);
        View view = new View(visibleArea);

        view.Center = new Vector2f(e.Width / 2f, e.Height / 2f);

        _window.SetView(view);
    }
    private void LoadShaders()
    {
        _shaders = new Dictionary<string, Shader>();
        
        Shader background = new Shader(null, null, $"../../../Shaders/background.frag");
        _shaders.Add("BACKGROUND", background);
    }
}