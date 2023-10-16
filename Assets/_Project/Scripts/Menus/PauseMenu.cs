using KLab.MessageBuses;

public class PauseMenu : SimpleMenu<PauseMenu>
{

    private BoardAction _boardAction;
    private HUDButtonAction _HUDButtonAction;

    private void Start()
    {
        _boardAction = MessageBus.GetBus<BoardAction>();
        _HUDButtonAction = MessageBus.GetBus<HUDButtonAction>();
    }

    public override void OnBackPressed()
    {
        _boardAction.Broadcast(BoardActionType.Show);
    }

    public void OnQuitPressed()
    {
        Hide();
        Destroy(this.gameObject); // This menu does not automatically destroy itself

        _HUDButtonAction.Broadcast(HUDButtonActionType.Exit);
    }
}
