using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public float speed = 150f;
    public GameObject impactEffect;
    public GameObject SiPasTouche;
    public int degat;
    private bool degatfait = false;
    public float tempApparition;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    private void Update()
    {


        if (target == null)
        {
            if (SiPasTouche == null)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                Outils.Destroyed(gameObject, SiPasTouche, tempApparition);
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
        if (!degatfait)
        {
            target.GetComponent<Enemy>().enemyHP -= degat;
            Outils.Destroyed(gameObject, impactEffect, tempApparition);
            degatfait = true;

            //effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
            //Destroy(effectIns, delaiApparition);
            //Destroy(gameObject, delaiApparition);

        }


    }
}
