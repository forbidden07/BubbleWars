using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Direction : MonoBehaviour {

    // Use this for initialization
    NavMeshAgent agent;
    public Transform Destination;

	void Start () {
        Destination = GameObject.Find("Base").transform;
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.destination = Destination.position;
        if (Vector3.Distance(Destination.position , this.transform.position) < 10)
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
