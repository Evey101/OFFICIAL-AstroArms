using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_enemy_move : MonoBehaviour 
{
    public Rigidbody2D rb;
    public bool isleft;
    public Vector3 rotation;
    public GameObject point;
    public GameObject bomb;
    public bool start_shooting;
    public float timer;
    public int hp;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (hp == 0)
        {
            Destroy(gameObject);
        }
        rotation = transform.eulerAngles;
        Vector3 dir = Quaternion.AngleAxis(rotation.z, Vector3.forward) * Vector3.forward;
        transform.Rotate(dir);
        transform.RotateAround(point.transform.position, Vector3.forward, 40 * Time.deltaTime);

        if(start_shooting == true)
        {
            timer += Time.deltaTime;
        }
        if(timer >= .8f)
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            timer = 0;
            Debug.Log("spwned bomb");
        }


	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bomb trigger")
        {
            start_shooting = true;
        }
        if (collision.gameObject.tag == "bomb enemy killer")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "player bullet")
        {
            hp -= 1;
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
