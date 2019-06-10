 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorescript : MonoBehaviour 
{
    public float timer, finalscore;
    public playerController player;
    public Image scoresq, livessq, enemiysq, finalsq;
    public Text scoretxt, livetxt, enemytxt, finaltxt;
    public bool h;
    public int bonus, thing, lives;

	// Use this for initialization
	void Start () 
    {
        scoresq.gameObject.SetActive(false);
        livessq.gameObject.SetActive(false);
      
        scoretxt.gameObject.SetActive(false);
        livetxt.gameObject.SetActive(false);

        thing = 100;
        h = true;
      
        player = GameObject.Find("player").GetComponent<playerController>();
	}

    // Update is called once per frame
    void Update()
    {
        if (h == true)
        {
            lives = player.HP += 1;
            bonus = lives * 10;
         
            h = false;
        }
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            scoresq.gameObject.SetActive(true);
        }
        if (timer >= 2)
        {
            scoretxt.gameObject.SetActive(true);
            scoretxt.text = "" + player.score;
        }
        if (timer >= 3)
        {
            livessq.gameObject.SetActive(true);
        }
        if (timer >= 4)
        {
            livetxt.gameObject.SetActive(true);
            livetxt.text = "" + lives + " lives (+" + bonus + ")"; 
        }
        if ( timer >= 5)
        {
            if (player.score != player.score + bonus) // change later
            {
                player.score += 1;
            }
            if (bonus > 0)
            {
                bonus -= 1;
            }
        }
    }
}
