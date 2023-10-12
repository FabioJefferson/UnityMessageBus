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
        Debug.Log("setCallBack");
        _onClick = callback;
    }


    private void OnMouseUpAsButton()
    {
        // This code is executed when the mouse button is released over this 2D object.
        Debug.Log("Mouse button released over this 2D object!");

        _onClick?.Invoke();

        // You can add more code to handle the desired behavior.
    }
}
