using AI_TictacToe_logic.AI;
using System;
using System.Collections;
using System.Threading.Tasks;

[Serializable]
public class Player: IPlayer
{
    public int Id;

    public Player(int id)
    {
        Id = id;
    }

    public PlayerTypes Type => PlayerTypes.Human;

    public Task<int> MakeMove(GameState state)
    {
        throw new NotImplementedException();
    }
}
