using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanillaenemyscript : MonoBehaviour 
{
    public Vector2 speed;

	// Use this for initialization
	void Start () 
	{
        speed = new Vector2(0,-8);
	}
	
	// Update is called once per frame
	void Update () 
    {
        GetComponent<Rigidbody2D>().velocity = speed;
	}

 void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player bullet")
        {
            Destroy(gameObject);
        }
    }
}
