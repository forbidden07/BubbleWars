using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidTurret : TurretBase
{
    public float slowPropertion;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }
    public override void Shoot()
    {
        GetComponent<AudioSource>().Play();
        GameObject bulletGO = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        bulletGO.GetComponent<AcideBullet>().slowAcide = this.slowPropertion;
        bulletGO.GetComponent<AcideBullet>().Seek(target);
    }
}
