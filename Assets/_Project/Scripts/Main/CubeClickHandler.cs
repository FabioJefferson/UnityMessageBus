using AI_TictacToe_logic.AI;
using Assets._Project.Scripts.Nantenaina.Data;
using KLab.MessageBuses;
using System.Collections.Generic;
<<<<<<< Updated upstream:Assets/_Project/Scripts/Main/CubeClickHandler.cs
=======
<<<<<<< Updated upstream
=======
using System.Threading.Tasks;
using test.Utils;
>>>>>>> Stashed changes
using TMPro;
>>>>>>> Stashed changes:Assets/_Project/Scripts/Nantenaina/CubeClickHandler.cs
using UnityEngine;
using TMPro;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] _cubeList = new GameObject[9];
    [SerializeField] private TextMeshProUGUI _textMessage;
    [SerializeField] private List<Pawn> _pawnsOrdered = new();
    private Player _currentPlayer;
    private Dictionary<Player, Pawn> _playerToPawn = new();
    private int _addedPawns;
    private bool _isGameModeHumanVsAi = true;
    private MinMaxBot _aiBot;
    private GameStateHandler _gameStateHandler;

    private void Awake()
    {

        _aiBot = new();
        _gameStateHandler = GameStateHandler.GetInstance();
        ValidateNotNull();
        AssignClickListeners();
        ListenToBuses();
      
    }

    private void ListenToBuses()
    {
        MessageBus.GetBus<FilteredBoardInputBus>()
            .Connect(move => OnFilteredInputHandler(move));
        MessageBus.GetBus<PlayerSwitchedBus>()
            .Connect(player => OnPlayerSwitchedHandler(player));
        MessageBus.GetBus<PlayEndedBus>()
            .Connect(endResult => OnPlayEndHandler(endResult));
    }

    private void ValidateNotNull()
    {
        if (_pawnsOrdered == null)
        {
            Debug.LogError("_pawns is null");
        }
    }

<<<<<<< Updated upstream
=======
   
>>>>>>> Stashed changes
    private void AssignClickListeners()
    {
        int counter = 0;
        string currentCubeName;
        while (counter < _cubeList.Length)
        {
            var listener = _cubeList[counter].AddComponent<CubeClickListener>();
            currentCubeName = _cubeList[counter].gameObject.name;
            Position pos = new Position(int.Parse(currentCubeName));
            listener.SetCallBack(() => OnMouseUpHandler(pos));
            counter++;
        }
    }

    private void OnFilteredInputHandler(Move move)
    {
        var _cubeSelected = _cubeList[move.Position.GridIndex];
        var position = _cubeSelected.transform.position;
        var _ = Instantiate(GetPlayersPawn((Player)move.Player), position, Quaternion.identity);

        Pawn GetPlayersPawn(Player playerId)
        {
            if (!_playerToPawn.ContainsKey(playerId))
            {
                Debug.LogError($"Player Id: {playerId} is unknown");
                return null;
            }
            return _playerToPawn[playerId];
        }
    }

    private void OnPlayerSwitchedHandler(Player player)
    {
        _currentPlayer = player;

        // TODO: show visualy

        FillDictionary(player);

        void FillDictionary(Player player)
        {
            if (!_playerToPawn.ContainsKey(player))
            {
                //if (_addedPawns > 0)
                {
                    if (_pawnsOrdered[_addedPawns] == null)
                    {
                        Debug.LogError($"Not enough pawn in list, only: {_pawnsOrdered.Count}");
                    }
                    else
                    {
                        _playerToPawn[player] = _pawnsOrdered[_addedPawns++];
                    }
                }

            }
        }
    }

    private void OnMouseUpHandler( Position pos )
    {
        Move move = new(false, pos, _currentPlayer);
        MessageBus.GetBus<BoardInputBus>()
            .Broadcast(move);
        if (_isGameModeHumanVsAi)
        {
            _ = MoveAIAsync();
        }
    }

<<<<<<< Updated upstream
=======
    private void OnAIModeChoosen(GameModeType type)
    {
       if(type == GameModeType.AI)
       {
            _isGameModeHumanVsAi = true;
       }
    }

>>>>>>> Stashed changes
    private void OnPlayEndHandler(PlayEndResult endResult)
    {
        if (endResult.PlayResultType == PlayEndResultType.Win)
        {
<<<<<<< Updated upstream:Assets/_Project/Scripts/Main/CubeClickHandler.cs
            //_textMessage.text = "The player " + endResult.Winner.Id + " wins the game !!!!!";
            print("The player " + endResult.Winner.Id + " wins the game !!!!!");
=======
            _textMessage.text = "The player " + endResult.Winner.Id + " wins the _game !!!!!";
>>>>>>> Stashed changes:Assets/_Project/Scripts/Nantenaina/CubeClickHandler.cs
        }
    }
    
    public async Task<int> MoveAIAsync()
    {
        if (_gameStateHandler.State != null)
        {
            var playerMove = await _gameStateHandler.State.PlayersTurn.MakeMove(_gameStateHandler.State);
            UnityEngine.Debug.Log("_bot:" + playerMove);
            _gameStateHandler.State.ApplyMove(playerMove);
            Position pos = new(playerMove);

            MessageBus.GetBus<BoardInputBus>().Broadcast(new(false,pos,_currentPlayer));
            return playerMove;
        }

        return 0;
    }
}