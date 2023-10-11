using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDMenu : SimpleMenu<HUDMenu>
{
    public void OnReplayButtonPressed()
    {
        HUDMenu.Show();
    }
    public void OnExitButtonPressed()
    {
        WelcomeMenu.Show();
    }
}
