using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupscript : MonoBehaviour 
{
    public GameObject storage;
    public playerController script;

    public Vector2 speed;
    public bool thrown;

    public int powerID;

	// Use this for initialization
	void Start () 
    {
        storage = GameObject.Find("Player Manager");
        script = storage.GetComponent<playerController>();
        speed = new Vector2(0, .5f); // speed for throwing
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (script.grabbing == 2)
        {
            thrown = true; // when it is thrown
        }
        if (thrown == true && powerID == script.powerID) // this is so that only the powerup that is instantiated goes up
        {
            transform.Translate(speed);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (script.grabbing == 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
