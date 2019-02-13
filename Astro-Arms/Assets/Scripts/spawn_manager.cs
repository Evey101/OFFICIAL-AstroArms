using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_manager : MonoBehaviour
{
    public float Leveltimer;
    public float cannonEnemy_spawnTime;
    public GameObject cannonEnemy;
    public GameObject vanillaEnemy;
    public GameObject spiralEnemy;
    public GameObject triangleEnemy;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Leveltimer += Time.deltaTime;

    }

    void spawn_enemy()
    {
        
    }
    public IEnumerator level_one_spawn_manager()
    {
        yield return new WaitForSeconds(8f);
        for (int i = 0; i < 5; i++)
        {
            Instantiate(vanillaEnemy, new Vector3(3,10,0), Quaternion.identity);
            yield return new WaitForSeconds(1);
        }


    }
}
