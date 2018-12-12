using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AcideManagment : MonoBehaviour
{
    public float Slow;
    public List<GameObject> slowEnemys;

    private void Start()
    {

    }

    private void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !other.GetComponent<EnnemyBase>().slowed && other.GetComponent<EnnemyBase>().Slowable)
        {
            slowEnemys.Add(other.gameObject);
            other.GetComponent<NavMeshAgent>().speed *= Slow;
            other.GetComponent<EnnemyBase>().slowed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<NavMeshAgent>().speed = other.gameObject.GetComponent<EnnemyBase>().EnnemyVitesse;
            other.GetComponent<EnnemyBase>().slowed = false;
            slowEnemys.Remove(other.gameObject);
        }
    }
}
