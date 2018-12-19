using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcideBullet : BulletBase
{
    public GameObject PrefabTraineeAcide;
    private GameObject particleTraineeAcide;
    public GameObject PrefabBalleParticule;
    private GameObject BalleParticule;
    public float slowAcide;
    public override void Start()
    {
        base.Start();
        if (PrefabBalleParticule != null)
        {
            BalleParticule = Instantiate(PrefabBalleParticule, transform.position, transform.rotation);
        }
    }

    public override void Update()
    {
        base.Update();
    }
    public override void HitTarget()
    {
        if (!damageDone)
        {
            if (PrefabBalleParticule)
            {
                Destroy(BalleParticule, 0.5f);
            }
            if (PrefabTraineeAcide != null)
            {
                particleTraineeAcide = Instantiate(PrefabTraineeAcide, target.transform.position, target.transform.rotation);
            }
            particleTraineeAcide.GetComponent<ParticuleAcideTrain>().target = target.gameObject;
            Destroy(particleTraineeAcide, lifeTime);
        }
        base.HitTarget();
    }
    public override void ChooseAndHit()
    {
        BalleParticule.transform.position = transform.position;
        base.ChooseAndHit();
    }
}
