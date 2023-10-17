using System.Collections.Generic;
using System.Linq;

namespace AI_TictacToe_logic.AI
{
    public class GameState
    {
        public IPlayer Player1 { get; }
        public IPlayer Player2 { get; }

        public IPlayer PlayersTurn { get; private set; }
        public List<string> AllStates { get; set; }
        public AIBoard Board { get; set; }

        public GameState(
            int boardSize,
            IPlayer player1,
            IPlayer player2)
        {
            Player1 = player1;
            Player2 = player2;

            PlayersTurn = player1;
            Board = new AIBoard(boardSize);
            AllStates = new List<string>
        {
            Board.GetState()
        };
        }

        /// <summary>
        /// A move was made, let's apply the move and update the _game State accordingly
        /// </summary>
        public void ApplyMove(int move)
        {
            var availableSpots = Board.AvailablePositions;
            if (availableSpots.All(x => x != move))
            {

            }

            // update the board to reflect the move made
            CaptureBoardState(move);

            // update player's turn
            UpdatePlayersTurn();
        }

        private void CaptureBoardState(int move)
        {
            var playerNumber = GetCurrentPlayersNumber();
            Board.ApplyMove(move, playerNumber);
            AllStates.Add(Board.GetState());
        }

        public void GameEnded(ResultState result)
        {
            // Calling GameEnded on the players themselves, allows opportunity to train based on how the _game concluded
            Player1.GameEnded(this, result, Constants.PLAYER_1);
            Player2.GameEnded(this, result, Constants.PLAYER_2);
        }

        private void UpdatePlayersTurn() =>
            PlayersTurn =
                PlayersTurn == Player1
                    ? Player2
                    : Player1;

        public int GetCurrentPlayersNumber() =>
            PlayersTurn == Player1
                ? Constants.PLAYER_1
                : Constants.PLAYER_2;

        public string GetCurrentPlayersSymbol() =>
            PlayersTurn == Player1
                ? Constants.PLAYER_1_SYMBOL
                : Constants.PLAYER_2_SYMBOL;

        #region Clone

        /// <summary>
        /// Some bots may require copies of the _game State to calculate or predict best move
        /// Use Clone as a way to get a copy of the current State without mutating the existing one.
        /// </summary>
        /// <returns>Deep copy of the current _game State</returns>
        public GameState Clone()
        {
            var clonedState = new GameState(Board.Size, Player1, Player2)
            {
                PlayersTurn = PlayersTurn,
                AllStates = new List<string>(AllStates),
                Board = Board.Clone()
            };

            return clonedState;
        }

        #endregion
    }
}