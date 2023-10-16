using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : SimpleMenu<GameOver>
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
