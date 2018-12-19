using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticuleAcideTrain : MonoBehaviour
{

    public GameObject target;

    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = target.transform.position;
    }
}
