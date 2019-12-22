using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    public float BossHp;
    public GameObject bloodEffect;
    public GameObject hitEffect;
    public GameObject ScoreManagerObject;
    public HealthBar HpBar;
    public ScoreManager scoreManager;
    public float BaseBulletDamage;
    public static float UpgradeDmgMultiplier = 1;
    public float BulletDamage;
    





    public void Update()
    {
        BulletDamage = BaseBulletDamage * UpgradeDmgMultiplier;
    }

    public bool _dead;

    public void Awake()
    {
        ScoreManagerObject = GameObject.Find("ScoreManager");
        scoreManager = ScoreManagerObject.GetComponent<ScoreManager>();

    }

    public void BossDamaged()
    {
        if (_dead) return;               
        BossHp -= BulletDamage;
        HpBar.SetBar(BossHp / 50f);
        Instantiate(hitEffect, transform.position, Quaternion.identity);


        if (BossHp <= 0)
        {
            Destroy(gameObject);
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            scoreManager.BossDead = true;
            scoreManager.Tropiga += Random.Range(200, 400);

            _dead = true;
        }
    }

    public void SwordDamaged()
    {
        if (_dead) return;

        BossHp -= 100;

        if (BossHp <= 0)
        {
            Destroy(gameObject);
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            
            scoreManager.Tropiga += Random.Range(200, 400);

            _dead = true;
        }
    }
}

