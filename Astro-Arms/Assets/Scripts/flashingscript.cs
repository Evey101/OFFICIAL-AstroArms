using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashingscript : MonoBehaviour 
{
    public Color startcolor;
    public float timer;
    public int amount;
    public bool on;
	// Use this for initialization
	void Start () 
    {
        timer = 0;
        startcolor = gameObject.GetComponent<SpriteRenderer>().color;
        startcolor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (on == false)
        {
            amount = 0;
        }
        if (on)
        {
            timer += Time.deltaTime;
            if (timer < .1f)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
            if (timer > .25f)
            {
                timer = 0;
                amount += 1;
            }
            if (amount == 3)
            {
                on = false;
            }

        }
       
          GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, startcolor, .5f);
	}

}
