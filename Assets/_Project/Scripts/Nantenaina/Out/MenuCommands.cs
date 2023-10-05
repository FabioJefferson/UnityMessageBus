public class MenuCommands
{
    public readonly Menu Instance;
    public readonly MenuAction Command;

    public MenuCommands(Menu instance, MenuAction action)
    {
        Instance = instance;
        Command = action;
    }
}

public enum MenuAction
{
    None = 0,
    Open,
    Close
}
