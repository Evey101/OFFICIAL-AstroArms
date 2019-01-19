using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
    public void LevelSelectScreen()
    {
        SceneManager.LoadScene(0);
    }
    public void YouLost()
    {
        
    }
    public void YouWin()
    {
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
