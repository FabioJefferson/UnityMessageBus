using KLab.MessageBuses;
using System;
using System.Diagnostics;


public class Game
{
    public Move PlayerMove;
    private readonly Board _board;
    private bool _hasPlayEnded = false;
    private Play _play;
    private int _gameMode = 0;

    private const int PLAYER1ID = 54619896;
    private const int PLAYER2ID = 45464;

    private Player _player1 = new(PLAYER1ID);
    private Player _player2 = new(PLAYER2ID);

    private Player _currentPlayer;
    private PlayerSwitchedBus _playerSwitchedBus;
    private PlayEndedBus _playEndedBus;

    private FilteredBoardInputBus _filteredBoardInputBus;

    public Game()
    {
        _board = new Board();
        _play = new Play();

        var boardInputBus = MessageBus.GetBus<BoardInputBus>();

        _playerSwitchedBus = MessageBus.GetBus<PlayerSwitchedBus>();
        _playEndedBus = MessageBus.GetBus<PlayEndedBus>();
        _filteredBoardInputBus = MessageBus.GetBus<FilteredBoardInputBus>();

        _currentPlayer = _player1;

        boardInputBus.Connect(move => OnBoardInput(move));
        _playerSwitchedBus.Broadcast(_currentPlayer);

       
    }

    private void OnBoardInput(Move move)
    {
        if (_hasPlayEnded)
        {
            UnityEngine.Debug.LogError("Game Already Ended");
            return;
        }

        if (_currentPlayer != move.Player)
        {
            UnityEngine.Debug.LogError($"Wrong Player made a move: _currentPlayer:{_currentPlayer} != PlayerId:{move.Player}");
            return;
        }

        var inputResult = _board.CheckForWin(move.Player, move.Position.GridIndex, _play);
        if (!inputResult.InputSuccess)
        {
            UnityEngine.Debug.LogError("Error on input");
            return;
        }

        _filteredBoardInputBus.Broadcast(move);

        _hasPlayEnded = inputResult.ResultOnInputSuccess.WinOccured;
        if (_hasPlayEnded)
        {
            _playEndedBus.Broadcast(new(PlayEndResultType.Win, _currentPlayer));
            //UnityEngine.Debug.LogError("Vita ehhh" + _currentPlayer);
            return;
        }

        SwitchPlayers();

        void SwitchPlayers()
        {
            _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
            _playerSwitchedBus.Broadcast(_currentPlayer);
        }
    }
}

