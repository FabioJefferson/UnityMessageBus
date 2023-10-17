using System;
using System.Collections.Generic;
using System.Linq;

namespace AI_TictacToe_logic.AI
{
    public class AIBoard
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

        public AIBoard(int boardSize)
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
        public AIBoard Clone()
        {
            var clonedBoard = new AIBoard(Size)
            {
                Positions = Positions.ToArray(),
                AvailablePositions = new List<int>(AvailablePositions)
            };

            return clonedBoard;
        }

        #endregion
    }
}