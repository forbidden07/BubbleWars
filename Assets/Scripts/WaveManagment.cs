using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using static System.Int32;
using UnityEngine.SceneManagement;

public class WaveManagment : MonoBehaviour
{
    public GameObject BoulardPrefab;
    public GameObject FlamerPrefab;
    public GameObject BlindarPrefab;
    public GameObject BoulozorPrefab;
    public Transform Parent;

    private string path;
    private Dictionary<int, GameObject> dico;

    private void Start()
    {
        path = string.Format(@"Assets\Scripts\Resources\{0}.txt", SceneManager.GetActiveScene().name);

        StartCoroutine(Spawn());
        dico = new Dictionary<int, GameObject>()
        {
            { 1, BoulardPrefab },
            { 2, FlamerPrefab},
            { 3, BlindarPrefab},
            { 4, BoulozorPrefab }
        };
    }

    public IEnumerator Spawn()
    {
        List<string> Lines = File.ReadLines(path).ToList();
        yield return new WaitForSeconds(2);
        int i = 0;
        while (i < Lines.Count)
        {
            string[] splittedLine = Lines[i].Split('/');
            SpawnWave(splittedLine[0]);
            yield return new WaitForSeconds(Parse(splittedLine[1] ?? "0"));
            i++;
        }
        yield return new WaitForSeconds(10);
        GetComponent<GameManager>().Victory(GameManager.HpBase > 0 ? true : false); 
    }

    private void SpawnWave(string ennemies)
    {
        foreach (string enemy in ennemies.Split(';'))
        {
            GenererEnnemi(Parse(enemy));
        }
    }

    private void GenererEnnemi(int numeroEnnemi)
    {
        GameObject a = Instantiate(dico[numeroEnnemi], Parent.position, Parent.rotation);
        a.transform.SetParent(Parent);
    }
}
