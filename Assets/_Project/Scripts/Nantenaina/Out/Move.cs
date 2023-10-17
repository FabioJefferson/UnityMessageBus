using AI_TictacToe_logic.AI;

public class Move
{
    public readonly bool IsBoardFull;
    public readonly Position Position;
    public readonly IPlayer Player;

    public Move(bool isBoardFull, Position position, Player player)
    {
        IsBoardFull = isBoardFull;
        Position = position;
        Player = player;
    }
}
