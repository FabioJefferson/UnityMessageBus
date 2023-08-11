using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMenu : SimpleMenu<GameMenu>
{

    public void OnPlayModeButtonPressed()
    {

    }

    public void OnPauseButtonPressed()
    {
        PauseMenu.Show();
    }
}

