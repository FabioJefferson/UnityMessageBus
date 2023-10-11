using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDMenu : SimpleMenu<HUDMenu>
{
    public void OnReplayButtonPressed()
    {
        GameMenu.Show();
    }
    public void OnExitButtonPressed()
    {
        WelcomeMenu.Show();
    }
}
