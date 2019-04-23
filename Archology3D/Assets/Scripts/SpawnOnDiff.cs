using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDiff : MonoBehaviour
{
    public int difficultyNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(difficultyNumber >=PlayerPrefs.GetInt("Difficulty"))
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
