using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour 
{
    public GameObject earth, spaceScrolling,spaceScrolling1;
    public Vector2 planetScrollSpeed, spaceSrollSpd;
	// Use this for initialization
	void Start () 
    {
        planetScrollSpeed = new Vector2(0, -0.05f);
        spaceSrollSpd = new Vector2(0, -1);
	}
	
	// Update is called once per frame
	void Update () 
    {
        earth.transform.Translate(planetScrollSpeed);
        spaceScrolling.transform.Translate(spaceSrollSpd);
        spaceScrolling1.transform.Translate(spaceSrollSpd);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "space")
        {
            collision.gameObject.transform.position = new Vector3(0, 20, 1);
        }
        if(collision.gameObject.tag == "planet")
        {
            Destroy(collision.gameObject, 10f);
        }
    }
}
