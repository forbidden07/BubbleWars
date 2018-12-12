using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GestionLvl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LvlOne()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LvlTwo()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LvlThree()
    {
        SceneManager.LoadScene("Level3");
    }
    public void LvlFour()
    {
        SceneManager.LoadScene("Level4");
    }
    public void LvlFive()
    {
        SceneManager.LoadScene("Level5");
    }
    public void LvlSix()
    {
        SceneManager.LoadScene("Level6");
    }
    public void LvlSeven()
    {
        SceneManager.LoadScene("Level7");
    }
    public void LvlEight()
    {
        SceneManager.LoadScene("Level8");
    }
    public void LvlNine()
    {
        SceneManager.LoadScene("Level9");
    }


}
