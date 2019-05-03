using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject FlashLight;
   // public bool HasFlashlight;
    public GameObject FlashlightInHand;
    // Update is called once per frame
    void Update()
    {
    /*    void OnCollisionEnter(Collision Collision)
        {
            if (Collision.gameObject.tag == "Player")
            {
                Destroy(FlashLight);
                HasFlashlight = true;
            }
        }
        if (HasFlashlight == true)
        {
            FlashlightInHand.SetActive(true);
        }
       // if (HasFlashlight == false)
        //{
        //    FlashlightInHand.SetActive(false);
        //}*/
    }
    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Player")
        {
            Destroy(FlashLight);
            FlashlightInHand.SetActive(true);
           // HasFlashlight = true;
        }
      //  if (HasFlashlight == true)
       // {
       //     FlashlightInHand.SetActive(true);
       // }
    }
}
