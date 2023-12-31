using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KLab.MessageBuses;
using System;

public class PlayManager : MonoBehaviour
{
    [SerializeField] Transform _boardPrefab;

    [SerializeField] Camera _camera;

    private Game _game;

    private void Awake()
    {
#if UNITY_EDITOR
        if(!_boardPrefab)
        {
            Debug.LogError("_board is NULL", this);
        }
        if(_boardPrefab.gameObject.activeSelf)
        {
            HideBoard();
        }
#endif
       
        MessageBus.GetBus<BoardAction>()
            .Connect(msg => OnActionMessage(msg));
    }

    private void OnActionMessage(BoardActionType msg)
    {
        switch (msg)
        {
            case  BoardActionType.Close:
                HideBoard();
                break;
            case BoardActionType.Show:
                ShowEmptyBoard();
                _game = new();
                break;
            default: 
                break;

        }
    }

    public void ShowEmptyBoard()
    {
        _boardPrefab.gameObject.SetActive(true);
        _camera.gameObject.SetActive(true);
    }

    public void HideBoard()
    {
        _boardPrefab.gameObject.SetActive(false);
        _camera.gameObject.SetActive(false);
    }
}
