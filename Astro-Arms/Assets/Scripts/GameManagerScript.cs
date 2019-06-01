using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int mode, enemyDied;

    [System.Serializable]
    public class WaveSpecs
    {
        public Vector3 spawnPosition;
        public float beginningTime;
        public GameObject EnemyType;
    }
    public List<WaveSpecs> enemyWave;
    public float timePassing;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timePassing += Time.deltaTime;

        for (int i = 0; i < enemyWave.Count; i++)
        {
            if (timePassing > enemyWave[i].beginningTime)
            {
                Instantiate(enemyWave[i].EnemyType, enemyWave[i].spawnPosition, Quaternion.identity);
                enemyWave.RemoveAt(i);
            }
        }

    }
}
