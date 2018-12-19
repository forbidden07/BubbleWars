using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBullet : BulletBase
{
    public GameObject impactEffect;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
    public override void HitTarget()
    {
        if (!damageDone)
        {
            Destroy(Instantiate(impactEffect, transform.position, new Quaternion(0, 0, 0, 0)), 1);
            target.GetComponent<EnnemyBase>().EnemyHP -= damage;
        }
        base.HitTarget();
    }
}