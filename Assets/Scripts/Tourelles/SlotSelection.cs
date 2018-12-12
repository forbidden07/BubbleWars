using UnityEngine;
using UnityEngine.EventSystems;

public class SlotSelection : MonoBehaviour
{

    public Material slotMaterialDefault;
    public Material slotMaterialOnMouseOver;
    public GameObject turretPlace;
    private bool HasTurret = false;

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
        if (GameManager.TurretOnBuy == null)
            return;
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (GameManager.Money >= GameManager.TurretPrice && !HasTurret)
            {
                GameObject turret = Instantiate(GameManager.TurretOnBuy, turretPlace.transform.position, turretPlace.transform.rotation);
                GameManager.Money -= GameManager.TurretPrice;
                AudioManager.myTurrets.Add(turret);
                HasTurret = true;
            }
            else
            {
                //peut etre ici afficher un truc du genre le cout de la tourelle est trop elevé
            }
        }
    }
}
