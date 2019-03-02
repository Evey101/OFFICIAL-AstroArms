﻿using System.Collections; using System.Collections.Generic; using UnityEngine;  public class trianglescript : MonoBehaviour {     public Vector2 vert, horz, stop, go;      public float timer;     public float hurttime;     public float gotimer;     public float oldz;     public float turn;      public bool right;     public bool canMove;     public bool canShoot;     public bool canRotate;      public int mode;     public int state;     public int hp;      public GameObject rightbul, leftbul, downbul;    //s public GameObject blaster;      // Use this for initialization     void Start()     {         state = 0; //state refers to what action the ship is taking         // 0 is moving         //1 is shooting, which immediatly swicthes to 2 to instantiate the bullets only once         //2 is just staying still         //3 is for rotation         //4 reverts it back to 0         mode = 0; // mode refers to which way the ship is turning and when         vert = new Vector2(0, -3f);         horz = new Vector2(5f, 0);         stop = new Vector2(0, 0);         turn = 1.468999f; // rotation speed;     }      // Update is called once per frame     void Update()     {         timer += Time.deltaTime;         gotimer += Time.deltaTime;          if (hp == 0)         {             Destroy(gameObject);         }         if (gotimer > 1)         {             state += 1;             gotimer = 0;             // every second, the state will increas by 1         }         if (canMove == true)         {             GetComponent<Rigidbody2D>().velocity = go; // when they move         }         else if (canMove == false)         {             GetComponent<Rigidbody2D>().velocity = stop; // when it stops         }         if (state == 0)         {             canMove = true;         }         //else if (state != 0)         //{         //    canMove = false;         //}         // moves every other second         if (state == 1 && mode < 7)         {             mode += 1;             GameObject bullet=Instantiate(rightbul, transform.position, Quaternion.identity);             bullet.GetComponent<trianglebulletscript>().script = this;             bullet = Instantiate(leftbul, transform.position, Quaternion.identity); // all three are the different bullets             bullet.GetComponent<trianglebulletscript>().script = this;             bullet = Instantiate(downbul, transform.position, Quaternion.identity);             bullet.GetComponent<trianglebulletscript>().script = this;             // mode dictates the direction             state = 2;         }         if  (state == 2)         {             if (mode == 1|| mode == 4 || mode == 5)             {                 transform.Rotate(0, 0, turn);             }             if (mode == 2|| mode == 3 || mode == 6)             {                 transform.Rotate(0, 0, -turn);             }         }         if (state == 3)         {             state = 0;         }          if (mode == 0 || mode == 2 || mode == 4 || mode == 6)         {             go = vert;         }         else if (mode == 1 || mode == 5)         {             go = horz;         }         else if (mode == 3)         {             go = -horz;         }     }     private void OnTriggerEnter2D(Collider2D other)     {         if (other.gameObject.tag == "Finish")         {             Destroy(gameObject); // ship destroys itself if they travel far enough         }         if (other.gameObject.tag == "player bullet")         {             hp -= 1;         }     } } 