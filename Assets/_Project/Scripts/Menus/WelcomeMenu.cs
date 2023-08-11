using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeMenu : SimpleMenu<WelcomeMenu>
{
    
    public void OnPlayPressed()
    {

        GameMenu.Show();
    }

    
    public override void OnBackPressed()
    {

    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
    }

}

