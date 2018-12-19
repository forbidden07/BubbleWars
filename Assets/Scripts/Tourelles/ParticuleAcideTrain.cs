using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticuleAcideTrain : MonoBehaviour
{
    public GameObject target;

    private void Start()
    {

    }

    private void Update()
    {
        if (target)
        {
            transform.position = target.transform.position;
        }
    }
}
