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
    #endregion

    #region propriété GameObject/Transform
    public static GameObject TurretOnBuy;
    public static GameObject slotSelect;
    public static GameObject SelectedTurret;
    public GameObject MenuTurret;
    public GameObject SimpleTurret;
    public GameObject AcideTurret;
    public GameObject MortierTurret;
    public GameObject FlamerTurret;
    public Transform Depart;
    #endregion

    #region propriété Integer
    public static int TurretPrice
    {
        get { return TurretOnBuy.GetComponent<TurretBase>().TurretPrice; }
        set { TurretOnBuy.GetComponent<TurretBase>().TurretPrice = value; }
    }
    public static int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
            ArgentText.text = $"Argent: {value}";
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
            HPbaseText.text = $"PV: {value}";
        }
    }
    public int tours = 1;
    public int NombreAPop;
    public int BeginHPBase;
    #endregion

    #region propriété Bool
    public static bool MenuturretIsVisible = false;
    #endregion

    #region propriété UI
    public static Text ArgentText { get { return GameObject.Find("TextArgent").GetComponent<Text>(); } }
    public static Text HPbaseText { get { return GameObject.Find("TextVieBase").GetComponent<Text>(); } }
    public Text GameOver;
    public Text TextDamage;
    public Text textSpeed;
    public GameObject EndPanel;
    #endregion

    private void Start()
    {
        HpBase = BeginHPBase;
        Money = 60;
    }
    private void Update()
    {
        CameraControle();
        GestionTextUI();
        if (HpBase <= 0 || Input.GetKeyDown(KeyCode.A))
        {
            Victory(false);
        }
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
        if (Input.GetMouseButton(1))
        {
            cameraPosition.transform.Rotate(0, Input.GetAxis("Mouse X") * 50 * Time.deltaTime,0);
            Cursor.lockState = CursorLockMode.Locked;
        }else
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
    public void GestionTextUI()
    {
        if (SelectedTurret)
        {
            MenuTurret.transform.position = Camera.main.WorldToScreenPoint(SelectedTurret.transform.position);
            TextDamage.text = SelectedTurret.GetComponent<TurretBase>().damage.ToString();
            textSpeed.text = SelectedTurret.GetComponent<TurretBase>().fireRate.ToString();
            MenuTurret.SetActive(MenuturretIsVisible);
            if (MenuturretIsVisible)
            {
                MenuTurret.transform.position = Camera.main.WorldToScreenPoint(SelectedTurret.transform.position);
            }
            else
            {
                MenuTurret.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            }
        }
    }
    #endregion

    #region Methode Button
    // choice of turret.
    public void ChoixTurretSimple()
    {
        TurretOnBuy = SimpleTurret;
        TurretPrice = 8;
    }
    public void ChoixTurretAcide()
    {
        TurretOnBuy = AcideTurret;
        TurretPrice = 20;
    }
    public void ChoixTurretMortier()
    {
        TurretOnBuy = MortierTurret;
        TurretPrice = 20;
    }
    public void ChoixTurretFlamer()
    {
        TurretOnBuy = FlamerTurret;
        TurretPrice = 15;
    }
    //Turret enhancement.
    public void UpgradeDamageAttack()
    {
        if (EventSystem.current.IsPointerOverGameObject() && Money >= 5)
        {
            SelectedTurret.GetComponent<TurretBase>().damage += 15;
            Money -= 5;
        }
    }
    public void UpgradeSpeedAttaque()
    {
        if (EventSystem.current.IsPointerOverGameObject() && Money >= 5)
        {
            SelectedTurret.GetComponent<TurretBase>().fireRate += 0.10f;
            Money -= 5;
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
    #endregion

}
