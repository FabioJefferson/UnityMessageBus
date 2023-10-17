<<<<<<< Updated upstream
using System;
using System.Collections;

[Serializable]
public class Player
=======
using AI_TictacToe_logic.AI;
using KLab.MessageBuses;
using System;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;

[Serializable]
public class Player : IPlayer
>>>>>>> Stashed changes
{
    public int Id;

    public Player(int id)
    public Player( int id )
    {
        Id = id;
    }
<<<<<<< Updated upstream:Assets/_Project/Scripts/Models/Player.cs
    public Player(){}
=======
<<<<<<< Updated upstream
=======

    public PlayerTypes Type => PlayerTypes.Human;

    public Task<int> MakeMove( GameState state )
    {

        var input = MessageBus.GetBus<BoardInputBus>();
        input.Connect(move => onPlayerMove(move));
       return Task.FromResult(0);

        void onPlayerMove(Move move)
        {
            state.ApplyMove(move.Position.GridIndex);
        }
    }
     
>>>>>>> Stashed changes
>>>>>>> Stashed changes:Assets/_Project/Scripts/Nantenaina/Models/Player.cs
}
