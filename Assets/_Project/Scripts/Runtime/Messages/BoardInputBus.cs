using KLab.MessageBuses;
using test.Utils;

public sealed class BoardInputBus : MessageBus<Move> { }
public sealed class GameModeBus: MessageBus<GameModeType> { }
public sealed class FilteredBoardInputBus : MessageBus<Move>{ }

public sealed class PlayerSwitchedBus : MessageBus<Player> { }

public sealed class BoardAction : MessageBus<BoardActionType> { }

public sealed class PlayEndedBus : MessageBus<PlayEndResult> { }

public sealed class IOErrorBus: MessageBus<ErrorMessage> { }

public class ErrorMessage
{
    public string Message { get; set; }
}

public enum BoardActionType
{
    None = 0,
    Show,
    Close
}

public enum PlayEndResultType
{
    None = 0,
    Win,
    Draw
}

public class PlayEndResult
{
    public readonly PlayEndResultType PlayResultType;
    public readonly Player Winner;

    public PlayEndResult(PlayEndResultType playResultType, Player winner)
    {
        PlayResultType = playResultType;
        Winner = winner;
    }
}