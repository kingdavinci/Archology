using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadWinScreen : MonoBehaviour
{
    int EnemyCounter;

    private void Start()
    {
        EnemyCounter = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    void OnCollisionEnter(Collision collision)
    {

        //attaching this script to the portal
        //will load the win screen when player collides
        if (collision.gameObject.tag == "Flag" && EnemyCounter - GameObject.FindGameObjectsWithTag("Enemy").Length >= 2)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
