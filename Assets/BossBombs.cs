using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBombs : MonoBehaviour
{
    public GameObject mira;
    public GameObject currentMira;
    public EnemySpawner Boss;
    public Transform miraPosition;
    public float delay;
    public bool miraOn;
    public bool Firing = false;
    public float cooldown;
    public float bassCooldown;


    public void Start()
    {

    }
    public void Update()
    {
        if (Boss.BossBibo & !Firing)
        {
            InvokeRepeating("SpawnMira", delay, delay);
            Firing = true;
        }

        if (miraOn & cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        }
        if(cooldown <= 0)
        {
            miraOn = false;
            Destroy(currentMira);
            cooldown = bassCooldown;
        }
    }
    public void SpawnMira()

    {
        miraPosition.position = new Vector3(Random.Range(-8, 4), Random.Range(-4, 4), 0);
        currentMira = Instantiate(mira, miraPosition);
        miraOn = true;         

    }
}
   
