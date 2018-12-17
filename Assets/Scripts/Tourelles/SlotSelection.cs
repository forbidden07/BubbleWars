using UnityEngine;
using UnityEngine.EventSystems;

public class SlotSelection : MonoBehaviour
{

    public Material slotMaterialDefault;
    public Material slotMaterialOnMouseOver;
    public GameObject turretPlace;
    public GameObject MenuBuyTurret;
    public bool HasTurret = false;

    private void Start()
    {

    }

    private void Update()
    {
        
    }
    //change material onMouseOver
    
    private void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && !HasTurret)
        {
            GetComponent<Renderer>().material = slotMaterialDefault;
        }
    }
    private void OnMouseExit()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            GetComponent<Renderer>().material = slotMaterialOnMouseOver;
        }
    }
    //check if he has a turret if not build turret
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && !HasTurret)
        {
            if (MenuBuyTurret.activeSelf == true)
            {
                GameManager.slotSelect = gameObject;
            }
            else
            {
                MenuBuyTurret.SetActive(true);
                GameManager.slotSelect = gameObject;
            }
        }
    }
}
