using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outils : MonoBehaviour {


    public static void Destroyed(GameObject ObjectDestroy , GameObject Particule , float SecToDestroyParticule)
    {
        GameObject a = Instantiate(Particule, ObjectDestroy.transform.position, ObjectDestroy.transform.rotation);
        Destroy(ObjectDestroy);
        Destroy(a, SecToDestroyParticule);
    }

    public static IEnumerator WaitOneSec()
    {
        yield return new WaitForSeconds(1f);
    }
}