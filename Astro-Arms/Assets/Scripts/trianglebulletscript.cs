﻿using System.Collections; using System.Collections.Generic; using UnityEngine;  public class trianglebulletscript : MonoBehaviour  {     public Vector2 right, down, left;     ///public GameObject storage;     public trianglescript script;     public int mode;     public float timer;   // Use this for initialization  void Start ()       {         timer = 0;         //mode = 1;         right = new Vector2(3,-10);         down = new Vector2(0, -10);         left = new Vector2(-3,-10);         //storage = GameObject.Find("triangle_enemy");          mode = script.mode; // comment out for version control  }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.tag == "rightbul") // bullets are tagged appropriately so they each do their own action
        {             GetComponent<Rigidbody2D>().velocity = new Vector3(3, -10);         }         else if (gameObject.tag == "down bul")         {             GetComponent<Rigidbody2D>().velocity = new Vector3(0, -10);         }         else if (gameObject.tag == "left bul")         {             GetComponent<Rigidbody2D>().velocity = new Vector3(-3, -10);         }
        //if (mode == 0 || mode == 2 || mode == 4) // when the ship is facing downwards
        //{

        //}
        //else if (mode == 1 || mode == 5)// when the ship is facing the right side
        //{
        //    if (gameObject.tag == "rightbul") 
        //    {
        //        GetComponent<Rigidbody2D>().velocity = new Vector2 (10, 3);
        //    }
        //    else if (gameObject.tag == "downbul")
        //    {
        //        GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        //    }
        //    else if (gameObject.tag == "leftbul")
        //    {
        //        GetComponent<Rigidbody2D>().velocity = new Vector2(10, -3);
        //    }
        //}
        //else if (mode == 3) // when the ship is facing the left side

        //    if (gameObject.tag == "rightbul") 
        //    {
        //        GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 3);
        //    }
        //    else if (gameObject.tag == "downbul")
        //    {
        //        GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        //    }
        //    else if (gameObject.tag == "leftbul")
        //    {
        //        GetComponent<Rigidbody2D>().velocity = new Vector2(-10, -3);
        //    }
        //}
    }     private void OnTriggerEnter2D(Collider2D other)     {         if (other.gameObject.tag =="Finish")         {             Destroy(gameObject); // bullets destory themselves if they travel far enough         }     } }   
