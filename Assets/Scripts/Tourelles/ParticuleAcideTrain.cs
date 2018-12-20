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
        }
        
    }

    private void Update()
    {
        if (target)
        {
            transform.position = target.transform.position;
        }
    }
}
