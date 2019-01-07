using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParticuleAcideTrain : MonoBehaviour
{
    public GameObject target;

    private void Start()
    {
        if (target)
        {
            StartCoroutine(target.GetComponent<EnnemyBase>().SlowableManagement());
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (Vector3.Distance(item.transform.position, target.transform.position) <= 4)
                {
                    StartCoroutine(item.GetComponent<EnnemyBase>().SlowableManagement());
                }
            }
        }
    }

    private void Update()
    {
        if (target != null)
        {
            transform.position = target.transform.position;
        }
        else
        {
            Destroy(gameObject,2f);
        }
    }
}
