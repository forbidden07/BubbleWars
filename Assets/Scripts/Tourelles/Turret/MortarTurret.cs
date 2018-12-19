using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarTurret : TurretBase
{
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
        StartCoroutine(GetComponent<MortarBullet>().SimulateProjectile(bulletPrefab.transform, target));
    }
}
