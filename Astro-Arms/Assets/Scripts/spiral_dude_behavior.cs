using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiral_dude_behavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public float timer;
    public float movetime;
    public Vector2 move;
    public List<GameObject> bullets;
    public GameObject bullet;
    public int hp;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("spiral_dude_shoot");
        movetime = 0;
        move = new Vector2(0, -2);

    }

    // Update is called once per frame
    void Update()
    {
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
            Destroy(gameObject);
        }

        if (timer >= 15)
        {
            StartCoroutine("spiral_dude_shoot");
            timer = 0;
        }

    }

    public IEnumerator spiral_dude_shoot()
    {
        for (int i = 0; i < 100; i++)
        {
            gameObject.transform.Rotate(0, 0, 20);
            //bullets.Add(Instantiate(bullet, transform.position + new Vector3(.5f, 0, 0), transform.rotation));            // for double spiral
            //bullets.Add(Instantiate(bullet, transform.position + new Vector3(-.5f, 0, 0), transform.rotation));           // for doubel spiral 
            bullets.Add(Instantiate(bullet, transform.position, transform.rotation));
            yield return new WaitForSeconds(.03f);
        }
        bullets.Clear();
        yield return new WaitForSeconds(.3f);
        for (int i = 0; i < 100; i++)
        {
            gameObject.transform.Rotate(0, 0, -20);
            //bullets.Add(Instantiate(bullet, transform.position + new Vector3(.5f, 0, 0), transform.rotation));            // for double spiral
            //bullets.Add(Instantiate(bullet, transform.position + new Vector3(-.5f, 0, 0), transform.rotation));           // for doubel spiral 
            bullets.Add(Instantiate(bullet, transform.position, transform.rotation));
            yield return new WaitForSeconds(.03f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player bullet")
        {
            hp -= 1;
        }
    }
}
