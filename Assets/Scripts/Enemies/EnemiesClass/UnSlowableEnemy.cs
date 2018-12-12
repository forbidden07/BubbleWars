using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnSlowableEnemy : EnnemyBase {

    // Use this for initialization
    protected override void  Start () {
        base.Start();
        Slowable = false;
    }

    // Update is called once per frame
    protected override void Update ()
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
