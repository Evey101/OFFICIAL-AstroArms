using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioscript : MonoBehaviour 
{
    public GameObject bg, boss, win, aaa, ooo, eee;
    public float timer;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (ooo.GetComponent<GameManagerScript>().enemyDied < 75 && eee.GetComponent<Cutscene1>().getit == true)
        {
            bg.SetActive(true);
        }
        if (ooo.GetComponent<GameManagerScript>().enemyDied == 75)
        {
            boss.SetActive(true);
            bg.SetActive(false);
        }
        if (aaa.GetComponent<shipscript>().myStatus == shipscript.Status.dead)
        {
            boss.SetActive(false);
        }
        if (aaa.GetComponent<shipscript>().deadtime > 5)
        {
            win.SetActive(true);
        }
	}
}
