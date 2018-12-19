using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region champs
    private static int _money;
    private static int _hpBase;
    private GameObject Sun;
    #endregion

    #region propriété GameObject/Transform
    // public static GameObject TurretOnBuy;
    public static GameObject slotSelect;
    public GameObject SimpleTurret;
    public GameObject AcideTurret;
    public GameObject MortierTurret;
    public GameObject FlamerTurret;
    public Transform Depart;
    public GameObject MenuBuyTurret;
    public GameObject SearchPanel;

    #endregion

    #region propriété Integer
    // public static int TurretPrice
    //{
    //get { return TurretOnBuy.GetComponent<TurretBase>().TurretPrice; }
    // set { TurretOnBuy.GetComponent<TurretBase>().TurretPrice = value; }
    //}
    public static int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
            ArgentText.text = $"{value}";
        }
    }
    public static int HpBase
    {
        get
        {
            return _hpBase;
        }
        set
        {
            _hpBase = value;
            HPbaseText.text = $"{value}";
        }
    }
    public int MoneyBegin;
    public int tours = 1;
    public int NombreAPop;
    public int BeginHPBase;
    public float timerSun = 0;
    #endregion

    #region propriété Bool

    #endregion

    #region propriété UI
    public static Text ArgentText { get { return GameObject.Find("TextArgent").GetComponent<Text>(); } }
    public static Text HPbaseText { get { return GameObject.Find("TextVieBase").GetComponent<Text>(); } }
    public GameObject EndPanel;
    #endregion

    private void Start()
    {
        HpBase = BeginHPBase;
        Money = MoneyBegin;
        Sun = GameObject.Find("Directional Light");
        Sun.GetComponent<Light>().color = new Color(1, 0.5f, 0, 1);
    }
    private void Update()
    {
        RotationSun();
        CameraControle();
        if (HpBase <= 0)
        {
            Victory(false);
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (MenuBuyTurret.activeSelf == true)
            {
                MenuBuyTurret.SetActive(false);
            }
        }
        MenuTurretBuy();
    }

    #region Methode Controle
    //Controle of the Camera.
    private void CameraControle()
    {
        Transform cameraPosition = Camera.main.transform.parent.transform;

        #region ZQSD
        if (Input.GetKey(KeyCode.Z))
        {
            cameraPosition.Translate(0, 0, 70 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            cameraPosition.Translate(0, 0, -70 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            cameraPosition.Translate(-70 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cameraPosition.Translate(70 * Time.deltaTime, 0, 0);
        }
        #endregion

        #region Zoom
        if (Camera.main.transform.position.y < 15)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                Camera.main.transform.localPosition += (Vector3.up + Vector3.back) * 3;
            }
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                Camera.main.transform.localPosition -= (Vector3.up + Vector3.back) * 3;
            }
        }

        if (Camera.main.transform.position.y > 55)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                Camera.main.transform.localPosition -= (Vector3.up + Vector3.back) * 3;
            }
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                Camera.main.transform.localPosition += (Vector3.up + Vector3.back) * 3;
            }
        }
        #endregion

        #region TurnCamera
        if (Input.GetMouseButton(2))
        {
            cameraPosition.transform.Rotate(0, Input.GetAxis("Mouse X") * 50 * Time.deltaTime, 0);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        #endregion
    }
    #endregion

    #region Methode UI
    public void Victory(bool winOrLose)
    {
        EndPanel.SetActive(true);
        if (winOrLose)
        {
            EndPanel.transform.GetChildren("TextVictoryOrDefeat").GetComponent<Text>().text = "Victory";
            //win
        }
        else
        {
            EndPanel.transform.GetChildren("TextVictoryOrDefeat").GetComponent<Text>().text = "Defeat";
            //lose
        }
    }
    public void MenuTurretBuy()
    {
        if (slotSelect)
        {
            slotSelect.GetComponent<SlotSelection>().MenuBuyTurret.transform.position = Camera.main.WorldToScreenPoint(slotSelect.transform.position) + new Vector3(0, 55, 0);
        }
    }

    public float otherTimer = 1;
    public void RotationSun()
    {
        timerSun -= Time.deltaTime /2;
        Sun.transform.rotation = Quaternion.Euler(timerSun - 180, 90, 0);
        if (timerSun <= 0)
        {
            timerSun = 360;
        }
        if (timerSun - 160 >= 180 && timerSun - 160 <= 225)
        {
            otherTimer -= Time.deltaTime / 45;
            Sun.GetComponent<Light>().color = Color.Lerp(new Color(0.862f, 0.768f, 0.55f, 1), new Color(1, 0.4f, 0, 1), otherTimer);
        }
        if (timerSun - 160 >= 0 && timerSun - 160 <= 45)
        {
            otherTimer -= Time.deltaTime / 45;
            Sun.GetComponent<Light>().color = Color.Lerp(new Color(0.862f, 0.768f, 0.55f, 1), new Color(1, 0.4f, 0, 1), otherTimer);
        }
    }
    #endregion 

    #region Methode Button
    // choice of turret.
    public void ChoixTurretSimple()
    {
        if (Money >= 8 && slotSelect.GetComponent<SlotSelection>().HasTurret == false)
        {
            GameObject turret = Instantiate(SimpleTurret, slotSelect.GetComponent<SlotSelection>().turretPlace.transform.position, slotSelect.GetComponent<SlotSelection>().turretPlace.transform.rotation);
            Money -= 8;
            AudioManager.myTurrets.Add(turret);
            slotSelect.GetComponent<SlotSelection>().HasTurret = true;
            MenuBuyTurret.SetActive(false);
        }
    }
    public void ChoixTurretAcide()
    {
        if (Money >= 15 && slotSelect.GetComponent<SlotSelection>().HasTurret == false)
        {
            GameObject turret = Instantiate(AcideTurret, slotSelect.GetComponent<SlotSelection>().turretPlace.transform.position, slotSelect.GetComponent<SlotSelection>().turretPlace.transform.rotation);
            Money -= 15;
            AudioManager.myTurrets.Add(turret);
            slotSelect.GetComponent<SlotSelection>().HasTurret = true;
            MenuBuyTurret.SetActive(false);
        }
    }
    public void ChoixTurretMortier()
    {
        if (Money >= 20 && slotSelect.GetComponent<SlotSelection>().HasTurret == false)
        {
            GameObject turret = Instantiate(MortierTurret, slotSelect.GetComponent<SlotSelection>().turretPlace.transform.position, slotSelect.GetComponent<SlotSelection>().turretPlace.transform.rotation);
            Money -= 20;
            AudioManager.myTurrets.Add(turret);
            slotSelect.GetComponent<SlotSelection>().HasTurret = true;
            MenuBuyTurret.SetActive(false);
        }
    }
    public void ChoixTurretFlamer()
    {
        if (Money >= 15 && slotSelect.GetComponent<SlotSelection>().HasTurret == false)
        {
            GameObject turret = Instantiate(FlamerTurret, slotSelect.GetComponent<SlotSelection>().turretPlace.transform.position, slotSelect.GetComponent<SlotSelection>().turretPlace.transform.rotation);
            Money -= 15;
            AudioManager.myTurrets.Add(turret);
            slotSelect.GetComponent<SlotSelection>().HasTurret = true;
            MenuBuyTurret.SetActive(false);
        }
    }
    //management Open Menu.
    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuDepart");
    }
    public void GoToMenuAtEnd()
    {
        SceneManager.LoadScene("MenuDepart");
        //ici ajouter les sous si win sinon rien
    }
    public void GoToTurretMenu()
    {
        SceneManager.LoadScene("MenuDepart");
        //bha ... aller a l'amélioration des turret + ajouter sous si win
    }
    public void GoForReloadSame()
    {
        string CurrentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(CurrentSceneName, LoadSceneMode.Single);
        //ajoute les sous si win et relance la meme scene
    }
    public void OpenCloseSearchPanel()
    {
        if (SearchPanel.activeInHierarchy) { SearchPanel.SetActive(false); }
        else { SearchPanel.SetActive(true); }
    }
    #endregion

}
