using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp_Drain : MonoBehaviour
{

    public float BulletDamage;
    public Player_HP_Bar Player_HP_Bar;


    public float PlayerHp = 14;

    


    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision Detected " + col.gameObject.name);

        if (col.gameObject.tag == "Bullets")
        {          
            PlayerDamage(2);
            
            Destroy(col.gameObject);          
        }
      
    }

    public void PlayerDamage(float _BulletDamage)
    {
        _BulletDamage = BulletDamage;
        PlayerHp -= BulletDamage;
        Player_HP_Bar.setBar(PlayerHp / 14);
        if (PlayerHp <= 0)
        {
            Destroy(gameObject);
        }

    }


}
