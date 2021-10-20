using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{

    public GameObject settingsMenu;
    public GameObject mainMenu;

    public void toMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void toSettings()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }


}
