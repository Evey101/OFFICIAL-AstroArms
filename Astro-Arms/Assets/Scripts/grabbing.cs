using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbing : MonoBehaviour 
{
    public GameObject player;
    public cannon_enemy_move cannon_enemy_script;
    public spiral_dude_behavior spriral_dude_script;
    public trianglescript triangle_enemy_script;
    public vanillaenemyscript vanilla_enemy_script;
    public bool intrigger;
    public bool Can_Grab;
    public int let_go_counter;
    public bool grab;

	// Use this for initialization
	void Start () 
    {
        Can_Grab = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position = player.transform.position + new Vector3(0f, 2f, 0f);
	}  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        intrigger = true;
        Can_Grab = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "vanilla enemy")
        {
            if (collision.gameObject.GetComponent<vanillaenemyscript>().let_go_counter == 1 && Can_Grab == true)
            {
                collision.gameObject.GetComponent<vanillaenemyscript>().free = false;
                Can_Grab = false;
            }
            if (collision.gameObject.GetComponent<vanillaenemyscript>().let_go_counter == 2)
            {
                Debug.Log("freeee");
                collision.gameObject.GetComponent<vanillaenemyscript>().free = true;
                collision.gameObject.GetComponent<vanillaenemyscript>().speed = new Vector2(0, 16);
            }
        }
        if (collision.gameObject.tag == "triangle enemy")
        {
            if (collision.gameObject.GetComponent<trianglescript>().let_go_counter == 1 && Can_Grab == true)
            {
                collision.gameObject.GetComponent<trianglescript>().free = false;
                Can_Grab = false;
            }
            if (collision.gameObject.GetComponent<trianglescript>().let_go_counter == 2)
            {
                Debug.Log("freeee");
                collision.gameObject.GetComponent<trianglescript>().free = true;
                collision.gameObject.GetComponent<trianglescript>().thrown = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        intrigger = false;
    }
}
