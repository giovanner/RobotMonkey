using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PosLevelMenu : MonoBehaviour {

    public GameObject panelMenu;
    public Text timeText;

    public Button nextLevel;

    public void enable(float timeLevel = 0.0f, bool bydeath = false)
    {
        if (panelMenu)
        {
            if(bydeath)
            {
                disableNext();
                timeText.text = "You Dead in: " + (int)(timeLevel / 60) + ":" + (int)(timeLevel % 60);
            }
            else
            {
                timeText.text = "You Complete the level in: " + (int)(timeLevel / 60) + ":" + (int)(timeLevel % 60);
            }

            panelMenu.SetActive(true);
        }
        else
            Debug.Log("No reference to pos level menu"); 
    }

    public void disable()
    {
        if (panelMenu)
            panelMenu.SetActive(false);
        else
            Debug.Log("No reference to pos level menu");
    }

    void disableNext()
    {
        if (nextLevel)
            nextLevel.gameObject.SetActive(false);
    }
}
