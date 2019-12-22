using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCol : MonoBehaviour
{

    


    public void OnTriggerEnter2D(Collider2D col)
    {
        
        Debug.Log("Collision Detected " + col.gameObject.name);

        if (col.gameObject.tag == "preto")
        {
            
            col.GetComponent<EnemyDamage>().Damaged();
            Destroy(gameObject);                           
        }
        if (col.gameObject.tag == "Walls")
        {
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Boss")
        {
            col.GetComponent<BossDamage>().BossDamaged();
            Destroy(gameObject);
        }
    }





}
  
