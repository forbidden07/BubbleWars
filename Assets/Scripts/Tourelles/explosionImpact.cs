using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class explosionImpact : MonoBehaviour
{

    public GameObject shootedTurret;
    private List<GameObject> ImpactenemyList = new List<GameObject>();

    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (!ImpactenemyList.Contains(other.gameObject) && other && other.tag == "Enemy")
        {
            other.GetComponent<EnnemyBase>().EnemyHP -= shootedTurret.GetComponent<TurretBase>().damage;
            ImpactenemyList.Add(other.gameObject);
        }
    }
}
