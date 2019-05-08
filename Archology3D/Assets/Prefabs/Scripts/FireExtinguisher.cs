using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FireExtinguisher : MonoBehaviour
{
    //public Text Text;
    private float timer;
    private bool timerStart = false;
    public GameObject text;
    void Update()
    {
        /*if (timerStart)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer >= 3.5)
            {
                Text.enabled = false;
                timerStart = false;
                timer = 0;
            }
        }*/
    }
    void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "Player")
        {
            //Text.enabled = true;
            timerStart = true;
            Debug.Log(Collision.gameObject.name);
            Collision.gameObject.GetComponentInChildren<PlayerExtinguisher>().HasExtinguisher = true;
            Destroy(gameObject);
            text.GetComponent<CallUponText>().timer = 0;
            //GetComponent<MeshCollider>().enabled = false;
            //GetComponent<MeshRenderer>().enabled = false;
        }
    }
}