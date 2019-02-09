using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_upscript : MonoBehaviour 
{
    public GameObject storage;
    public playerController script;
    public int goUp;
    public Vector2 up;

	// Use this for initialization
	void Start () 
    {
        storage = GameObject.Find("player");
        script = storage.GetComponent<playerController>();
        goUp = script.grabbing;
        up = new Vector2(0, 3);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (goUp != 2)
        {
            GetComponent<Rigidbody2D>().velocity = -up;
        }
        if (goUp == 2)
        {
            GetComponent<Rigidbody2D>().velocity = up;
        }	
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
