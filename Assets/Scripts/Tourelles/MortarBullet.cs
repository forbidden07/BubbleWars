using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;
using UnityEngine.AI;
using System;

public class MortarBullet : MonoBehaviour
{
    public float firingAngle = 10.0f;
    public float gravity = 5f;
    public Vector3 nextposition;
    public GameObject ExplosionMortar;

    void Start()
    {
       
    }

    public IEnumerator SimulateProjectile(Transform Projectile, Transform target)
    {
        Transform calculateTarget = target.GetChildren("cible");
        Transform Projectil = Instantiate(Projectile.gameObject).transform;
        // Move projectile to the position of throwing object + add some offset if needed.
        Projectil.position = transform.position + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(Projectil.position, calculateTarget.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Sin(2 * firingAngle * Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Sqrt(projectile_Velocity) * Cos(firingAngle * Deg2Rad);
        float Vy = Sqrt(projectile_Velocity) * Sin(firingAngle * Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        Projectil.rotation = Quaternion.LookRotation(calculateTarget.position - Projectil.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            Projectil.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }
        var a = Instantiate(ExplosionMortar,Projectil.transform.position, new Quaternion(0,0,0,0));
        Destroy(Projectil.gameObject);
        a.GetComponent<explosionImpact>().shootedTurret = this.gameObject;
        Destroy(a, 0.5f);
        
    }


}
