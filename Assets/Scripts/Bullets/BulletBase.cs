using UnityEngine;
public class BulletBase : MonoBehaviour
{
    [HideInInspector] public Transform target;
    [HideInInspector] public float speed = 10f;
    [HideInInspector] public GameObject NoTouch;
    [HideInInspector] public bool damageDone = false;
    public int lifeTime;
    public GameObject BalleParticule;
    private GameObject Particule;

    public virtual void Start()
    {
        if (BalleParticule != null)
        {
             Particule = Instantiate(BalleParticule, transform.position, transform.rotation);
        }
    }
    public void Seek(Transform _target)
    {
        target = _target;
    }
    
    public virtual void Update()
    {
        ChooseAndHit();
    }
    
    public void ChooseAndHit()
    {
        if (Particule != null)
        {
            Particule.transform.position = transform.position;
        }
        if (target == null)
        {
            if (NoTouch == null)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                Outils.Destroyed(gameObject, NoTouch, lifeTime);
                return;
            }
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    public virtual void HitTarget()
    {
        if (!damageDone)
        {
           
            Destroy(gameObject);
            Destroy(particle, lifeTime);
            if (BalleParticule)
            {
                Destroy(Particule, 0.5f);
            }
            damageDone = true;
        }
    }
}
