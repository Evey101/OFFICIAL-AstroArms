using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiral_dude_behavior : MonoBehaviour 
{
    public Rigidbody2D rb;
    public float timer;
    public List<GameObject> bullets;
    public GameObject bullet;
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;

        if(timer >= 5)
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
            //Debug.Log(i);
        }
        bullets.Clear();
    }

}
/*
 *         for (int i = 0; i < 20; i++)                                                                    //spawns the ring of bullets 
        {                                                                                               //spawns the ring of bullets 
            bullets.Add(Instantiate(bullet, transform.position, Quaternion.identity));                  //spawns the ring of bullets 
            bullets[i].transform.Rotate(0, 0, 20 * i);                                                  //spawns the ring of bullets 
        }   

*/