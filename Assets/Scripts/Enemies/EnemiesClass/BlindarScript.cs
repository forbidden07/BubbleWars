using UnityEngine;

public class BlindarScript : EnnemyBase
{

    public float MaxArmor;
    private float Armor;
    public GameObject ArmorBarPrefab;
    private GameObject ArmorBar;
    public override float EnemyHP
    {
        get
        {
            return base.EnemyHP;
        }
        set
        {
            if (Armor > 0)
            {
                Armor--;
            }
            else
            {
                base.EnemyHP = value;
            }
        }
    }
    protected override void Start()
    {

        base.Start();
        Slowable = true;
        Armor = MaxArmor;
        ArmorBar = Instantiate(ArmorBarPrefab, base.canvas.transform);
    }

    protected override void Update()
    {
        if (EnemyHP == EnemyHPMax)
        {
            LifeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(30, 2.5f);
        }
        else
        {
            LifeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(EnemyHP / EnemyHPMax * 30, 2.5f);
        }
        base.Update();
        ArmorBarManagment();
    }
    private void ArmorBarManagment()
    {
        if (ArmorBar && Armor > 0)
        {
            ArmorBar.transform.position = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0, -7, 0);
            if (Armor == MaxArmor)
            {
                ArmorBar.GetComponent<RectTransform>().sizeDelta = new Vector2(30, 2.5f);
            }
            else
            {
                ArmorBar.GetComponent<RectTransform>().sizeDelta = new Vector2(Armor / MaxArmor * 30, 2.5f);
            }
        }
        if (Armor <= 0)
        {
            Destroy(ArmorBar);
        }
    }
}
