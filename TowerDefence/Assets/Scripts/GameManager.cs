using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region propriété GameObject/Transform
    public static GameObject TurretOnBuy;
    public static GameObject slotSelect;
    public static GameObject SelectedTurret;
    public GameObject EnemyPrefab;
    public GameObject BossPrefab;
    public GameObject cameraMain;
    public GameObject MenuTurret;
    public GameObject Simpleturret;
    public GameObject AcideTurret;
    public GameObject MortierTurret;
    public Transform Depart;
    #endregion
    #region propriété Integer
    public static int CoutTurret;
    public static int argent;
    public static int HpBase;
    public int tours;
    public int NombreAPop;
    public int BeginHPBase;
    public float Timer;
    public float TimerPop;
    #endregion
    #region propriété Bool
    public static bool MenuturretIsVisible = false;
    #endregion
    #region propriété UI
    public Text argentText;
    public Text HPbase;
    public Text GameOver;
    public Text TextDamage;
    public Text textSpeed;
    #endregion
    private void Start()
    {
        CoutTurret = 0;
        HpBase = BeginHPBase;
        //test
        //GameObject a = Instantiate(BossPrefab, Depart.position, Depart.rotation);
        //a.transform.SetParent(Depart);
        //a.transform.localPosition = new Vector3(0, 0, 0);
        //a.GetComponent<NavMeshAgent>().speed = 7.5f;
        //a.GetComponent<Enemy>().enemyHP = 100000;
        StartCoroutine(Spawn(20, 5, 10, 30, 25));
        //test
        Timer = 0;
        tours = 1;
        TimerPop = Timer;
        argent = 600;
    }
    private void Update()
    {
        CameraControle();
        GestionTextUI();
        if (HpBase <= 0)
        {
            GameOver.gameObject.SetActive(true);
        }
    }
    #region Methode Enemies voué a disparaitre d'ici
    public IEnumerator Spawn(int vagueEnemy, int nbEnnemis, int secsToWait, int PV, float vitesse)
    {
        for (int i = 0; i < vagueEnemy; i++)
        {
            yield return new WaitForSeconds(secsToWait);
            SpawnEnemy(nbEnnemis, 25, PV);
            nbEnnemis += 3;
            PV += 5;
        }
        yield return new WaitForSeconds(secsToWait);
        GameObject a = Instantiate(BossPrefab, Depart.position, Depart.rotation);
        a.transform.SetParent(Depart);
        a.transform.localPosition = new Vector3(0, 0, 0);
        a.GetComponent<NavMeshAgent>().speed = 7.5f;
        a.GetComponent<Enemy>().enemyHP = 100000;
    }
    public void SpawnEnemy(int enemy, float vitesseEnemy, int PV)
    {
        for (int i = 0; i < enemy; i++)
        {
            GameObject a = Instantiate(EnemyPrefab, Depart.position, Depart.rotation);
            a.transform.SetParent(Depart);
            a.transform.localPosition = new Vector3(0, 0, 0);
            a.GetComponent<NavMeshAgent>().speed = vitesseEnemy;
            a.GetComponent<Enemy>().enemyHP = PV;

        }
    }
    public void GestionTimer()
    {
        if (Timer > 5)
        {
            TimerPop += Time.deltaTime;
            if (TimerPop >= 0.9)
            {
                NombreAPop++;
                GameObject a = Instantiate(EnemyPrefab, Depart.position, Depart.rotation);
                a.transform.SetParent(Depart);
                a.transform.localPosition = new Vector3(0, 0, 0);
                TimerPop = 0;
            }
        }
        if (Timer >= 5 + tours)
        {
            Timer = 0;
            tours++;
            NombreAPop = 0;
        }
    }
    #endregion
    #region Methode Controle
    private void CameraControle()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            cameraMain.transform.position += new Vector3(0, 0, 70 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            cameraMain.transform.position += new Vector3(0, 0, -70 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            cameraMain.transform.position += new Vector3(-70 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cameraMain.transform.position += new Vector3(70 * Time.deltaTime, 0, 0);
        }
    }
    #endregion
    #region Methode UI
    public void GestionTextUI()
    {
        argentText.text = string.Format("Argent: {0}", argent.ToString());
        HPbase.text = string.Format("PV: {0}", HpBase);

        if (SelectedTurret)
        {
            MenuTurret.transform.position = cameraMain.GetComponent<Camera>().WorldToScreenPoint(SelectedTurret.transform.position);
            TextDamage.text = SelectedTurret.GetComponent<Tourelle>().damage.ToString();
            textSpeed.text = SelectedTurret.GetComponent<Tourelle>().fireRate.ToString();

            if (MenuturretIsVisible)
            {
                MenuTurret.SetActive(true);
                MenuTurret.transform.position = cameraMain.GetComponent<Camera>().WorldToScreenPoint(SelectedTurret.transform.position);
            }
            else
            {
                MenuTurret.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
                MenuTurret.SetActive(false);
            }
        }
    }
    #endregion
    #region Methode Button
    public void ChoixTurretSimple()
    {
        TurretOnBuy = Simpleturret;
        CoutTurret = 8;
    }
    public void ChoixTurretAcide()
    {
        TurretOnBuy = AcideTurret;
        CoutTurret = 20;
    }
    public void ChoixTurretMortier()
    {
        TurretOnBuy = MortierTurret;
        CoutTurret = 20;
    }
    public void UpgradeDamageAttack()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (GameManager.argent >= 5)
            {
                SelectedTurret.GetComponent<Tourelle>().damage += 5;
                GameManager.argent -= 5;
            }
        }
    }
    public void UpgradeSpeedAttaque()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (GameManager.argent >= 5)
            {
                SelectedTurret.GetComponent<Tourelle>().fireRate += 0.10f;
                GameManager.argent -= 5;
            }
        }
    }
    #endregion
}
