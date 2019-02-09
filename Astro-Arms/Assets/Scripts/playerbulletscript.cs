using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbulletscript : MonoBehaviour 
{
    public Vector2 speed;

	// Use this for initialization
	void Start () 
    {
        //speed = new Vector2(10, 0);
        speed = new Vector2(0, 30);
	}
	
	// Update is called once per frame
	void Update () 
    {
        GetComponent<Rigidbody2D>().velocity = speed;
	}
}
