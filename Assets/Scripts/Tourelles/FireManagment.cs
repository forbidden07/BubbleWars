using UnityEngine;

public class FireManagment : MonoBehaviour
{
    private float timer = 0;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !other.GetComponent<EnnemyBase>().Ignited)
        {
            other.GetComponent<EnnemyBase>().Ignited = true;
        }
    }
}
