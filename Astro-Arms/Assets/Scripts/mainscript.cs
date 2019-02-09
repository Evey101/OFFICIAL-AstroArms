using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mainscript : MonoBehaviour 
{
    public KeyCode up, down, left, right, attack, grab;
    public Vector2 vert, horz, puspawn;
    public List<Vector2> spawnlist;
    public float spawntime;
    public GameObject player;
    public GameObject cannon_enemy;
    public int mode;
    public int grabbing;
    public int powerID;
    public float timer;
    public bool following;
    public Rigidbody2D rb;
    public float HP;
    public TMP_Text health;

	// Use this for initialization
	void Start () 
    {
        spawntime = 0;
        mode = 0;
        vert = new Vector2(0, 10f); // up and down speed
        horz = new Vector2(10f, 0);// left and right speed
        grabbing = 0;
        powerID = 0;
        player.GetComponent<SpriteRenderer>().color = Color.white;
        following = false;
        HP = 100;
	}
	
	// Update is called once per frame
	void Update () 
    {
        spawntime += Time.deltaTime;
        health.text = "HP: " + HP.ToString();

        timer += Time.deltaTime;
        //if (timer > 5)
        //{
            
        //}
        if (Input.GetKey(up))
        {
            rb.velocity = vert; // moving up
        }
        if(Input.GetKeyUp(up))
        {
            rb.velocity = Vector2.zero;
        }
        if (Input.GetKey(down))
        {
            rb.velocity = -vert; // moving down
        }
        if (Input.GetKeyUp(down))
        {
            rb.velocity = Vector2.zero;
        }
        if (Input.GetKey(left))
        {
            rb.velocity = -horz; // moving left
        }
        if (Input.GetKeyUp(left))
        {
            rb.velocity = Vector2.zero;
        }
        if (Input.GetKey(right))
        {
            rb.velocity = horz; // moving right
        }
        if (Input.GetKeyUp(right))
        {
            rb.velocity = Vector2.zero;
        }
        if (Input.GetKeyDown(grab))
        {
            grabbing += 1; 
        }
       
        if (grabbing == 0)
        {
            player.GetComponent<SpriteRenderer>().color = Color.white; //the color white is its standard state
        }

        if (grabbing == 1) // this means that the key was pressed once, meaning it was used
            //right now, its just showing through the color change.
        {
            if (powerID == 1)
            {
                player.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (powerID == 2)
            {
                player.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            if (powerID == 3)
            {
                player.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
        if (grabbing == 2) // this means that the key was pressed a second time, throwing the powerup and setting the player back to 
            //to its standard state
        {
            grabbing = 0;
        }
        if(timer >= 2)
        {
            Instantiate(cannon_enemy, new Vector3(0, 5, 0), Quaternion.identity);
            timer = 0;
        }

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "red" && grabbing == 0)
        {
            powerID = 1; 
        }
        if (other.gameObject.tag == "blue" && grabbing == 0)
        {
            powerID = 2;
        }
        if (other.gameObject.tag == "green" && grabbing == 0)
        {
            powerID = 3;
        }

        //The collider is bigger than the actual player so that when the player gets close enough to a certain powerup, 
        //it recognizes which powerup is close by
    }
}
