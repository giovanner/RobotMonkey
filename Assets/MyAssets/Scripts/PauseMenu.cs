using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject panelMenu;
    
    public void enable()
    {
        panelMenu.SetActive(true);
    }

    public void disable()
    {
        panelMenu.SetActive(false);
    }
    
    public void pause()
    {
        GameManager.instance.pause();
    }
}
