using KLab.MessageBuses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMode : SimpleMenu<GameMode>
{
    [SerializeField] private Button _2DButton;  
    [SerializeField] private Button _3DButton;
    [SerializeField] private Button _exitBtn;
    private HUDButtonAction _HUDButtonAction;
    private GameModeBus _gameModeBus;

    private void Start()
    {
        _gameModeBus = MessageBus.GetBus<GameModeBus>();
        _2DButton.onClick.AddListener(() => On2DPressed());
        _3DButton.onClick.AddListener(() => On3DPressed());
        _exitBtn.onClick.AddListener(() => OnExitPressed());
    }
    public void On2DPressed()
    {
        _gameModeBus.Broadcast(GameModeType.TwoD);
        Debug.Log("2D");
    }
    public void On3DPressed()
    {
        _gameModeBus.Broadcast(GameModeType.ThreeD);
        Debug.Log("3D");

    }
    public void OnExitPressed()
    {

        Debug.Log("HUDExitPressed");
        _HUDButtonAction.Broadcast(HUDButtonActionType.Exit);

    }
}
