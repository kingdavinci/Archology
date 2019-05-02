using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective1 : MonoBehaviour
{
    public GameObject Canvas;
    public bool timerStart = false;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerStart)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 7)
        {
            Canvas.SetActive(false);
            timer = 0;
        }
    }
     void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Canvas.SetActive(true);
            timerStart = true;
        }
    }
}
