using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEffect : MonoBehaviour {

    public float tempAvantDestruction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        tempAvantDestruction -= Time.deltaTime;
        if (tempAvantDestruction < 0)
        {
            Destroy(gameObject);
        }

    }
}
