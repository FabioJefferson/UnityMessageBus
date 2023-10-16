using UnityEngine;
using KLab.MessageBuses;
using UnityEngine.UI;

public class WelcomeMenu : SimpleMenu<WelcomeMenu>
{
    private BoardAction _boardAction ;

    [SerializeField] private Button _playBtn;

    private void Start()
    {
        _boardAction = MessageBus.GetBus<BoardAction>();
        _playBtn.onClick.AddListener(() => OnPlayPressed());
       
    }

    public void OnPlayPressed()
    {
        Debug.Log("OnPlayPressed");
        _boardAction.Broadcast(BoardActionType.Show);
        Hide();
    }
     
    public override void OnBackPressed()
    {

    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
    }

}

