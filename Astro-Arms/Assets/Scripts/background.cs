using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour 
{
    public GameObject  spaceScrolling,spaceScrolling1;
    public Vector2 spaceSrollSpd;
	// Use this for initialization
	void Start () 
    {
        spaceSrollSpd = new Vector2(0, -40 * Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () 
    {
        spaceScrolling.transform.Translate(spaceSrollSpd);
        spaceScrolling1.transform.Translate(spaceSrollSpd);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "space")
        {
            collision.gameObject.transform.position = new Vector3(0, 15, 0);
        }
 
    }
}