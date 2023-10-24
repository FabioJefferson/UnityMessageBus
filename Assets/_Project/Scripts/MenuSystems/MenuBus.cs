using KLab.MessageBuses;


public sealed class HUDButtonAction : MessageBus<HUDButtonActionType> { }

public sealed class GameModeAction : MessageBus<GameModeActionType> { }

public enum GameModeActionType
{
    None = 0,
    AI,
    OneVsOne
}

public enum HUDButtonActionType
{
    None = 0,
    Pause,
    Exit
}

//public class T : MessageBus<T>
//{
//    T Message;
//    public Menu Instance;
//    public MenuAction Command;
//}

