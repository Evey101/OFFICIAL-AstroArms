using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class shipscript : MonoBehaviour
{
    public int shieldhp, tries, phase;
    public Vector2 speed, down;
    public Color transp;
    public float hp, timer, shottime, bulletime, starttime, deadtime;
    public GameObject bullet, mtype1, mtype2, shield, explosion,
    b1, b2, b3, b4, b5, b6, b7, excircle;
    public List<Sprite> shipsprites;
    public SpriteRenderer sr;
    public int mode;
    public int shots;
    public bool explode;
    public List<Vector2> spawns;
    public GameObject energy;
    public GameObject laser;
    public int start;
    public Image hpbar;
    public Image hpbar2;
    public enum Status
    {
        phase0,
        phase1,
        phase2,
        dead
    }

    public Status myStatus;

    // Use this for initialization
    void Start()
    {
        phase = 0;
        hp = 600;
        shieldhp = 100;
        mode = 0;
        timer = 0;
        speed = new Vector2(2, 0);
        shots = 9;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = shipsprites[0];
        starttime = 0;
        down = new Vector2(0, -.2f);
        start = 5;
        myStatus = Status.phase0;
        explosion.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            myStatus = Status.dead;
        }
        hpbar.GetComponent<Image>().fillAmount = hp / 600;
        hpbar2.GetComponent<Image>().fillAmount = hp / 600;
        Debug.Log("hp normalized is: " + hp / 600);
        //Debug.Log("Current Status: " + myStatus); 
        switch(myStatus)
        {
            case Status.phase0:
                PhaseZeroFunction();
                //hpbar.gameObject.SetActive(true);
                break;
            case Status.phase1:
                PhaseOneFunction();
                break;
            case Status.phase2:
                PhaseTwoFunction();
                break;
            case Status.dead:
                DeadBoss();
                break;
        }

        if (myStatus == Status.phase1 || myStatus == Status.phase2)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                GetComponent<Rigidbody2D>().velocity = speed;
                //Debug.Log("going right");
            }
            if (timer < 1)
            {
                GetComponent<Rigidbody2D>().velocity = -speed;
                //Debug.Log("going left");
            }
            if (timer >= 2)
            {
                timer = 0;
            }
        }
       
        if (Input.GetKeyDown(KeyCode.G) && myStatus == Status.phase1)
        {
            shieldhp = -1;
            hp = -1;
        }

    }

    void PhaseZeroFunction()
    {
        if (GameObject.Find("player").GetComponent<playerController>().gametime >= 133)
        {
            starttime += Time.deltaTime;
            start = 0;
            hpbar.gameObject.SetActive(true);
            hpbar2.gameObject.SetActive(true);
        }

        if (start == 0 && starttime < 5)
        {
            phase = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3);
           // Debug.Log("moving down");
        }
        if (start == 0 && starttime >= 5)
        {
            start = 1;
        }
        if (start == 1)
        {
            phase = 1;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            myStatus = Status.phase1;
        }
    }

    void PhaseOneFunction()
    {
        //Debug.Log("Phase 1 in action");

        if (hp < 500)
        {
            Destroy(shield);
            sr.sprite = shipsprites[1];
            hpbar.GetComponent<Image>().color = Color.yellow;
            hpbar2.GetComponent<Image>().color = Color.yellow;
        }
        if (hp < 300)
        {
            tries = 0;
            shottime = 0;
            shots = 0;
            bulletime = 0;
           
            mode = 0;
            myStatus = Status.phase2;
        }

        if (mode == 0)
        {
            //timer += Time.deltaTime;
            if (shottime < 3)
            {
                shottime += Time.deltaTime;
                shots = 8;
            }
            if (shottime > 3)
            {
                bulletime += Time.deltaTime;
                if (bulletime > .3f && shots > 0)
                {
                    Instantiate(bullet, b1.transform.position, Quaternion.identity);
                    Instantiate(bullet, b2.transform.position, Quaternion.identity);
                    Instantiate(bullet, b3.transform.position, Quaternion.identity);
                    Instantiate(bullet, b4.transform.position, Quaternion.identity);
                    Instantiate(bullet, b5.transform.position, Quaternion.identity);
                    Instantiate(bullet, b6.transform.position, Quaternion.identity);
                    shots -= 1;
                    bulletime = 0;
                }
                if (shots == 0)
                {
                    shottime = 0;
                    mode = 1;
                }
            }
        }
        if (mode == 1)
        {
            if (shottime > 3)
            {
                shottime += Time.deltaTime;
            }
            if (shottime < 3)
            {
                bulletime += Time.deltaTime;
                if (bulletime >= 1f)
                {
                    shots += 1;
                    bulletime = 0;
                }
                if (shots == 1)
                {
                    Instantiate(mtype1, b1.transform.position, Quaternion.identity);
                    shots = 2;
                }
                if (shots == 3)
                {
                    Instantiate(mtype1, b2.transform.position, Quaternion.identity);
                    shots = 4;
                }
                if (shots == 5)
                {
                    Instantiate(mtype1, b3.transform.position, Quaternion.identity);
                    shots = 6;
                }
                if (shots == 7)
                {
                    Instantiate(mtype1, b4.transform.position, Quaternion.identity);
                    shots = 8;
                }
                if (shots == 9)
                {
                    Instantiate(mtype1, b5.transform.position, Quaternion.identity);
                    shots = 10;
                }
                if (shots == 11)
                {
                    Instantiate(mtype1, b6.transform.position, Quaternion.identity);
                    shots = 12;
                }
                if (shots == 12)
                {
                    mode = 0;
                }
            }
        }
    }
    void PhaseTwoFunction()
    {
        //Debug.Log("Phase 2 in action");
        sr.sprite = shipsprites[2];
        hpbar.GetComponent<Image>().color = Color.red;
        hpbar2.GetComponent<Image>().color = Color.red;
        if (mode == 0)
        {
            Debug.Log("for the love of god please help me");
            if (shottime < 3)
            {
                shottime += Time.deltaTime;
                shots = 5;
            }
            if (shottime >= 3)
            {
                bulletime += Time.deltaTime;
                if (bulletime > 1 && shots != 0)
                {
                    Instantiate(mtype2, b7.transform.position, Quaternion.identity);
                    shots -= 1;
                    bulletime = 0;
                    if (shots == 0)
                    {
                        bulletime = 0;
                        shottime = 0;
                        mode = 1;
                    }
                }
            }

        }
        if (mode == 1)
        {
            if (shottime < 3)
            {
                shottime += Time.deltaTime;
                shots = 15;
            }
            if (shottime >= 3)
            {
                bulletime += Time.deltaTime;
                if (bulletime >= .2f && shots != 0)
                {
                    Instantiate(energy, spawns[Random.Range(0, 9)], Quaternion.identity);
                    bulletime = 0;
                    shots -= 1;
                }
                if (shots == 0)
                {
                    Destroy(GameObject.FindGameObjectWithTag("energy"));
                    if (bulletime < 3)
                    {
                        bulletime += Time.deltaTime;
                        laser.transform.position = b7.transform.position;
                        explode = true;
                    }
                    if (bulletime >= 3)
                    {
                        laser.transform.position = new Vector2(30, 0);
                        explode = false;
                        shottime = 0;
                        mode = 0;
                    }

                }
            }
            if (hp < 0)
            {
                Debug.Log("no hp should be dead");
                myStatus = Status.dead;
            }
        }

    }

    void DeadBoss ()
    {
        deadtime += Time.deltaTime;
        if (deadtime < 3)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
            transform.Rotate(0, 0, .5f);
        }
        if (deadtime > 3 && deadtime < 5)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.position = new Vector3(0, 100, 0);
            transform.Rotate(0, 0, 0);
            explosion.gameObject.SetActive(true);
            explosion.transform.localScale += new Vector3(2, 2, 1);
        }
        if (deadtime > 5)
        {
            explosion.gameObject.SetActive(false);
        }
    }
}
