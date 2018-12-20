using UnityEngine;
using UnityEngine.AI;

public class BasicEnnemy : EnnemyBase
{

    protected override void Start()
    {
        Slowable = true;
        base.Start();
    }

    protected override void Update()
    {
        if (EnemyHP == EnemyHPMax)
        {
            LifeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(30, 2.5f);
        }
        else
        {
            LifeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(((EnemyHP * 100 / EnemyHPMax) / 100) * 30, 2.5f);
        }
        base.Update();
    }
}
