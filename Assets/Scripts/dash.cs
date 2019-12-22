using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
    
    
    public float dashTime;
    public float startDashTime;
    public float cooldown;
    public float cdTime;
    public bool coolingDown = false;
    public Vector3 dashtarget;
    public float dashSpeed;
    public PointAndShoot pointAndShoot;
    public Rigidbody2D rb;
    public bool mouseClone;
    public static bool Upgraded = false;



        void Update()
        {

        if (Upgraded)
        {
            
                if ((Input.GetMouseButtonDown(1)) & !mouseClone & !coolingDown)
                {
                    dashtarget = pointAndShoot.target;
                    mouseClone = true;
                    
                }

                if (mouseClone)
                {
                    if (dashTime >= 0)
                    {
                        Vector3 difference = dashtarget - rb.transform.position;
                        transform.Translate(difference.x * Time.deltaTime * dashSpeed, difference.y * Time.deltaTime * dashSpeed, 0, Space.World);
                        

                        dashTime -= Time.deltaTime;
                        

                    }
                    else
                    {
                    mouseClone = false;
                    coolingDown = true;
                    dashTime = startDashTime;
                    }

                

                }
                
            
        }
        if (coolingDown)
        {
            
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                coolingDown = false;
                cooldown = cdTime;
            }
        }

    }
    }
