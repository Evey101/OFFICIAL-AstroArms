﻿using System.Collections;
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
    public GameObject cannon_enemy;
    public Vector3 urpos;
    public Rigidbody2D rb;
    public int HP;
    public GameObject[] current_HP;
    public TMP_Text health;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        vert = new Vector2(0, 15f); // up and down speed
        horz = new Vector2(15f, 0); // left and right speed
        thrown = new Vector2(0, .5f); // this speed of 
        grabbing = 0;
        powerID = 0;
        player.GetComponent<SpriteRenderer>().color = Color.white;
        HP = 4;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        health.text = "HP";
        Move();


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
        if (other.gameObject.tag == "bomb explosion" || other.gameObject.tag == "rightbul" || other.gameObject.tag == "downbul"
            || other.gameObject.tag == "leftbul" || other.gameObject.tag == "vanilla enemy" || other.gameObject.tag == "spiral bullet")
        {
            Destroy(current_HP[HP]);
            HP -= 1;
            Debug.Log(HP);
        }
            
           

    }
    private void OnTriggerExit2D(Collider2D other)
    {

    }
}
