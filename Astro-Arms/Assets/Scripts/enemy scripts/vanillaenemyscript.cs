using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vanillaenemyscript : MonoBehaviour 
{
    public Vector2 speed;
    public bool free, die;
    public GameObject grabber, Player;
    public Vector3 grabberpos;
    public grabbing grabbing_script;
    public int let_go_counter;
    public float dtime;


	// Use this for initialization
	void Start () 
	{
        GameObject.Find("player");
        speed = new Vector2(0,-16);
        free = true;
        grabbing_script = FindObjectOfType<grabbing>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (GameObject.Find("player").GetComponent<playerController>().pause == false)
        {
            grabberpos = GameObject.FindGameObjectWithTag("grabber").transform.position;
            if (free == true)
            {
                GetComponent<Rigidbody2D>().velocity = speed;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                transform.position = grabberpos;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                let_go_counter = 1;

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                let_go_counter = 2;
                // gameObject.tag = "thrown";
            }
        }

	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "player bullet")
        {
                GetComponent<Animator>().Play("death explosion");
                GameObject.Find("enemy spawner").GetComponent<GameManagerScript>().enemyDied += 1;
                GameObject.Find("player").GetComponent<playerController>().score += 1000 * GameObject.Find("player").GetComponent<playerController>().multiplier;
                GameObject.Find("player").GetComponent<playerController>().multibar += 1;
                Destroy(gameObject);
        }
        if(collision.gameObject.tag == "thrown")
        {
            GameObject.Find("enemy spawner").GetComponent<GameManagerScript>().enemyDied += 1;
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "grabber")
        {
            gameObject.tag = "thrown";
            Debug.Log("tag changed");

        }    
    }
}
