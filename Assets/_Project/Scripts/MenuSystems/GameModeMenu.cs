using KLab.MessageBuses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeMenu : SimpleMenu<GameModeMenu>
{
    private GameModeAction _gameModeAction;
    [SerializeField] private Button _aIBtn;
    [SerializeField] private Button _oneVsOneBtn;


    private void Start()
    {
        _gameModeAction = MessageBus.GetBus<GameModeAction>();
        _aIBtn.onClick.AddListener(() => OnAiBtnPressed());
        _oneVsOneBtn.onClick.AddListener(() => OnOneVsOneBtnPressed());
    }
    public void OnAiBtnPressed()
    {
        Debug.Log("AiPressed");
        _gameModeAction.Broadcast(GameModeActionType.AI);
    }
    public void OnOneVsOneBtnPressed()
    {

        Debug.Log("HUDExitPressed");
        _gameModeAction.Broadcast(GameModeActionType.OneVsOne);

    }
    //private override void OnDestroy()
    //{
    //    _pauseBtn.onClick.RemoveAllListeners();
    //    _exitBtn.onClick.RemoveAllListeners();
    //}
}
