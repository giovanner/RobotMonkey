using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player1") || collider.CompareTag("Player2"))
        {
            collider.GetComponent<Health>().die();
        }
    }
}
