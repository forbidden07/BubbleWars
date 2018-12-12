using UnityEngine;
using UnityEngine.AI;

public class Direction : MonoBehaviour
{
    private NavMeshAgent Agent { get { return GetComponent<NavMeshAgent>(); } }
    public Transform Destination;

    private void Start()
    {
        Destination = GameObject.Find("Base").transform;
    }

    private void Update()
    {
        Agent.destination = Destination.position;
        if (Vector3.Distance(Destination.position, transform.position) < 10)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
