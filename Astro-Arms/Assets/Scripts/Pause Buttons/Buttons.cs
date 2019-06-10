using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour 
{
    public GameObject Player;
	// Use this for initialization
	void Start () 
    {
        Player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
    public void Resume()
    {
        Player.GetComponent<playerController>().pause = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        SceneManager.LoadScene(1);
    }
}
