using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tourelle : MonoBehaviour {

    public float fireRate;
    public float range;
    public int damage;
    public int turretPrice;
    public GameObject CaracTuretPanel;
    public GameObject cameraMain;
    public GameObject MiniTextDamage;
    public GameObject MinitextSpeed;
    GameObject a;
    GameObject canvas;
    

    // Use this for initialization
    void Start () {
        cameraMain = GameObject.Find("Main Camera");
        canvas = GameObject.Find("Canvas");
        a = Instantiate(CaracTuretPanel);
        a.transform.SetParent(canvas.transform);
        MiniTextDamage = a.transform.GetChild(1).gameObject;
        MinitextSpeed = a.transform.GetChild(3).gameObject;

    }
	
	// Update is called once per frame
	void Update () {
        a.transform.position = cameraMain.GetComponent<Camera>().WorldToScreenPoint(transform.position) + new Vector3(0, 55, 0);
        MiniTextDamage.GetComponent<Text>().text = damage.ToString();
        MinitextSpeed.GetComponent<Text>().text = fireRate.ToString();
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            GameManager.SelectedTurret = gameObject;
            if (!GameManager.MenuturretIsVisible)
            {
                GameManager.MenuturretIsVisible = true;
            }
        }
    }
}
