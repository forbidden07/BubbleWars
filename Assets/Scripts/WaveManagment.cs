using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Int32;

public class WaveManagment : MonoBehaviour
{
    //EnemyPrefab
    public GameObject BoulardPrefab;
    public GameObject FlamerPrefab;
    public GameObject BlindarPrefab;
    public GameObject BoulozorPrefab;
    //Depart
    public Transform Parent;
    private string path;
    private Dictionary<int, GameObject> dico;
    private bool isLastWave;

    //UI
    private Text WaveTimer;

    private void Start()
    {
        path = string.Format(@"Assets\Scripts\Resources\{0}.txt", SceneManager.GetActiveScene().name);
        WaveTimer = GameObject.Find("WaveTimer").GetComponent<Text>();
        StartCoroutine(Spawn());
        dico = new Dictionary<int, GameObject>()
        {
            { 1, BoulardPrefab },
            { 2, FlamerPrefab},
            { 3, BlindarPrefab},
            { 4, BoulozorPrefab }
        };
    }
    private void Update()
    {
        if (isLastWave && GameObject.FindGameObjectsWithTag("Enemy").Count() <= 0)
        {
            GetComponent<GameManager>().Victory(GameManager.HpBase > 0 ? true : false);
        }
    }

    public IEnumerator Spawn()
    {
        List<string> Lines = File.ReadLines(path).ToList();
        StartCoroutine(TimerWave(10));
        yield return new WaitForSeconds(10);
        int i = 0;
        while (i < Lines.Count)
        {
            string[] splittedLine = Lines[i].Split('/');
            SpawnWave(splittedLine[0]);
            StartCoroutine(TimerWave(Parse(splittedLine[1] ?? "0")));
            yield return new WaitForSeconds(Parse(splittedLine[1] ?? "0"));
            i++;
        }
        isLastWave = true;
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

    public IEnumerator TimerWave(int temp)
    {
        while (temp > 0)
        {

            WaveTimer.text = temp.ToString();
            yield return new WaitForSeconds(1);
            temp--;
        }
        yield break;
    }
}
