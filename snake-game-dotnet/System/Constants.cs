namespace snake_game_dotnet.System;

public class Constants
{
    public static readonly string GAME_TITLE = "Snake";
    
    // PATHS
    public static readonly string SHADERS_FOLDER_PATH = "../../../Shaders/";
    public static readonly string LEVELS_FILE_PATH = "../../../Logic/Levels/Levels.json";

    // EXCEPTION MESSAGES
    public static readonly string LEVEL_NOT_FOUND = "Level does not exist.";
    public static readonly string SHADER_NOT_LOADED = "Shader wasn't loaded properly.";
    public static readonly string SHADER_NOT_FOUND = "Shader does not exist.";
}