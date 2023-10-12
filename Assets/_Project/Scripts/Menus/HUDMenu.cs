using KLab.MessageBuses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDMenu : SimpleMenu<HUDMenu>
{
    [SerializeField] private Button _pauseBtn;
    [SerializeField] private Button _exitBtn;
    private HUDButtonAction _HUDButtonAction;

    public void Awake()
    {
        _HUDButtonAction = MessageBus.GetBus<HUDButtonAction>();
        _pauseBtn.onClick.AddListener(() => OnPausePressed());
        _exitBtn.onClick.AddListener(() => OnExitPressed());
    }


    public void OnPausePressed()
    {
        Debug.Log("HUDPausePressed");
        _HUDButtonAction.Broadcast(HUDButtonActionType.Pause);
    }
    public void OnExitPressed()
    {
        Debug.Log("HUDExitPressed");
        _HUDButtonAction.Broadcast(HUDButtonActionType.Exit);

    }
}
