using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcideBullet : BulletBase
{
    public GameObject PrefabTraineeAcide;
    private GameObject particleTraineeAcide;
    public float slowAcide;
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        if (!target)
        {
            Destroy(gameObject);
        }
        base.Update();
    }
    public override void HitTarget()
    {
        if (!damageDone)
        {
            particleTraineeAcide = Instantiate(PrefabTraineeAcide, target.transform.position, target.transform.rotation);
            particleTraineeAcide.GetComponent<ParticuleAcideTrain>().target = target.gameObject;
            Destroy(particleTraineeAcide, lifeTime);
        }
        base.HitTarget();
    }
    public override void ChooseAndHit()
    {
        base.ChooseAndHit();
    }
}
