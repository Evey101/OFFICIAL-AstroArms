using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour 
{
    public List<Vector2> dirlist;
    public Vector2 dir;
    public Vector2 speed;
    public float missilespeed;
    public float m2speed;
    public float followtime;
    public float timer;
    public Vector2 target;
    public Vector2 position;
    public shipscript ship;
    public shieldscript shield;
    public int mode;
    //public GameObject player;
    public Vector2 playerpos;
	// Use this for initialization
	void Start () 
    {
        speed = new Vector2(0, 10);
        ship = GameObject.Find("SHIPS").GetComponent<shipscript>();
        missilespeed = 5;
        m2speed = 2;
        position = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        //target = player.gameObject.transform.position;
        if (gameObject.tag == "player bullets")
        {
            GetComponent<Rigidbody2D>().velocity = speed;
        }
        if (gameObject.tag == "enemy bullet")
        {
            GetComponent<Rigidbody2D>().velocity = -speed;
        }
        if (gameObject.tag == "missile2")
        {
            if (mode == 0)
            {
                timer += Time.deltaTime;
                GetComponent<Rigidbody2D>().AddForce (dirlist[Random.Range(0, 4)]);
                if (timer > .5f)
                {
                    mode = 1;
                }
            }
            if (mode == 1)
            {
                timer = 0;
                mode = 2;
            }
            if (mode == 2)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                timer += Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("player").transform.position, m2speed * Time.deltaTime);
                if (timer >= 2)
                {
                    mode = 3;
                }
            }
            if (mode == 3)
            {
                GetComponent<Rigidbody2D>().velocity = GameObject.Find("player").transform.position;
            }
        }
        if (gameObject.tag == "missile")
        {
            followtime += Time.deltaTime;
            if (followtime < 3)
            {
                playerpos = GameObject.Find("player").transform.position;
                float step = missilespeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, target, step);
                target = playerpos;
            }
            if (followtime >= 3)
            {
                GetComponent<Rigidbody2D>().velocity = target;
            }
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "weak points" && gameObject.tag == "player bullets")
        {
            ship.hp -= 5;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "ship" && gameObject.tag == "player bullets")
        {
            ship.hp -= 1;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "shield" && gameObject.tag == "player bullets")
        {
            ship.shieldhp -= 1;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
