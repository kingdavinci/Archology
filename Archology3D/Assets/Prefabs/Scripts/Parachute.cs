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
    public int maxAirTime;
    private float timer2;
    private bool timer2Start = false;
    public GameObject text;
    private float timer3;
    private bool timer3Start = false;
    public GameObject text2;
    RigidbodyFirstPersonController RFPC;
    // Start is called before the first frame update
    void Start()
    {
        wearingParachute = false;
        usingParachute = false;
        grounded = true;
        RFPC = GetComponent<RigidbodyFirstPersonController>();
        maxAirTime = 8;
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
            slowFall.Normalize();
            slowFall *= RFPC.movementSettings.ForwardSpeed/2;
            GetComponent<Rigidbody>().velocity = slowFall;
            RFPC.advancedSettings.airControl = true;
            airTime += Time.deltaTime;
            timer3Start = true;
            text2.GetComponent<CallUponText>().timer = 0;
            Debug.Log(slowFall);
            if (airTime >= maxAirTime)
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
            timer2Start = true;
            Destroy(collision.gameObject);
            wearingParachute = true;
            text.GetComponent<CallUponText>().timer = 0;
        }
        if (collision.gameObject.tag == "ground")
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
