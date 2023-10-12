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

    public void OnPlayPressed()
    {
        Hide();

        Debug.Log("OnPlayPressed");
        _boardAction.Broadcast(BoardActionType.Show);
    }

    public override void OnBackPressed()
    {

    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
    }

}

