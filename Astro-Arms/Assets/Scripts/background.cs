using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour 
{
    public GameObject  spaceScrolling;
    public Vector2 spaceSrollSpd;
	// Use this for initialization
	void Start () 
    {
        spaceSrollSpd = new Vector2(-20 * Time.deltaTime, 0);
	}
	
	// Update is called once per frame
	void Update () 
    {
        spaceScrolling.transform.Translate(spaceSrollSpd);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "space")
        {
            collision.gameObject.transform.position = new Vector3(0f, 5f, 0f);
        }
 
    }
}