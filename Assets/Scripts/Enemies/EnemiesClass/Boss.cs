using UnityEngine;

public class Boss : EnnemyBase
{
    private float ScaleOnStart;
    protected override void Start()
    {
        ScaleOnStart = transform.localScale.x;
        Slowable = false;
        base.Start();
    }
    protected override void Update()
    {
        float percentHealh = ((EnemyHP * 100 / EnemyHPMax) / 100) * ScaleOnStart;
        transform.localScale = new Vector3(percentHealh, percentHealh, percentHealh);
        if (EnemyHP == EnemyHPMax)
        {
            LifeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 3.5f);
        }
        else
        {
            LifeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(((EnemyHP * 100 / EnemyHPMax) / 100) * 60, 3.5f);
        }
        base.Update();
    }
}
