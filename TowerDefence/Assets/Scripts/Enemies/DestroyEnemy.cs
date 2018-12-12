using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyEnemy : MonoBehaviour {

    public GameObject ImpactPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(ImpactPrefab);
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            GameManager.HpBase--;
            Destroy(collision.gameObject.GetComponent<Enemy>().LifeBar);
            Destroy(collision.gameObject);
        }
    }
}
