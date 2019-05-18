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
    public float timer, cooldown, gametime;
    public Vector3 urpos;
    public Rigidbody2D rb;
    public int HP;
    public GameObject[] current_HP;
    public TMP_Text health;
    public Animator anim;
    public GameObject bullet;
    public grabbing grabber;
    public vanillaenemyscript vanilla_enemy_script;
    public shipscript boss_script;
    public GameObject boss;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vert = new Vector2(0, 15f); // up and down speed
        horz = new Vector2(15f, 0); // left and right speed
        thrown = new Vector2(0, .5f); // this speed of 
        HP = 4;
        cooldown = 0;
        anim = GetComponent<Animator>();
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        health.text = "HP";
        Move();
        gametime += Time.deltaTime;

        //if(gametime >= 120)
        //{
        //    boss_script.phase = 0;
        //    GetComponent<AudioSource>().Pause();
        //    //boss.GetComponent<AudioSource>().Play();
        //}
        if(Input.GetKey(KeyCode.Space))
        {
            anim.Play("holding final anim");
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            anim.Play("thowing animation");    
        }
        if (Input.GetKey(attack))
        {
            cooldown += Time.deltaTime;
            if (cooldown >= .1f)
            {
                Instantiate(bullet, gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
                cooldown = 0;
            }
        }

    }
    public static bool IsInBorder(Vector2 pos)
    {
        return ((float)pos.x >= -8.5 && (float)pos.x <= 8.5 && (float)pos.y >= -8.4f && (float)pos.y <= 8.4);
    }
    private void Move()
    {
        if (Input.GetKey(up))
        {
            rb.velocity = new Vector2(rb.velocity.x, vert.y); // moving up
        }
        if (Input.GetKeyUp(up))
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

        if (HP <= -1)
        {
            SceneManager.LoadScene(2);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
 
        if(other.gameObject.tag == "bomb explosion" || other.gameObject.tag == "rightbul" || other.gameObject.tag == "down bul" 
           || other.gameObject.tag == "left bul" || other.gameObject.tag == "spiral bullet" || other.gameObject.tag == "enemy bullet" ||
          other.gameObject.tag == "enemy")
        {
            Destroy(current_HP[HP]);
            HP -= 1;
            Debug.Log(HP);
        }
        if (other.gameObject.tag == "thrown")
        {
            Destroy(gameObject);
        }
    }
}
