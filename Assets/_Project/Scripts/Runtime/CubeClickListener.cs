using KLab.MessageBuses;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClickListener : MonoBehaviour
{
    private Action _onClick;
    public void SetCallBack(Action callback)
    {
        _onClick = callback;
    }

    private void OnMouseUp()
    {
        _onClick?.Invoke();
       
    }
}
