using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene1 : MonoBehaviour
{
    public Vector2 scrollSPD;
    public float movementAmount, timeTester;
    public float donMove;
    public GameObject Player, BG, BG2;
    public bool getit;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && transform.position.x >= -104)
        {
            transform.position = new Vector3(-150, 0, 0);
        }
        timeTester += Time.deltaTime;
        if (transform.position.x <= -95)
        {
            Player.SetActive(true);
        }
        else
        {
            Player.SetActive(false);
        }
        if (transform.position.x <= -170)
        {
            BG.SetActive(false);
            BG2.SetActive(true);
        }
        else
        {
            BG.SetActive(true);
            BG2.SetActive(false);
            getit = true;
        }
        donMove -= Time.deltaTime;
        if (donMove <= 0)
        {
            transform.Translate(scrollSPD);
            movementAmount += .1f;
        }
        /*if(movementAmount >= 19)
        {
            donMove = 5;
            movementAmount = 0;
        }*/
    }
}

