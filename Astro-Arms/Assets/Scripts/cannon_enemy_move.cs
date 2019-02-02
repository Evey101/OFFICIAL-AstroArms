using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_enemy_move : MonoBehaviour 
{
    public Rigidbody2D rb;
<<<<<<< HEAD
    public bool isleft;
<<<<<<< HEAD
    public Vector3 rotation;
=======
    public GameObject point;
    public GameObject bomb;
    public bool start_shooting;
    public float timer;
>>>>>>> master
=======
>>>>>>> parent of 46557aa... test

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
<<<<<<< HEAD
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
=======
        //if (gameObject.transform.position.x > 0)
        //{
        //    isleft = false;
        //}
        //else
        //{
        //    isleft = true;
        //}

        for (int i = 0; i < 50; i++)
        {
            rb.AddForce(new Vector2(1 + i, -1 + i), ForceMode2D.Force);
        }

>>>>>>> parent of 46557aa... test
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
