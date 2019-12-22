using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private Vector3 target;
    
    public GameObject duck;
    
    public GameObject bulletPrefab;

    public float cooldown;
    public bool cooldowntimer = false;

    public float bulletSpeed = 5.0f;

    public EnemyDamage Health;
    public Animator animGRShoot;

   

    void Start()
    {
        animGRShoot = GetComponent<Animator>();
    }




    // Update is called once per frame
    void Update()
    {

        duck = GameObject.Find("duck");
        target = duck.transform.position;
        

        Vector3 difference = target - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (!cooldowntimer)
        {
           
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            
                FireEnemyBullet(direction, rotationZ);
            cooldowntimer = true;
        }
        if (cooldowntimer)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                cooldowntimer = false;
                cooldown = 2;
            }
        }

        


    }
    void FireEnemyBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 180f);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        animGRShoot.SetTrigger("GR Shoot");
    }
}

