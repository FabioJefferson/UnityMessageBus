using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 
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

