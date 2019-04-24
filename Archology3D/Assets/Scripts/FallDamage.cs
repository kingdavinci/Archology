using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public bool grounded;
    private float airTime;


    void Update()
    {
        if (grounded == false)
        {
            airTime += Time.deltaTime;
        }

       /* if (airTime >= 5.0)
        {
            playerHP -= 5.0;
        }*/
    }

    //are you on the ground
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Ground")
        {
            grounded = true;
            airTime = 0;
        }
    }

    //if character is jumping
    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    //fall damage

}
