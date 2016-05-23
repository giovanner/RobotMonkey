using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    public float velocity = 1000.0f; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0,0,1*velocity) * Time.deltaTime);
	}
}
