using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KLab.MessageBuses;
using System;

public class PlayManager : MonoBehaviour
{
    [SerializeField] Transform _boardPrefab2D;
    [SerializeField] Transform _boardPrefab3D;

    [SerializeField] Camera _camera2D;
    [SerializeField] Camera _camera3D;

    private Game _game;

    private void Awake()
    {
#if UNITY_EDITOR
        if (!_boardPrefab2D || !_boardPrefab3D)
        {
            Debug.LogError("_board is NULL", this);
        }
        if (!_boardPrefab2D.gameObject.activeSelf || !_boardPrefab3D.gameObject.activeSelf)
        {
            HideBoard();
        }
#endif

        MessageBus.GetBus<GameModeBus>()
            .Connect(msg => OnActionMessage(msg));
        MessageBus.GetBus<HUDButtonAction>()
            .Connect(msg => OnHUDButtonActionMessage(msg));
    }

    private void OnActionMessage(GameModeType msg)
    {
        Debug.Log("aonahhh");
        switch (msg)
        {
            case GameModeType.None:
                HideBoard();
                break;
            case GameModeType.TwoD:
                ShowEmptyBoard2D();
                if (_game == null)
                {
                    _game = new();
                }
                break;
            case GameModeType.ThreeD:
                ShowEmptyBoard3D();
                if (_game == null)
                {
                    _game = new();
                }
                break;
            default:
                break;

        }
    }

    private void OnHUDButtonActionMessage(HUDButtonActionType msg)
    {
        switch (msg)
        {
            case HUDButtonActionType.Pause:
                HideBoard();
                break;
            case HUDButtonActionType.Exit:
                HideBoard();
                break;
            default:
                break;

        }
    }

    public void ShowEmptyBoard2D()
    {
        _boardPrefab2D.gameObject.SetActive(true);
        _camera2D.gameObject.SetActive(true);
    }
    public void ShowEmptyBoard3D()
    {
        _boardPrefab3D.gameObject.SetActive(true);
        _camera3D.gameObject.SetActive(true);
    }

    public void HideBoard()
    {
        _boardPrefab2D.gameObject.SetActive(false);
        _boardPrefab3D.gameObject.SetActive(false);
        //_camera.gameObject.SetActive(false);
    }
}
