using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_enemy_move : MonoBehaviour 
{
    public Rigidbody2D rb;
<<<<<<< HEAD
    public bool isleft;
    public Vector3 rotation;
=======
    public GameObject point;
    public GameObject bomb;
    public bool start_shooting;
    public float timer;
>>>>>>> master

	// Use this for initialization
	void Start () 
    {
        rb.AddForce((Vector3.up), ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () 
    {
<<<<<<< HEAD
        rotation = transform.eulerAngles;
        Vector3 dir = Quaternion.AngleAxis(rotation.z, Vector3.forward) * Vector3.forward;
        transform.Rotate(dir);
=======
        transform.RotateAround(point.transform.position, Vector3.forward, 40 * Time.deltaTime);

        if(start_shooting == true)
        {
            timer += Time.deltaTime;
        }
        if(timer >= .8f)
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            timer = 0;
        }
>>>>>>> master
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bomb trigger")
        {
            start_shooting = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bomb trigger")
        {
            start_shooting = false;
        }
    }
}
