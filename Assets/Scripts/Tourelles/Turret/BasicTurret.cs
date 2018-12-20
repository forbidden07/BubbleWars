using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BasicTurret : TurretBase
{
    public GameObject flameParticlesPrefab;
    private float TempEclair;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (TempEclair >= 0 && TempEclair <= 60)
        {
            TempEclair -= Time.deltaTime * 100;

            flameParticlesPrefab.GetComponent<Light>().range = TempEclair;
        }
        base.Update();
    }
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }
    public override void Shoot()
    {
        base.Shoot();
        TempEclair = 20;
        //GameObject a = Instantiate(flameParticlesPrefab, FirePoint);
        //a.transform.localPosition = FirePoint.localPosition;
        //Destroy(a, 1);
    }
}
