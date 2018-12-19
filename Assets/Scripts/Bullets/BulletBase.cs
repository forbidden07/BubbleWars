using UnityEngine;
public abstract class BulletBase : MonoBehaviour
{
    [HideInInspector] public Transform target;
    public float speed = 10f;
    public int damage;
    [HideInInspector] public bool damageDone = false;
    public int lifeTime;

    public virtual void Start()
    {

    }
    public void Seek(Transform _target)
    {
        target = _target;
    }

    public virtual void Update()
    {
        ChooseAndHit();
    }

    public virtual void ChooseAndHit()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
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
            damageDone = true;
        }
    }
}
