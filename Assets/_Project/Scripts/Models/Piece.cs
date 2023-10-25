public class Piece
{
    public Player Owner;
    public Piece()
    {
        Owner = null;
    }
    public Piece(Player player = null)
    {
        Owner = player;
    }
}