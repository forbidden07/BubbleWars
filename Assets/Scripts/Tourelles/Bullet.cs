using UnityEngine;
using Nalka.Tools.Unity;
public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 150f;
    public GameObject impactEffect;
    public GameObject NoTouch;
    public int damage;
    private bool damageDone = false;
    public int lifeTime;
    public float slowAcide;

    public void Seek(Transform _target)
    {
        target = _target;
    }
    
    private void Update()
    {
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
            particle.transform.SetParent(GameObject.Find("Acides").transform);
            if (gameObject.name == "BalleAcid")
            {
                particle.GetComponent<AcideManagment>().Slow = slowAcide;
                
            }
            Destroy(gameObject);
            Destroyer.Destroy(particle, lifeTime);
            damageDone = true;
        }
    }
}
