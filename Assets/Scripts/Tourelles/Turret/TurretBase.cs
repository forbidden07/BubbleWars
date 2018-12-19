using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public abstract class TurretBase : MonoBehaviour
{
    #region Fields
    private float fireCountDown = 0f;
    private GameObject PanelInstance;
    protected Transform target;
    private bool ToolTipTurretActive;
    

    private GameObject Canvas { get { return GameObject.Find("Canvas"); } }
    protected Transform FirePoint
    {
        get
        {
            return transform.GetChildren("firePoint");
        }
    }
    protected GameObject MinitextSpeed { get { return PanelInstance.transform.GetChild(3).gameObject; } }
    protected GameObject MiniTextDamage { get { return PanelInstance.transform.GetChild(1).gameObject; } }
    #endregion

    #region Properties
    public float fireRate;
    public float range;
    public float turnSpeed = 7.5f;
    public int damage;
    public int TurretPrice { get; set; }
    public GameObject CaracTuretPanel;
    public GameObject bulletPrefab;
    private GameObject nearestEnemy = null;
    public Transform PartToRotate;
    #endregion

    #region Unity Methods 
    protected virtual void Start()
    {
        //refresh the target every 0.5 sec
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
        PanelInstance = Instantiate(CaracTuretPanel);
        PanelInstance.transform.SetParent(Canvas.transform);
    }

    protected virtual void Update()
    {
        UIManagment();
        fireCountDown -= Time.deltaTime;
        if (target == null || nearestEnemy == null)
            return;
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        if (fireCountDown <= 0 && Vector3.Distance(nearestEnemy.transform.position, transform.position) <= range)
        {
            Shoot();
            fireCountDown = 1 / fireRate;
        }
       

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.red;
    }
    protected virtual void OnMouseDown()
    {
        //ICI montrer la porter de la tour
    }
    #endregion

    #region Methods
    private void UIManagment()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToolTipTurretActive = !ToolTipTurretActive;
        }
        if (ToolTipTurretActive)
        {
            PanelInstance.SetActive(true);
        }
        else
        {
            PanelInstance.SetActive(false);
        }
        PanelInstance.transform.position = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0, 55, 0);
        MiniTextDamage.GetComponent<Text>().text = damage.ToString();
        MinitextSpeed.GetComponent<Text>().text = fireRate.ToString();
    }
    public virtual void Shoot()
    {
        GetComponent<AudioSource>().Play();
        GameObject bulletGO = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        BulletBase bullet = bulletGO.GetComponent<BulletBase>();
        bullet.damage = damage;
        bullet.Seek(target);
    }
    private void UpdateTarget()
    {
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float DistanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (DistanceToEnemy < shortestDistance)
            {
                shortestDistance = DistanceToEnemy;
                nearestEnemy = enemy;
            }
            else
            {
                target = null;
            }
        }
        if (shortestDistance <= range)
        {
            target = nearestEnemy?.transform;
        }

    }
    #endregion
}
