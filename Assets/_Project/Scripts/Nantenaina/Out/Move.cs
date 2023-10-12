public class Move
{
    public readonly bool IsBoardFull;
    public readonly Position Position;
    public readonly Player Player;

    public Move(bool isBoardFull, Position position, Player player)
    {
        IsBoardFull = isBoardFull;
        Position = position;
        Player = player;
    }
}
