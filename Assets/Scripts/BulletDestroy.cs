using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D wall)
    {
        if (wall.gameObject.tag == "Walls")
        {
            Destroy(gameObject);
        }
    }


}
