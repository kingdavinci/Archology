using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective1 : MonoBehaviour
{
    public GameObject Canvas;
    public bool timerStart = false;
    public float timer;
    public int CanvasAppear = 1;
    // Start is called before the first frame update
    void Start()
    {
      //  PlayerPrefs.SetInt("HelpCanvas", CanvasAppear);
    }

    // Update is called once per frame
    void Update()
    {
        CanvasAppear = PlayerPrefs.GetInt("HelpCanvas");
        if(timerStart)
        {
            timer += Time.deltaTime;
        }
        if(timer >= 7)
        {
            Canvas.SetActive(false);
            timer = 0;
            PlayerPrefs.SetInt("HelpCanvas", 2);
            CanvasAppear = 2;
            Destroy(gameObject);
        }
    }
     void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && CanvasAppear == 1) 
        {
            Canvas.SetActive(true);
            timerStart = true;
        }
    }
}
