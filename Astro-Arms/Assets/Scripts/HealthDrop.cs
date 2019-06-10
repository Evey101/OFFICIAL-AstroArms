using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    public bool DropTheHealth;
    public bool enemyDead;
    public GameObject healthBox;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DropTheHealth && enemyDead)
        {
            Debug.Log("urdropping!");
            Instantiate(healthBox, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (enemyDead)
        {
            Destroy(gameObject);
        }
    }
}
