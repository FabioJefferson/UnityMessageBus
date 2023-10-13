using KLab.MessageBuses;

public class PauseMenu : SimpleMenu<PauseMenu>
{

    public override void OnBackPressed()
    {
        base.OnBackPressed();
        MessageBus.GetBus<BoardAction>().Broadcast(BoardActionType.Show);
        //MessageBus.GetBus<HUDButtonAction>().Broadcast(HUDButtonActionType.Show);
    }

    public void OnQuitPressed()
    {
        Hide();
        Destroy(this.gameObject); // This menu does not automatically destroy itself

        HUDMenu.Hide();
    }
}
