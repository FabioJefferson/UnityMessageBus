using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KLab.MessageBuses;
using System;

public class PlayManager : MonoBehaviour, IPlayManager
{
    [SerializeField] Transform _boardPrefab2D;
    [SerializeField] Transform _boardPrefab3D;

    [SerializeField] Camera _camera2D;
    [SerializeField] Camera _camera3D;

    [SerializeField] GameObject _realBoardPrefab2D;
    [SerializeField] GameObject _realBoardPrefab3D;

    private Game _game;

    private void Awake()
    {


        //#if UNITY_EDITOR
        //        if (!_boardPrefab2D || !_boardPrefab3D)
        //        {
        //            Debug.LogError("_board is NULL", this);
        //        }
        //        if (!_boardPrefab2D.gameObject.activeSelf || !_boardPrefab3D.gameObject.activeSelf)
        //        {
        //            HideBoard();
        //        }
        //#endif

        MessageBus.GetBus<GameModeBus>()
            .Connect(msg => OnActionMessage(msg));
        MessageBus.GetBus<HUDButtonAction>()
            .Connect(msg => OnHUDButtonActionMessage(msg));
    }
    private void OnActionMessage(GameModeType msg)
    {
        Debug.Log("aonahhh");
        var position = transform.position;
        switch (msg)
        {
            case GameModeType.None:
                HideBoard();
                break;
            case GameModeType.TwoD:
                _boardPrefab2D = Instantiate(_realBoardPrefab2D, position, Quaternion.identity).transform;
                _boardPrefab2D.transform.SetParent(this.transform);
                ShowEmptyBoard2D();
                if (_game == null)
                {
                    _game = new();
                }
                break;
            case GameModeType.ThreeD:
                _boardPrefab3D = Instantiate(_realBoardPrefab3D, position, Quaternion.identity).transform;
                _boardPrefab3D.transform.SetParent(this.transform);
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
        if (_boardPrefab2D) _boardPrefab2D.gameObject.SetActive(false);
        if (_boardPrefab3D) _boardPrefab3D.gameObject.SetActive(false);
        //_camera.gameObject.SetActive(false);
    }
}
