﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDiff : MonoBehaviour
{
    public int difficultyNumber = 1;
    public GameObject Enemy;
    public GameObject PauseMenu;
    //public bool TurnOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(difficultyNumber >=PlayerPrefs.GetInt("Difficulty"))
        // {
        //    GetComponent<MeshRenderer>().enabled = true;

        // }
        if (PauseMenu.GetComponent<MenuButtons>().diff == 2 && difficultyNumber == 2)
        {
            // TurnOff = true;
            GetComponent<SkinnedMeshRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            Enemy.GetComponent<CapsuleCollider>().enabled = true;
        }
        else if (PauseMenu.GetComponent<MenuButtons>().diff == 3 && difficultyNumber >= 2)
        {
            //   TurnOff = true;
            GetComponent<SkinnedMeshRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            Enemy.GetComponent<CapsuleCollider>().enabled = true;
        }
    }
}
