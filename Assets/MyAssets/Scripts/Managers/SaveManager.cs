using UnityEngine;
using System.Collections;

public class SaveManager : MonoBehaviour {

    public static SaveManager instance = null;

    void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void saveGame()
    { }

    public void loadGame()
    { }
}
