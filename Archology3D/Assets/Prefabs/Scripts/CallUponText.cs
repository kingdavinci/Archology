using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CallUponText : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 0;
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3.5)
        {
            GetComponent<Text>().enabled = false;
        }
        else
        {
            GetComponent<Text>().enabled = true;
        }
    }
}
