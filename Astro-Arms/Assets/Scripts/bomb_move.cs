using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_move : MonoBehaviour
{
    public Rigidbody2D rb;
    public float timer;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        rb.velocity = new Vector2(0, -10);

        if(timer >= 1)
        {
            GetComponent<SpriteRenderer>().color = new Vector4(255, 0, 0, 255);
            transform.localScale = new Vector3(3, 3, 3);
        }

        Destroy(gameObject,3f);
	}
}
