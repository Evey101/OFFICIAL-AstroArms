using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_enemy_move : MonoBehaviour 
{
    public Rigidbody2D rb;
    public bool isleft;
    public Vector3 rotation;
    public GameObject point;
    public GameObject bomb, Player;
    public bool start_shooting;
    public float timer, dtime;
    public int hp;
    public bool free;

	// Use this for initialization
	void Start () 
    {
        free = true;
        hp = 2;
        Player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Player.GetComponent<playerController>().pause == false)
        {
            if (hp == 0)
            {
                dtime += Time.deltaTime;
                GetComponent<Animator>().Play("death explosion");
                GameObject.Find("enemy spawner").GetComponent<GameManagerScript>().enemyDied += 1;
                GameObject.Find("player").GetComponent<playerController>().score += 1000 * GameObject.Find("player").GetComponent<playerController>().multiplier;
                GameObject.Find("player").GetComponent<playerController>().multibar += 1;
                Destroy(gameObject);
            }

            if (free == true)
            {
                rotation = transform.eulerAngles;
                Vector3 dir = Quaternion.AngleAxis(rotation.z, Vector3.forward) * Vector3.forward;
                transform.Rotate(dir);
                transform.RotateAround(point.transform.position, Vector3.forward, 40 * Time.deltaTime);

                if (start_shooting == true)
                {
                    timer += Time.deltaTime;
                }
                if (timer >= .8f)
                {
                    Instantiate(bomb, transform.position, Quaternion.identity);
                    timer = 0;
                    // Debug.Log("spwned bomb");
                }
            }

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
            GameObject.Find("enemy spawner").GetComponent<GameManagerScript>().enemyDied += 1;
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
