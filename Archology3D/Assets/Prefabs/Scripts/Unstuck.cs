using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unstuck : MonoBehaviour
{
    public int StuckRoll = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            StuckRoll = Random.Range(1, 4);
        }
    }
}
