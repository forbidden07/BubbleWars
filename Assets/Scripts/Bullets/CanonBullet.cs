using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBullet : BulletBase {


    public GameObject impactEffect;
    public int damage;

    // Use this for initialization
    public override void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
		
	}
    public override void HitTarget()
    {
        base.HitTarget();
        if (!damageDone)
        {
            GameObject particle = Instantiate(impactEffect, transform.position, new Quaternion(0, 0, 0, 0));
            target.GetComponent<EnnemyBase>().EnemyHP -= damage;
        }
    }
}
