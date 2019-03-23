using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyscript : MonoBehaviour 
{
    public float speed;
    public List<Vector3> sizelist;

	// Use this for initialization
	void Start () 
    {
        speed = 5;
        transform.localScale = sizelist[Random.Range(0, 3)];
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("SHIPS").transform.position, speed * Time.deltaTime);
	}
}
