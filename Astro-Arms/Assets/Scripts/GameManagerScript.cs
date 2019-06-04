using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public float timeB4Start;
    public int enemyDied;
    public int mode;
    public GameObject Player;
    [System.Serializable]
    public class WaveSpecs
    {
        public Vector3 spawnPosition;
        public Vector3 spawnRotation;
        public Vector3 scaling;
        public float beginningTime;
        public GameObject EnemyType;
        public bool DropHealthPack;
        public HealthDrop HD;
        public int bonusHP;

    }
    public List<WaveSpecs> enemyWave;
    public GameObject GOholderForOtherElements;
    public float timePassing;
    // Use this for initialization
    void Start()
    {
        timeB4Start = 63f;
    }

    // Update is called once per frame
    void Update()
    {
        timeB4Start -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && timeB4Start >= 5)
        {
            timeB4Start = 5;
        }
        if (Player.GetComponent<playerController>().pause == false && timeB4Start <= 0)
        {
            timePassing += Time.deltaTime;
        }
        for (int i = 0; i < enemyWave.Count; i++)
        {
            if (timePassing > enemyWave[i].beginningTime && timeB4Start <= 0)
            {
                GOholderForOtherElements = Instantiate(enemyWave[i].EnemyType, enemyWave[i].spawnPosition, Quaternion.Euler(enemyWave[i].spawnRotation));
                if (enemyWave[i].scaling == new Vector3(0, 0, 0))
                {
                    enemyWave[i].scaling = new Vector3(2, 2, 2);
                }
                GOholderForOtherElements.transform.localScale = enemyWave[i].scaling;
                enemyWave[i].HD = GOholderForOtherElements.GetComponent<HealthDrop>();
                enemyWave[i].HD.DropTheHealth = enemyWave[i].DropHealthPack;

                enemyWave.RemoveAt(i);
            }
        }

    }
}