using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nalka.Tools.Unity;

public class FireTurret : TurretBase
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
        GameObject FireParticles = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        FireParticles.transform.SetParent(FirePoint);
        FireParticles.transform.localRotation = new Quaternion(0, 180, 0, 0);
        Destroy(FireParticles,0.5f);
       
    }
}
