using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject FlashLight;
    public bool HasFlashlight;
    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter(Collision Collision)
        {
            if (Collision.gameObject.tag == "flashlight")
            {
                Destroy(FlashLight);
                HasFlashlight = true;
            }
        }
        if (HasFlashlight == true)
        {
            FlashLight.SetActive(true);
        }
        if (HasFlashlight == false)
        {
            FlashLight.SetActive(false);
        }
    }
}
