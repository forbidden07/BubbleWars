using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotSelection : MonoBehaviour {

    public Material onMouse;
    public Material onRien;
    public GameObject emplacement;
    private bool HaveTurret;
	// Use this for initialization
	void Start () {
        HaveTurret = false;
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && !HaveTurret)
        {
            this.GetComponent<Renderer>().material = onMouse;
        }
    }
    private void OnMouseExit()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            this.GetComponent<Renderer>().material = onRien;
        }
    }
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (GameManager.TurretOnBuy == null) return;
            if (GameManager.argent >= GameManager.CoutTurret && !HaveTurret)
            {
                GameObject turret = Instantiate(GameManager.TurretOnBuy, emplacement.transform.position, emplacement.transform.rotation);
                GameManager.argent -= GameManager.CoutTurret;
                AudioManager.MesTours.Add(turret);
                HaveTurret = true;
            }
            else
            {
                //peut etre ici afficher un truc du genre le cout de la tourelle est trop elevé
            }
        }
    }
}
