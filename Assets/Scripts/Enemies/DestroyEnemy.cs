using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject ImpactPrefab;
    
    private void Start()
    {

    }
    
    private void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject a = Instantiate(ImpactPrefab, transform.position , transform.rotation);
            a.transform.LookAt(collision.transform.position + new Vector3(0,20,0));
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            GameManager.HpBase--;
            Destroy(collision.gameObject.GetComponent<EnnemyBase>().LifeBar);
            Destroy(collision.gameObject);
        }
    }
}
