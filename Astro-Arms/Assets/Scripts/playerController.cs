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
    public float timer, cooldown, gametime, multibar;
    public Vector3 urpos;
    public Rigidbody2D rb;
    public int HP, score, multiplier;
    public GameObject[] current_HP;
    public TMP_Text health;
    public Text multi, sc;
    public Image progressbar;
    public Animator anim;
    public GameObject bullet, playershield, smoke;
    public grabbing grabber;
    public vanillaenemyscript vanilla_enemy_script;
    public shipscript boss_script;
    public GameObject boss;
    public bool canHit;
    public float hittime;
    public bool changedrag, pause;
    public GameObject pauseScrn;
    public GameObject nuetral;
    public GameObject sad;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vert = new Vector2(0, 50f); // up and down speed
        horz = new Vector2(50f, 0); // left and right speed
        thrown = new Vector2(0, .5f); // this speed of 
        HP = 4;
        cooldown = 0;
        anim = GetComponent<Animator>();
        GetComponent<AudioSource>().Play();
        canHit = true;
        multiplier = 1;
        pauseScrn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("progress bar: " + progressbar.fillAmount);
        Debug.Log("multbar: " + multibar);

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pause == false)
            {
                pause = true;
                pauseScrn.SetActive(true);
            }
            else if (pause == true)
            {
                pause = false;
                pauseScrn.SetActive(false);
            }
        }
        if (pause)
        {
            pauseScrn.SetActive(true);
        }
        if (!pause)
        {
            pauseScrn.SetActive(false);
        }

        if (pause == false)
        {
            progressbar.fillAmount = multibar / 10;

            if (progressbar.fillAmount == 1)
            {
                multiplier += 1;
                multibar = 0;
                progressbar.fillAmount = 0;
            }

            multi.text = "" + multiplier + "x";
            sc.text = "" + score;

            timer += Time.deltaTime;
            //health.text = "HP";
            Move();
            gametime += Time.deltaTime;

            if (canHit == true)
            {
                hittime = 0;
                playershield.SetActive(false);
                nuetral.SetActive(true);
                sad.SetActive(false);

            }
            else
            {
                playershield.SetActive(true);
                nuetral.SetActive(false);
                sad.SetActive(true);
                hittime += Time.deltaTime;
                if (hittime >= .75f)
                {
                    canHit = true;
                }
            }

            if (HP < 2)
            {
                smoke.SetActive(true);
            }
            else
            {
                smoke.SetActive(false);
            }


            //if(gametime >= 120)
            //{
            //    boss_script.phase = 0;
            //    GetComponent<AudioSource>().Pause();
            //    //boss.GetComponent<AudioSource>().Play();
            //}
            if (Input.GetKey(KeyCode.Space))
            {
                anim.Play("holding final anim");
            }
            if (Input.GetKeyUp(KeyCode.Space))
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
        }
        public static bool IsInBorder(Vector2 pos)
        {
            return ((float)pos.x >= -8.5 && (float)pos.x <= 8.5 && (float)pos.y >= -8.4f && (float)pos.y <= 8.4);
        }
        private void Move()
        {
            if (Input.GetKey(up) && GetComponent<Rigidbody2D>().velocity.y < 50)
            {
                GetComponent<Rigidbody2D>().AddForce(vert);
                GetComponent<Rigidbody2D>().drag = 0;
            }
            if (Input.GetKey(down) && GetComponent<Rigidbody2D>().velocity.y > -50)
            {
                GetComponent<Rigidbody2D>().AddForce(-vert); // moving down
                GetComponent<Rigidbody2D>().drag = 0;
            }
            if (Input.GetKey(left) && GetComponent<Rigidbody2D>().velocity.x > -50)
            {
                GetComponent<Rigidbody2D>().AddForce(-horz); // moving left
                GetComponent<Rigidbody2D>().drag = 0;
            }
            if (Input.GetKey(right) && GetComponent<Rigidbody2D>().velocity.x < 50)
            {
                GetComponent<Rigidbody2D>().AddForce(horz); // moving right
                GetComponent<Rigidbody2D>().drag = 0;
            }
            if (Input.GetKeyUp(up) || Input.GetKeyUp(down) || Input.GetKeyUp(right) || Input.GetKeyUp(left))
            {
                GetComponent<Rigidbody2D>().drag = 50;
            }

            if (HP <= -1)
            {
                SceneManager.LoadScene(2);
            }
        }
        

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canHit == true)
        {  
            if (other.gameObject.tag == "bomb explosion" || other.gameObject.tag == "rightbul" || other.gameObject.tag == "down bul"
          || other.gameObject.tag == "left bul" || other.gameObject.tag == "spiral bullet" || other.gameObject.tag == "enemy bullet" ||
                other.gameObject.tag == "enemy" || other.gameObject.tag == "missile" || other.gameObject.tag == "missile2")
            {
                current_HP[HP].SetActive(false);
                HP -= 1;
                //Debug.Log(HP);
                GetComponent<flashingscript>().on = true;
                canHit = false;

            }
        }
       
        if (other.gameObject.tag == "healthUp")
        {
            Debug.Log("ur Getting hp");
            if (HP <= 4)
            {
                HP += 1;
            }
            current_HP[HP].SetActive(true);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "thrown")
        {
            Destroy(gameObject);
        }

    }
}
