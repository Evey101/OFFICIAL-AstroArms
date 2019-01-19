using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainscript : MonoBehaviour 
{
    public List<Vector2> puspawns;
    public List<GameObject> powerups;
    public GameObject powerup;
    public Vector2 pos;
    public int mode;
    public float timer;

	// Use this for initialization
	void Start () 
    {
        mode = 0;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            mode = 1;
        }
        if (mode == 1)
        {
            powerup = powerups[Random.Range(0, 2)];
            pos = puspawns[Random.Range(0, 4)];
            Instantiate(powerup.gameObject, pos, Quaternion.identity);
            timer = 0;
            mode = 0;
        }
	}
}
