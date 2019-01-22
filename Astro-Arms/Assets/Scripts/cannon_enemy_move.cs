using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_enemy_move : MonoBehaviour 
{
    public Rigidbody2D rb;
    public bool isleft;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        //if (gameObject.transform.position.x > 0)
        //{
        //    isleft = false;
        //}
        //else
        //{
        //    isleft = true;
        //}

        for (int i = 0; i < 50; i++)
        {
            rb.AddForce(new Vector2(1 + i, -1 + i), ForceMode2D.Force);
        }

	}
}
