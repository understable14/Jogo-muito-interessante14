using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float Hp = 14;
    public GameObject bloodEffect;
    public GameObject hitEffect;
    public GameObject ScoreManagerObject;
    public HealthBar HpBar;
    public ScoreManager scoreManager;
    public float BaseBulletDamage;
    public static float UpgradeDmgMultiplier = 1;
    public float BulletDamage;
    
    //Bom dia
    


    public void Update()
    {
        BulletDamage = BaseBulletDamage * UpgradeDmgMultiplier;
    }

    private bool _dead;
    
    public void Awake()
    {
        ScoreManagerObject = GameObject.Find("ScoreManager");
        scoreManager = ScoreManagerObject.GetComponent<ScoreManager>();
        
    }

    public void Damaged()
    {
        if (_dead) return;

        Instantiate(hitEffect, transform.position, Quaternion.identity);
        
        Hp -= BulletDamage;
        HpBar.SetBar(Hp / 14f);
        
        
        if (Hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            scoreManager.Score += 1000;
            scoreManager.Tropiga += Random.Range(200, 400);

            _dead = true;
        }
    }

    public void SwordDamaged()
    {
        if (_dead) return;

        Hp -= 100;

        if (Hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            scoreManager.Score += 100;
            scoreManager.Tropiga += Random.Range(10, 14);

            _dead = true;
        }
    }
}

