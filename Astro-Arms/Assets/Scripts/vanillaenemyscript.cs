using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanillaenemyscript : MonoBehaviour 
{
    public int hp;
    public Vector2 speed;

	// Use this for initialization
	void Start () 
	{
        speed = new Vector2(0,-5);
	}
	
	// Update is called once per frame
	void Update () 
    {
        GetComponent<Rigidbody2D>().velocity = speed;
	}
}
