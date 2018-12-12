using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{

    // Use this for initialization
    public float enemyHP;
    private float EnemyHPMax;
    public float enemyVitesse;
    public bool Ralenti;
    public float RalentiTimer;
    public List<Collider> listCollider;
    private GameObject canvas;
    public GameObject LifeBar;
    public GameObject LifeBarPrefab;
    public GameObject DyingParticule;
    private GameObject cameraMain;
    private float ScaleDeBase;

    private void Start()
    {
        ScaleDeBase = this.transform.localScale.x;
        cameraMain = GameObject.Find("Main Camera");
        canvas = GameObject.Find("Canvas");
        LifeBar = Instantiate(LifeBarPrefab);
        LifeBar.transform.SetParent(canvas.transform);
        Ralenti = false;
        EnemyHPMax = enemyHP;
    }

    // Update is called once per frame
    private void Update()
    {
        HealhBarManagment();
        SlowableManagment();
        BossManagement();
    }
    private void BossManagement()
    {
        if (EnemyHPMax > 10000)
        {
            float percentHealh = ((enemyHP * 100 / EnemyHPMax) / 100) * ScaleDeBase;
            this.transform.localScale = new Vector3(percentHealh, percentHealh, percentHealh);
        }
    }
    private void SlowableManagment()
    {
        try
        {
            foreach (Collider item in listCollider)
            {
                if (item == null)
                {
                    listCollider.Remove(item);
                }
            }
        }
        catch (System.Exception)
        {
            //Oui 
        }
        if (listCollider.Count > 0)
        {
            if (!Ralenti)
            {
                GetComponent<NavMeshAgent>().speed *= 0.350f;// other.GetComponent<AcideComportement>().vitesseReduite;
                Ralenti = true;
            }
        }
        else
        {
            this.GetComponent<NavMeshAgent>().speed = enemyVitesse;
            Ralenti = false;
        }
    }
    private void HealhBarManagment()
    {
        if (EnemyHPMax < 1000)
        {
            if (enemyHP == EnemyHPMax)
            {
                LifeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(30, 2.5f);
            }
            else
            {
                LifeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(((enemyHP * 100 / EnemyHPMax) / 100) * 30, 2.5f);
            }
        }
        else
        {
            if (enemyHP == EnemyHPMax)
            {
                LifeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 3.5f);
            }
            else
            {
                LifeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(((enemyHP * 100 / EnemyHPMax) / 100) * 60, 3.5f);
            }
        }

        LifeBar.transform.position = cameraMain.GetComponent<Camera>().WorldToScreenPoint(transform.position) + new Vector3(0, -10, 0);
        if (enemyHP <= 0)
        {
            GameManager.argent++;
            Destroy(LifeBar);
            Outils.Destroyed(gameObject, DyingParticule, 0f);
            return;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Acide")
        {
            listCollider.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        listCollider.Remove(other);
    }

}
