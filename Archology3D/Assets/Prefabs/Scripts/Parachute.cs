using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
[RequireComponent(typeof(RigidbodyFirstPersonController))]
public class Parachute : MonoBehaviour
{
    public bool wearingParachute;
    public bool usingParachute;
    public bool grounded;
    public Vector3 slowFall;
    public float airTime;
    float timer = 0;
    RigidbodyFirstPersonController RFPC;
    // Start is called before the first frame update
    void Start()
    {
        wearingParachute = false;
        usingParachute = false;
        grounded = true;
        RFPC = GetComponent<RigidbodyFirstPersonController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (wearingParachute == true && Input.GetKeyDown(KeyCode.F) && grounded == false)
        {
            wearingParachute = false;
            usingParachute = true;
            RFPC.advancedSettings.airControl = true;
        }
        if(usingParachute == true)
        {
            slowFall = GetComponent<Rigidbody>().velocity;
            slowFall.y = -2;
            GetComponent<Rigidbody>().velocity = slowFall;
            RFPC.advancedSettings.airControl = true;
            airTime += Time.deltaTime;
            if(airTime >= 8.0)
            {
                RFPC.advancedSettings.airControl = false;
                usingParachute = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Parachute")
        {
            Destroy(collision.gameObject);
            wearingParachute = true;
        }
        if(collision.gameObject.tag == "ground")
        {
            grounded = true;
            usingParachute = false;
            RFPC.advancedSettings.airControl = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            grounded = false;
        }
    }
}
