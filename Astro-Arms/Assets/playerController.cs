using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour 
{
    public KeyCode up, down, left, right, attack, grab;
    public Vector2 vert, horz, thrown;
    public GameObject player;
   public GameObject item;
    public int grabbing;
    public int powerID;
    public GameObject red;
    public GameObject green;
    public GameObject blue;

	// Use this for initialization
	void Start () 
    {
        vert = new Vector2(0, .15f); // up and down speed
        horz = new Vector2(.15f, 0);// left and right speed
        thrown = new Vector2(0, .5f);// this speed of 
        grabbing = 0;
        powerID = 0;
        player.GetComponent<SpriteRenderer>().color = Color.white;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKey(up))
        {
            player.transform.Translate(vert); // moving up
        }
        if (Input.GetKey(down))
        {
            player.transform.Translate(-vert); // moving down
        }
        if (Input.GetKey(left))
        {
            player.transform.Translate(-horz); // moving left
        }
        if (Input.GetKey(right))
        {
            player.transform.Translate(horz); // moving right
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
            if (powerID == 1)
            {
                Instantiate(red, gameObject.transform.position, Quaternion.identity);
                grabbing = 0;
            }
            if (powerID == 2)
            {
                Instantiate(blue, gameObject.transform.position, Quaternion.identity);
                grabbing = 0;
            }
            if (powerID == 3)
            {
                Instantiate(green, gameObject.transform.position, Quaternion.identity);
                grabbing = 0;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "red" && grabbing == 0)
        {
            powerID = 1;
        }
        else if (other.gameObject.tag == "blue" && grabbing == 0)
        {
          powerID = 2;
        }
        else if (other.gameObject.tag == "green" && grabbing == 0)
        {
            powerID = 3;
        }

        //The collider is bigger than the actual player so that when the player gets close enough to a certain powerup, 
        //it recognizes which powerup is close by
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "red" || other.gameObject.tag == "green" || other.gameObject.tag == "blue" && grabbing == 0)
        {
            powerID = 0;
        }
    }
}
