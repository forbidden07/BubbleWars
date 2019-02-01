using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMenuText : MonoBehaviour
{
    private Text CoutBasic;
    private Text CoutAcide;
    private Text CoutMortar;
    private Text CoutFlame;
    private GameManager gameManager;

    private void Start()
    {
        CoutBasic = GameObject.Find("TextCoutBasic").GetComponent<Text>();
        CoutAcide = GameObject.Find("TextCoutAcide").GetComponent<Text>();
        CoutMortar = GameObject.Find("TextCoutMortar").GetComponent<Text>();
        CoutFlame = GameObject.Find("TextCoutFlame").GetComponent<Text>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        CoutBasic.text = gameManager.turretPriceBasic.ToString();
        CoutAcide.text = gameManager.turretPriceAcide.ToString();
        CoutMortar.text = gameManager.turretPriceMortar.ToString();
        CoutFlame.text = gameManager.turretPriceFlame.ToString();

    }
}
