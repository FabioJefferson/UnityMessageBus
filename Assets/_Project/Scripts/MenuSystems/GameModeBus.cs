using KLab.MessageBuses;


public sealed class GameModeBus : MessageBus<GameModeType> { }

public enum GameModeType
{
    None = 0,
    TwoD,
    ThreeD
}
