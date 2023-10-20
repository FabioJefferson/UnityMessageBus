using KLab.MessageBuses;
using System.Collections.Generic;
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

    private void Awake()
    {
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
        var _ = Instantiate(GetPlayersPawn(move.Player), position, Quaternion.identity);
        _.transform.parent = this.transform;
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

    private void OnMouseUpHandler(Position pos)
    {
        Move move = new(false, pos, _currentPlayer);
        MessageBus.GetBus<BoardInputBus>()
            .Broadcast(move);
    }

    private void OnPlayEndHandler(PlayEndResult endResult)
    {
        if (endResult.PlayResultType == PlayEndResultType.Win)
        {
            //_textMessage.text = "The player " + endResult.Winner.Id + " wins the game !!!!!";
            print("The player " + endResult.Winner.Id + " wins the game !!!!!");
        }
    }
}