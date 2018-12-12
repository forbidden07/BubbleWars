using System.Collections;
using UnityEngine;
using static UnityEngine.Object;

public static class Outils
{
    public static void Destroyed(GameObject ObjectDestroy, GameObject Particule, float SecToDestroyParticule)
    {
        GameObject particle = Instantiate(Particule, ObjectDestroy.transform.position, new Quaternion(0,0,0,0));
        Destroy(ObjectDestroy);
        Destroy(particle, SecToDestroyParticule);
    }

    public static IEnumerator WaitOneSec()
    {
        yield return new WaitForSeconds(1f);
    }
    public static Transform GetChildren(this Transform BaseTransform, string name)
    {
        foreach (Transform item in BaseTransform)
        {
            if (item.name == name)
                return item;
            if (item.childCount == 0)
                continue;
            else
            {
                Transform temp = item.GetChildren(name);
                if (temp != null)
                    return temp;
            }
        }
        return null;
    }
}