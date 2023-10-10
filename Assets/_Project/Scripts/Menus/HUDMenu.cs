using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDMenu : SimpleMenu<HUDMenu>
{
    //[SerializeField] private Camera _camera;

    public void OnPlayModeButtonPressed()
    {

    }


    public void OnPauseButtonPressed()
    {
        PauseMenu.Show();
    }
}

