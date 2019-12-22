using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MovSpeed = 5f;

    public Rigidbody2D rb;
    public bool Moving = false;

    Vector2 movement;

    private Animator anim;

    // Update is called once per frame
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0 | movement.y != 0)
        {
            Moving = true;
            anim.SetBool("isMoving", true);

        }
        else
        {
            Moving = false;
            anim.SetBool("isMoving", false);
        }
    }
   

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MovSpeed * Time.deltaTime);
    }
}
