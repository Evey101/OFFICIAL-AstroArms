using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour 
{
    public GameObject  spaceScrolling;
    public GameObject spaceScrolling1;
    public Vector2 spaceSrollSpd;
	// Use this for initialization
	void Start () 
    {
        spaceSrollSpd = new Vector2(-0.5f, 0);
	}
	
	// Update is called once per frame
	void Update () 
    {
        spaceScrolling.transform.Translate(spaceSrollSpd);
        spaceScrolling1.transform.Translate(spaceSrollSpd);

        if (spaceScrolling.transform.position.y <= -26)
        {
            spaceScrolling.transform.position = new Vector3(0, 37.7f, 0);
            Debug.Log("goin up");
        }
        if (spaceScrolling1.transform.position.y <= -26)
        {
            spaceScrolling1.transform.position = new Vector3(0, 37.7f, 0);
            Debug.Log("goin up again");
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "space")
        //{
        //    collision.gameObject.transform.position = new Vector3(0f, 6.4f, 0f);
        //}
 
    }
}
