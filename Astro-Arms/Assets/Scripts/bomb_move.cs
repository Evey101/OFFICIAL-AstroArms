using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_move : MonoBehaviour
{
    public Rigidbody2D rb;
    public float timer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("player").GetComponent<playerController>().pause == false)
        {

            timer += Time.deltaTime;

            rb.velocity = new Vector2(0, -10);
            if (timer < 1)
            {
                GetComponent<Animator>().Play("bomb blinking");
            }

            if (timer >= 1)
            {
                //GetComponent<SpriteRenderer>().color = new Vector4(255, 0, 0, 255);
                //transform.localScale = new Vector3(6, 6, 6);
                rb.velocity = new Vector2(0, -1);
                //gameObject.tag = "bomb explosion";
                GetComponent<Animator>().Play("bomb explosion");
            }
            Destroy(gameObject, 4f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
