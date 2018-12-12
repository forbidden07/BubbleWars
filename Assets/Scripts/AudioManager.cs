using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static List<GameObject> myTurrets = new List<GameObject>();

    private void Start()
    {

    }

    private void Update()
    {
        //sound management for turret
        foreach (GameObject Turret in myTurrets)
        {
            if (myTurrets.Count != 0 && Vector3.Distance(Turret.transform.position, Camera.main.transform.position) < 50)
            {
                float a = Vector3.Distance(Turret.transform.position, Camera.main.transform.position) * 2 / 100;
                Turret.GetComponentInChildren<AudioSource>().volume = 1 - a;
            }
            else
            {
                Turret.GetComponentInChildren<AudioSource>().volume = 0;
            }
        }
    }
}
