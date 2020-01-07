using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown_Manager : MonoBehaviour
{
    public Transform Cdbar;
    


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBar(float sizeNormalized)
    {
        Cdbar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
