using KLab.MessageBuses;


public sealed class HUDButtonAction : MessageBus<HUDButtonActionType> { }

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

