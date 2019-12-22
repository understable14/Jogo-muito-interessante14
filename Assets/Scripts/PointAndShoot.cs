using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{

    public Vector3 target;
    public GameObject crosshairs;
    public GameObject duck;
    public GameObject ClosestEnemy;
    public GameObject bulletPrefab;
    
    

    public float cooldown;
    public bool cooldowntimer = false;

    public float bulletSpeed = 60.0f;
    public bool shooting = false;
    public GameObject effect;
    public float cdTime;
    

    
    
    
    



    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        
       

        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2 (target.x,target.y);

        

        if (target.x < duck.transform.position.x)
        {
             duck.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (target.x > duck.transform.position.x)
        {
            duck.transform.rotation = Quaternion.Euler(0, 180, 0);
        }


        Vector3 difference = target - duck.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        float distance = difference.magnitude;

        //if (Input.GetKey("space") && EnemyDistance.Distance <= 2)
        //{
           // ClosestEnemy.GetComponent<EnemyDamage>().SwordDamaged();
        //}

        if (Input.GetMouseButtonDown(0))

        {

            Vector2 direction = difference / distance;
            direction.Normalize();
            if (!cooldowntimer)
            {
                FireBullet(direction, rotationZ);
                cooldowntimer = true;
                Instantiate(effect, duck.transform.position, Quaternion.identity);
                shooting = true;
            }
        }

            if (cooldowntimer)
            {
                shooting = false;
                cooldown -= Time.deltaTime;
                if (cooldown <= 0)
                {
                    cooldowntimer = false;
                    cooldown = cdTime;
                }
            }
        



    }
    void FireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = duck.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

    }

   

}
