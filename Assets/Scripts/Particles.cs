using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{

    public PointAndShoot particles;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (particles.shooting == true)
        {
            var exp = GetComponent<ParticleSystem>();
            exp.Play();
        }
    }
}
