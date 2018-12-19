using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcideBullet : BulletBase {


    public float slowAcide;
    // Use this for initialization
    public override void Start () {
		
	}
	
	// Update is called once per frame
	public override void  Update () {
		
	}
    public override void HitTarget()
    {
        base.HitTarget();
        if (!damageDone)
        {
            particle.GetComponent<ParticuleAcideTrain>().target = target.gameObject;
            Destroy(particle, lifeTime);
        }
    }
}
