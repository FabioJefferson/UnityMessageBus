﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;

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
