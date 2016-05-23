using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    public GameObject loadingImage;

    public void LoadScene(int level)
    {
        if(loadingImage)
            loadingImage.SetActive(true);

        Application.LoadLevel(level);
    }
}
