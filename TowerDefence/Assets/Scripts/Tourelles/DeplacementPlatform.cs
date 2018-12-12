using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementPlatform : MonoBehaviour {

    public Vector3 debut;
    public Vector3 Haut;
    public Vector3 bas;
    public bool VersHaut ;
    public bool VersBas ;
	// Use this for initialization
	void Start () {
        debut = this.transform.position;
        Haut = this.transform.position + new Vector3(0, 0, 6);
        bas = this.transform.position + new Vector3(0, 0, -6);
    }
	
	// Update is called once per frame
	void Update () {
        if (VersHaut)
        {
            this.transform.position += new Vector3(0, 0, 4f) * Time.deltaTime;
        }
        if (VersBas)
        {
            this.transform.position += new Vector3(0, 0, -4f) * Time.deltaTime;
        }
        if (transform.position.z > Haut.z)
        {
            VersHaut = false;
            VersBas = true;
        }
        if (transform.position.z < bas.z)
        {
            VersHaut = true;
            VersBas = false;
        }
        
	}
}
