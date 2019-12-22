using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Hp_Drain PlayerHealth;
    public GameObject enemy;
    public GameObject Boss1;
    public ScoreManager score;
    public bool BossBibo;
    
    public float SpawnTimer = 1f;
    public Transform[] SpawnPoints;
    
  





    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", SpawnTimer, SpawnTimer);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score.Score >= 1400 & !BossBibo)
        {
            Instantiate(Boss1);
            BossBibo = true;
        }
    }

    public void Spawn()
    {
        if(PlayerHealth.PlayerHp <= 0)
        {
            return;
        }
        int spawnPointIndex = Random.Range(0, SpawnPoints.Length);
        Instantiate(enemy, SpawnPoints[spawnPointIndex].position, SpawnPoints[spawnPointIndex].rotation);
        
        
    }

}
