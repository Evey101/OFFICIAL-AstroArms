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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "ship")
        {
            GameObject.Find("SHIPS").GetComponent<shipscript>().hp -= 1;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "weak points")
        {
            GameObject.Find("SHIPS").GetComponent<shipscript>().hp -= 5;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "shield")
        {
            GameObject.Find("SHIPS").GetComponent<shipscript>().shieldhp -= 1;
            Destroy(gameObject);

        }
    }

}
