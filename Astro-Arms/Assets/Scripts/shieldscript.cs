using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldscript : MonoBehaviour 
{
    public int hp;
	// Use this for initialization
	void Start () 
    {
        hp = 50;		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (hp == 0)
        {
            Destroy(gameObject);
        }
	}
}
