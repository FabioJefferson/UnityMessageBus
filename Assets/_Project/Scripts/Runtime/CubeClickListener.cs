using KLab.MessageBuses;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClickListener : MonoBehaviour
{
    //private BoardInputBus _boardBus;
    //[SerializeField] private Move _moveMessage = null;
    private Action _onClick;


    //public void SetPosition(Move move)
    //{
    //    _moveMessage = move;
    //}

    public void SetCallBack(Action callback)
    {
        _onClick = callback;
    }

    private void OnMouseUp()
    {
        _onClick?.Invoke();
        //_boardBus = MessageBus.GetBus<BoardInputBus>();
        //if (_boardBus == null)
        //{
        //    Debug.LogError("_boardBus not Found", this);
        //    return;
        //}
        //if (_moveMessage == null)
        //{
        //    Debug.LogError("_moveMessage not Initialized", this);
        //    return;
        //}
        //_boardBus.Broadcast(_moveMessage);

        //Debug.Log("Cube clicked, Piece Index: " + _moveMessage.Position.GridIndex + " idPlayer = " + _moveMessage.PlayerId);
    }
}
