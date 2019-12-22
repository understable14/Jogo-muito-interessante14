using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashAtack : MonoBehaviour
{
    public float sl_cd = 0;
    public float bal_sl_cd = 1;
    public float animation_time = 0;
    public float bal_animation_time = 0.15f;

    //These are enemies that can be attacked
    private readonly List<EnemyDamage> _enemiesInRange = new List<EnemyDamage>();

    private Animator _anim;
    private bool _startAnimation;
    private bool _attack;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("preto"))
        {
            var enemyDamage = col.GetComponentInChildren<EnemyDamage>();
            _enemiesInRange.Add(enemyDamage);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("preto"))
        {
            var enemyDamage = col.GetComponentInChildren<EnemyDamage>();
            _enemiesInRange.Remove(enemyDamage);
        }
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") & sl_cd <= 0)
        {
            _anim.SetTrigger("slash");
            sl_cd = bal_sl_cd;
            _startAnimation = true;
        }

        if (sl_cd > 0)
        {
            sl_cd -= Time.deltaTime;
        }

        if (_startAnimation & animation_time <= 0)
        {
            _attack = true;
            animation_time = bal_animation_time;
            _startAnimation = false;
        }
        else if (_startAnimation == false & animation_time <= 0)
        {
            _attack = false;
        }

        if (animation_time > 0)
        {
            animation_time -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (_attack)
        {
            foreach (var enemyDamage in new List<EnemyDamage>(_enemiesInRange))
            {
                enemyDamage.SwordDamaged();
            }
        }
    }
}