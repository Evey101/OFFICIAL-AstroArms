using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour 
{
    public KeyCode up, down, left, right, attack, grab;
    public Vector2 vert, horz, thrown, spawn;
    public List<Vector2> spawnlist;
    public GameObject player;
    public GameObject item;
    public int grabbing;
    public int powerID;
    public List<GameObject> powerups;
    public GameObject red;
    public GameObject green;
    public GameObject blue;
    public GameObject powerup;
    public float timer;
    public float spawntime;
    public GameObject cannon_enemy;
    public Vector3 urpos;
    public Rigidbody2D rb;
    public int HP;
    public GameObject[] current_HP;
    public TMP_Text health;
    public GameObject spiral_enemy;




    // Use this for initialization
    void Start () 
    {
        rb = player.GetComponent<Rigidbody2D>();
        vert = new Vector2(0, 15f); // up and down speed
        horz = new Vector2(15f, 0); // left and right speed
        thrown = new Vector2(0, .5f); // this speed of 
        grabbing = 0;
        powerID = 0;
        GetComponent<SpriteRenderer>().color = Color.white;
        HP = 4;
	}
	
	// Update is called once per frame
	void Update () 
    {
        spawntime += Time.deltaTime;
        timer += Time.deltaTime;
        health.text = "HP";
        Move();

        if (spawntime > 10)
        {
            powerup = powerups[Random.Range(0, 2)];
            spawn = spawnlist[Random.Range(0, 2)];
            Instantiate(powerup, spawn, Quaternion.identity);
            spawntime = 0;
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
        if (timer >= 5)
        {
            Instantiate(cannon_enemy, new Vector3(0, 20, 0), Quaternion.identity);
            timer = 0;
        }
        if (timer >= 5)
        {
            Instantiate(spiral_enemy, new Vector3(0, 20, 0), Quaternion.identity);
            timer = 0;
        }

    }
    private void Move()
    {

        if (Input.GetKey(up))
        {
            rb.velocity = new Vector2(rb.velocity.x, vert.y); // moving up
        }
        if(Input.GetKeyUp(up))
        {
            rb.velocity = Vector3.zero;
        }
        if (Input.GetKey(down))
        {
            rb.velocity = new Vector2(rb.velocity.x, -vert.y); // moving down
        }
        if (Input.GetKeyUp(down))
        {
            rb.velocity = Vector3.zero;
        }
        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-horz.x, rb.velocity.y); // moving left
        }
        if (Input.GetKeyUp(left))
        {
            rb.velocity = Vector3.zero;
        }
        if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(horz.x, rb.velocity.y); // moving right
        }
        if (Input.GetKeyUp(right))
        {
            rb.velocity = Vector3.zero;
        }
        if(HP <= -1)
        {
            SceneManager.LoadScene(2);
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
        if(other.gameObject.tag == "bomb explosion" || other.gameObject.tag == "rightbul" || other.gameObject.tag == "downbul" 
           || other.gameObject.tag == "leftbul")
        {
            Destroy(current_HP[HP]);
            HP -= 1;
        }
        if (other.gameObject.tag == "bullet")
        {
            Destroy(current_HP[HP]);
            HP -= 1;
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
