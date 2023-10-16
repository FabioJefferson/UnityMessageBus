using UnityEngine;
using KLab.MessageBuses;
using UnityEngine.UI;

public class WelcomeMenu : SimpleMenu<WelcomeMenu>
{
    private BoardAction _boardAction;

    [SerializeField] private Button _playBtn;

    private void Start()
    {

        _boardAction = MessageBus.GetBus<BoardAction>();
        //print("kc_boardBus");

        _playBtn.onClick.AddListener(() => OnPlayPressed());

    }
    //public void OnEnable()
    //{
    //    print("OnEnableCalled");
    //    _playBtn.onClick.AddListener(() => OnPlayPressed());
    //}
    public void OnPlayPressed()
    {
        Debug.Log("OnPlayPressed");
        _boardAction.Broadcast(BoardActionType.Show);
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
    }

}

