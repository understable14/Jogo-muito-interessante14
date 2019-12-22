using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP_Bar : MonoBehaviour
{

    public Transform bar;
    public GameObject duck;
    

    void Start()
    {
        bar = transform.Find("BarDuck");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = duck.transform.position;
    }

    public void setBar(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
