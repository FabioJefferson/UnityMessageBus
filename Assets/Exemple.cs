using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exemple : SimpleMenu<Exemple>
{
    // Start is called before the first frame update
    public void OnBtnPressed()
    {
        WelcomeMenu.Show();
    }

}
