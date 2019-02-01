using Nalka.Tools.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnnemyBase : MonoBehaviour
{
    public bool Slowable;
    public bool slowed = false;
    private bool _ignited;
    public bool Ignited
    {
        get { return _ignited; }
        set
        {
            _ignited = value;
            if (Ignited)
            {
                StartCoroutine(IgniteManagement());
            }
        }
    }
    [SerializeField]
    private float _enemyHP;
    public virtual float EnemyHP
    {
        get
        {
            return _enemyHP;
        }
        set
        {
            _enemyHP = value;
        }
    }
    public float EnemyHPMax;
    public float EnnemyVitesse;
    public float slowTimer;
    private float IgniteTimer = 0;
    public int earningsOnDestroy;
    public static List<GameObject> listSlowerZone
    {
        get { return GameObject.FindGameObjectsWithTag("Acide").ToList(); }
    }
    public GameObject LifeBarPrefab;
    public GameObject DyingParticule;
    [HideInInspector]
    public GameObject LifeBar;
    [HideInInspector]
    protected GameObject canvas;

    protected virtual void Start()
    {
        //Destroyer.Destroyed.AddHandler<EnnemyBase>(InstantiateOnDestroy);
        canvas = GameObject.Find("Canvas");
        LifeBar = Instantiate(LifeBarPrefab);
        LifeBar.transform.SetParent(canvas.transform);
        EnemyHP = EnemyHPMax;
    }

    protected virtual void Update()
    {
        HealhBarManagment();
    }

    protected void HealhBarManagment()
    {
        LifeBar.transform.position = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0, -10, 0);
        if (EnemyHP <= 0)
        {
            GameManager.Money += earningsOnDestroy;
            Destroy(LifeBar);
            Outils.Destroyed(gameObject, DyingParticule, 1f);
            // Destroyer.Destroy(gameObject);
        }
    }

    //public IEnumerator
    public IEnumerator IgniteManagement()
    {
        if (Ignited)
        {
            Ignited = false;
            transform.GetChildren("IgniteParticule").gameObject.SetActive(true);
            int i = 0;
            while (i < 4)
            {
                yield return new WaitForSeconds(1);
                EnemyHP -= GameObject.Find("GameManager").GetComponent<RechercheManager>().FlammeDamage;
                i++;
            }
            transform.GetChildren("IgniteParticule").gameObject.SetActive(false);

        }
        yield return null;
    }
    public IEnumerator SlowableManagement()
    {
        if (Slowable && !slowed)
        {
            GetComponent<NavMeshAgent>().speed *= GameObject.Find("GameManager").GetComponent<RechercheManager>().AcideSlowPropertie;
            slowed = true;
            yield return new WaitForSeconds(3);
            try
            {
                if (!gameObject)
                {
                    StopCoroutine(SlowableManagement());
                }
                else
                {
                    GetComponent<NavMeshAgent>().speed = EnnemyVitesse;
                    slowed = false;
                    StopCoroutine(SlowableManagement());
                }
            }
            catch (Exception)
            {
            }
        }
        StopCoroutine(SlowableManagement());
        yield return null;
    }
}