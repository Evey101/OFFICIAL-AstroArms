﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_move : MonoBehaviour 
{
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //rb.velocity = new Vector2(-25, 0);
        //rb.AddForce(transform.forward, ForceMode2D.Impulse);
        //transform.Translate(.1f, 0, 0);
        rb.AddRelativeForce(new Vector2(5, 0));
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish" || collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

