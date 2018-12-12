using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public GameObject Camera;
    public static List<GameObject> MesTours = new List<GameObject>();

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        foreach (GameObject tour in MesTours)
        {
            if (MesTours.Count != 0 && Vector3.Distance(tour.transform.position, Camera.transform.position) < 50)
            {
                float a = Vector3.Distance(tour.transform.position, Camera.transform.position) * 2 / 100;
                tour.GetComponentInChildren<AudioSource>().volume = 1 - a;
            }
            else
            {
                tour.GetComponentInChildren<AudioSource>().volume = 0;
            }
        }
    }
}
