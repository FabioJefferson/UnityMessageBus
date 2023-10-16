using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : SimpleMenu<GameOver>
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
