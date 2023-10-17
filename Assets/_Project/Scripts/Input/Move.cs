<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< Updated upstream:Assets/_Project/Scripts/Input/Move.cs

=======
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
=======
﻿using AI_TictacToe_logic.AI;
>>>>>>> Stashed changes
>>>>>>> Stashed changes:Assets/_Project/Scripts/Nantenaina/Out/Move.cs

public class Move
{
    public readonly bool IsBoardFull;
    public readonly Position Position;
    public readonly Player Player;
    public readonly IPlayer Player;

    public Move(bool isBoardFull, Position position, Player player)
    {
        IsBoardFull = isBoardFull;
        Position = position;
        Player = player;
    }
}
