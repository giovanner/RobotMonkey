using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    private float heath = 1;

    public void die()
    {
        this.heath = 0;
        GameManager.instance.finishByDeath(GetComponent<DemoScene>().id);
    }

    public float getHealth()
    { 
        return heath;
    }
    
}
