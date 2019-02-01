using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RechercheManager : MonoBehaviour
{
    //Canon
    private Text CanonDamageText;
    [HideInInspector] public int CanonDamage;
    private Text CanonVitesseText;
    [HideInInspector] public float CanonVitesse;
    //Acide
    private Text AcideVitesseText;
    [HideInInspector] public float AcideVitesse;
    private Text AcideDurationText;
    [HideInInspector] public float AcideSlowPropertie;
    //Mortier
    private Text MortarDamageText;
    [HideInInspector] public int MortierDamage;
    private Text MortarVitesseText;
    [HideInInspector] public float MortierVitesse;
    //Flame
    private Text FlammeDamageText;
    [HideInInspector] public int FlammeDamage;
    private Text FlammeVitesseText;
    [HideInInspector] public float FlammeVitesse;

    public void Start()
    {
        //Canon
        CanonDamageText = GameObject.Find("TextCanonDamage").GetComponent<Text>();
        CanonDamage = 30;
        CanonDamageText.text = $"Damage: {CanonDamage}";
        CanonVitesseText = GameObject.Find("TextCanonVitesse").GetComponent<Text>();
        CanonVitesse = 0.8f;
        CanonVitesseText.text = $"Vitesse d'attaque: {CanonVitesse}";
        //Acide
        AcideVitesseText = GameObject.Find("TextVitesseAcide").GetComponent<Text>();
        AcideVitesse = 0.5f;
        AcideVitesseText.text = $"Vitesse d'attaque: {AcideVitesse}";
        AcideDurationText = GameObject.Find("TextDurationAcide").GetComponent<Text>();
        AcideSlowPropertie = 0.4f;
        AcideDurationText.text = $"Ralentissement: {Mathf.Round(AcideSlowPropertie * 100)}%";
        //Mortier
        MortarDamageText = GameObject.Find("TextMortarDamage").GetComponent<Text>();
        MortierDamage = 15;
        MortarDamageText.text = $"Damage: {MortierDamage}";
        MortarVitesseText = GameObject.Find("TextMortarVitesse").GetComponent<Text>();
        MortierVitesse = 0.6f;
        MortarVitesseText.text = $"Vitesse d'attaque: {MortierVitesse}";
        //Flame
        FlammeDamageText = GameObject.Find("TextDamageFlamme").GetComponent<Text>();
        FlammeDamage = 7;
        FlammeDamageText.text = $"Damage: {FlammeDamage}";
        FlammeVitesseText = GameObject.Find("TextVitesseFlamme").GetComponent<Text>();
        FlammeVitesse = 0.4f;
        FlammeVitesseText.text = $"Vitesse d'attaque: {FlammeVitesse}";

        GameObject.Find("RecherchePanel").SetActive(false);
    }
    #region Recherche

    #region Canon
    public void DegatRechercheCanon()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Canon"))
        {
            item.GetComponent<BasicTurret>().damage += 15;
        }
        CanonDamage += 15;
        CanonDamageText.text = $"Damage: {CanonDamage}";
    }
    public void VitesseRechercheCanon()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Canon"))
        {
            item.GetComponent<BasicTurret>().fireRate += 0.10f;
        }
        CanonVitesse += 0.10f;
        CanonVitesseText.text = $"Vitesse d'attaque: {CanonVitesse}";
    }
    #endregion

    #region LanceAcide
    public void PourcentageRalentieRechercheAcide()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("LanceAcide"))
        {
            item.GetComponent<AcidTurret>().slowPropertion += 0.05f;
        }
        AcideSlowPropertie += 0.05f;
        AcideDurationText.text = $"Ralentissement: {Mathf.Round(AcideSlowPropertie * 100)}%";
    }
    public void VitesseRechercheAcide()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("LanceAcide"))
        {
            item.GetComponent<AcidTurret>().fireRate += 0.10f;
        }
        AcideVitesse += 0.10f;
        AcideVitesseText.text = $"Vitesse d'attaque: {AcideVitesse}";
    }
    #endregion

    #region LanceFlamme
    public void DegatRechercheLanceFlamme()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("LanceFlamme"))
        {
            item.GetComponent<FireTurret>().damage += 10;
        }
        FlammeDamage += 10;
        FlammeDamageText.text = $"Damage: {FlammeDamage}";
    }
    public void VitesseRechercheLanceFlamme()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("LanceFlamme"))
        {
            item.GetComponent<FireTurret>().fireRate += 0.10f;
        }
        FlammeVitesse += 0.10f;
        FlammeVitesseText.text = $"Vitesse d'attaque: {FlammeVitesse}";
    }
    #endregion

    #region Mortier
    public void DegatRechercheMortier()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Mortar"))
        {
            item.GetComponent<MortarTurret>().damage += 10;
        }
        MortierDamage += 15;
        MortarDamageText.text = $"Damage: {MortierDamage}";
    }
    public void VitesseRechercheMortier()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Mortar"))
        {
            item.GetComponent<MortarTurret>().fireRate += 0.10f;
        }
        MortierVitesse += 0.10f;
        FlammeVitesseText.text = $"Vitesse d'attaque: {FlammeVitesse}";
    }
    #endregion

    #endregion
}
