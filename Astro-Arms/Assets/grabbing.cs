using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbing : MonoBehaviour 
{
    public GameObject player;
    public Animator anim;
    public cannon_enemy_move cannon_enemy_script;
    public spiral_dude_behavior spriral_dude_script;
    public trianglescript triangle_enemy_script;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cannon_enemy_script.free = false;
            anim.Play("grabbin anim");
            Debug.Log("Playing animation");
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {


    }
}
