using UnityEngine;
public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 10f;
    public GameObject impactEffect;
    public GameObject NoTouch;
    public int damage;
    private bool damageDone = false;
    public int lifeTime;
    public float slowAcide;
    public GameObject BalleParticule;
    private GameObject Particule;

    public void Start()
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
    
    private void Update()
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
    
    private void HitTarget()
    {
        if (!damageDone)
        {
            target.GetComponent<EnnemyBase>().EnemyHP -= damage;
            GameObject particle = Instantiate(impactEffect, transform.position, new Quaternion(0, 0, 0, 0));
            //particle.transform.SetParent(GameObject.Find("Acides").transform);
            Destroy(gameObject);
            Destroy(particle, lifeTime);
            //Destroyer.Destroyed.AddHandler<Object>(e => Debug.Log("salut"));
            if (BalleParticule)
            {
                Destroy(Particule, 0.5f);
            }
            damageDone = true;
        }
    }
}
