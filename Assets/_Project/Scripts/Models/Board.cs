<<<<<<< Updated upstream:Assets/_Project/Scripts/Models/Board.cs
using KLab.MessageBuses;

public class Board
{
    private Piece[] _pawns;
    private Line[] _lines;

    public Board()
    {
        _pawns = new Piece[9];
        _lines = new Line[8];
        FillGrid(_pawns, _lines);
    }

    private void FillGrid(Piece[] all_p, Line[] all_l)
    {
        Fill(all_p);
        FillLine(all_l, all_p);

        void Fill(Piece[] all_piece)
        {
            all_piece[0] = new Piece();
            all_piece[1] = new Piece();
            all_piece[2] = new Piece();
            all_piece[3] = new Piece();
            all_piece[4] = new Piece();
            all_piece[5] = new Piece();
            all_piece[6] = new Piece();
            all_piece[7] = new Piece();
            all_piece[8] = new Piece();
        }

        void FillLine(Line[] all_line, Piece[] all_piece)
        {
            all_line[0] = new Line(all_piece[0], all_piece[1], all_piece[2]);
            all_line[1] = new Line(all_piece[3], all_piece[4], all_piece[5]);
            all_line[2] = new Line(all_piece[6], all_piece[7], all_piece[8]);
            all_line[3] = new Line(all_piece[0], all_piece[3], all_piece[6]);
            all_line[4] = new Line(all_piece[1], all_piece[4], all_piece[7]);
            all_line[5] = new Line(all_piece[2], all_piece[5], all_piece[8]);
            all_line[6] = new Line(all_piece[0], all_piece[4], all_piece[8]);
            all_line[7] = new Line(all_piece[2], all_piece[4], all_piece[6]);
        }
    }

    public InputResult CheckForWin(Player currentPlayer, int input, Play play)
    {
      InputCheckResult inputResult = play.CheckInput(_pawns, input);

       if (!inputResult.InputAllowed)
        {
           // MessageBus.GetBus<IOErrorBus>().Broadcast(new ErrorMessage() { Message = "Wrong Input: Selected" });
            return new InputResult(false, null);
        }
        else
        {
            play.AssignOwnership(_pawns, input, currentPlayer);

            Player winnersId = play.CheckForWinnersId(_lines);

            if (winnersId != null)
            {
                return new InputResult(true, new PlaySessionResult(true, winnersId));
            }

            return new InputResult(true, new PlaySessionResult(false));
        }
    }

    //public String ReturnForm(int number)
    //{
    //    String tmp = "";
    //    if (number == -1)
    //    {
    //        tmp = ".";
    //    }
    //    if (number == 0)
    //    {
    //        tmp = "x";
    //    }
    //    if (number == 1)
    //    {
    //        tmp = "o";
    //    }
    //    return tmp;
    //}
    //
    //public void Show(Piece[] all_piece)
    //{
    //    for (int i = 0; i <= 2; i++)
    //    {
    //        Console.Write(i + " | ");
    //    }
    //    Console.WriteLine("\n-----------");
    //    for (int i = 3; i <= 5; i++)
    //    {
    //        Console.Write(i + " | ");
    //    }
    //    Console.WriteLine("\n-----------");
    //    for (int i = 6; i <= 8; i++)
    //    {
    //        Console.Write(i + " | ");
    //    }
    //    Console.WriteLine("\n");
    //    for (int i = 0; i <= 2; i++)
    //    {
    //        Console.Write(this.ReturnForm(all_piece[i].OwnerId) + " | ");
    //    }
    //    Console.WriteLine("\n-----------");
    //    for (int i = 3; i <= 5; i++)
    //    {
    //        Console.Write(this.ReturnForm(all_piece[i].OwnerId) + " | ");
    //    }
    //    Console.WriteLine("\n-----------");
    //    for (int i = 6; i <= 8; i++)
    //    {
    //        Console.Write(this.ReturnForm(all_piece[i].OwnerId) + " | ");
    //    }
    //    Console.WriteLine("\n");
    //}
}

=======
using System;
using System.Collections.Generic;
using System.Linq;

namespace AI_TictacToe_logic.AI
{
    public class Board
    {
        public int Size { get; set; }

        /// <summary>
        /// Indexes: 0 | 1 | 2
        ///          ---------
        ///          3 | 4 | 5
        ///          ---------
        ///          6 | 7 | 8
        ///
        /// Values: 0: Open spot
        ///         1: Player 1 spot (X)
        ///         2: Player 2 spot (O)
        /// 
        /// </summary>
        /// <example>
        /// [1,0,2,0,0,0,0,0,0] means:
        ///  X |  | O
        ///  ---------
        ///    |  | 
        ///  ---------
        ///    |  | 
        /// </example>
        public int[] Positions { get; set; }

        public List<int> AvailablePositions { get; private set; } = new();

        public Board(int boardSize)
        {
            if (boardSize is < 3 or > 5)
            {
                boardSize = 3;
            }

            Size = boardSize;
            Positions = new int[(int)Math.Pow(Size, 2)];
            ResetBoard();
        }

        private void ResetBoard()
        {
            AvailablePositions = Enumerable.Range(0, Positions.Length).ToList();
            for (var posIndex = 0; posIndex < Positions.Length; posIndex++)
            {
                // set all positions to 0 (unused space)
                Positions[posIndex] = 0;
            }
        }

        public void ApplyMove(int move, int player)
        {
            // update the board to reflect player's move
            Positions[move] = player;
            AvailablePositions.Remove(move);
        }

        public string GetState()
        {
            return string.Join("", Positions);
        }

        #region Clone

        /// <summary>
        /// Some bots may require copies of the board to calculate or predict best move.
        /// Use Clone as a way to get a copy of the current board State without mutating the existing one.
        /// </summary>
        /// <returns>Deep copy of the current board State</returns>
        public Board Clone()
        {
            var clonedBoard = new Board(Size)
            {
                Positions = Positions.ToArray(),
                AvailablePositions = new List<int>(AvailablePositions)
            };

            return clonedBoard;
        }

        #endregion
    }
}
>>>>>>> Stashed changes:Assets/_Project/Scripts/Nantenaina/Models/Board.cs
