using SFML.Graphics;
using SFML.System;
using SFML.Window;
using snake_game_dotnet.System;

namespace snake_game_dotnet.Logic.Game.Window;

public class WindowService
{
    private RenderWindow _windowInstance;

    public RenderWindow WindowInstance => _windowInstance;
    
    public WindowService()
    {
        _windowInstance = new (new VideoMode(900, 900), Constants.GAME_TITLE);
        
        _windowInstance.Resized += OnWindowResized!;
    }
    
    public void ResizeWindow(int width, int height)
    {
        _windowInstance.Size = new Vector2u((uint)width, (uint)height);
    }
    
    private void OnWindowResized(object sender, SizeEventArgs e)
    {
        FloatRect visibleArea = new FloatRect(0, 0, e.Width, e.Height);
        View view = new View(visibleArea);

        view.Center = new Vector2f(e.Width / 2f, e.Height / 2f);

        _windowInstance.SetView(view);
    }
}