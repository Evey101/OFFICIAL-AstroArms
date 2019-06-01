using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiral_dude_behavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public float timer, dtime;
    public float movetime;
    public float shoot_timer;
    public float interval;
    public int direction;
    public Vector2 move;
    public List<GameObject> bullets;
    public GameObject bullet;
    public int hp;
    public int let_go_counter;
    public int free;
    public Vector3 grabberpos;
    public bool thown;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("spiral_dude_shoot");
        move = new Vector2(0, -2);
        direction = 1;
        interval = .1f;
        free = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(thown == true)
        {
            transform.Translate(new Vector2(0, 16 * Time.deltaTime));
        }
        grabberpos = GameObject.FindGameObjectWithTag("grabber").transform.position;
        if(free == 1)
        {
            shoot_timer += Time.deltaTime;
            if (shoot_timer >= interval)
            {
                Instantiate(bullet, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);            // for double spiral
                Instantiate(bullet, transform.GetChild(1).transform.position, transform.GetChild(1).transform.rotation);
                shoot_timer = 0;
            }
            gameObject.transform.Rotate(0, 0, 2f * direction);

            timer += Time.deltaTime;
            if (movetime < 1)
            {
                movetime += Time.deltaTime;
                GetComponent<Rigidbody2D>().velocity = move;
            }
            if (movetime >= 1)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }

            if (hp == 0)
            {
                dtime += Time.deltaTime;
                GetComponent<Animator>().Play("death explosion");
                GameObject.Find("enemy spawner").GetComponent<GameManagerScript>().enemyDied += 1;
                GameObject.Find("player").GetComponent<playerController>().score += 1000 * GameObject.Find("player").GetComponent<playerController>().multiplier;
                GameObject.Find("player").GetComponent<playerController>().multibar += 1;
                Destroy(gameObject);
            }
           
            if (timer > 15)
            {
                direction *= -1;
                timer = 0;
            }        }
        if(free == 2)
        {
            transform.position = grabberpos;
        }
        if(free == 3)
        {
            transform.rotation = Quaternion.identity;
            transform.Translate(new Vector2(0, 16 * Time.deltaTime));
            StopCoroutine("spiral_dude_shoot");
        }
        else
        {
            //transform.position = grabberpos;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            let_go_counter = 1;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //gameObject.tag = "thrown";
            let_go_counter = 2;
        }

    }

    public IEnumerator spiral_dude_shoot()
    {
        //for (; ; ){

        //    yield return null;
        //}
        while (true){
            yield return null;
        }

        //for (int i = 0; i < 100; i++)
        //{
        //    gameObject.transform.Rotate(0, 0, 20);
        //    bullets.Add(Instantiate(bullet, transform.position + new Vector3(.5f, 0, 0), transform.rotation));            // for double spiral
        //    bullets.Add(Instantiate(bullet, transform.position + new Vector3(-.5f, 0, 0), transform.rotation));           // for doubel spiral 
        //    bullets.Add(Instantiate(bullet, transform.position, transform.rotation));
        //    yield return new WaitForSeconds(.03f);
        //}
        //bullets.Clear();
        //yield return new WaitForSeconds(.3f);
        //for (int i = 0; i < 100; i++)
        //{
        //    gameObject.transform.Rotate(0, 0, -20);
        //    //bullets.Add(Instantiate(bullet, transform.position + new Vector3(.5f, 0, 0), transform.rotation));            // for double spiral
        //    //bullets.Add(Instantiate(bullet, transform.position + new Vector3(-.5f, 0, 0), transform.rotation));           // for doubel spiral 
        //    bullets.Add(Instantiate(bullet, transform.position, transform.rotation));
        //    yield return new WaitForSeconds(.03f);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player bullet")
        {
            hp -= 1;
        }
        if (collision.gameObject.tag == "thrown")
        {
            GameObject.Find("enemy spawner").GetComponent<GameManagerScript>().enemyDied += 1;
            Destroy(gameObject);
        }    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "grabber")
        {
            gameObject.tag = "thrown";
            Debug.Log("tag changed");

        }
    }
}
