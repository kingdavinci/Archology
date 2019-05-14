using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// to do:
// 
// 
//
//
//
public class MenuButtons : MonoBehaviour
{
    //public Slider healthbar;
    public GameObject Player;
    public GameObject PauseMenu;
    public GameObject UI;
    public GameObject DifficultySettings;
    public int diff = 1;
    public void Start()
    {
        Time.timeScale = 1;
        LockCursorOff();
      //  PlayerPrefs.SetInt("Difficulty", diff);
        diff = PlayerPrefs.GetInt("Difficulty");
    }
    public void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("Difficulty"));
        //Debug.Log(PlayerPrefs.GetInt("Difficulty"));
        if (Input.GetKeyDown(KeyCode.P) & Time.timeScale == 1)
        {
            Pause();
        }
    }
    // pause button
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            LockCursorOff();
            Time.timeScale = 0;
            //make pause menu visible
            PauseMenu.GetComponent<Canvas>().enabled = true;
            UI.GetComponent<Canvas>().enabled = false;
        }
        else if (Time.timeScale == 0)
        {
            //unpause
            Resume();
            LockCursorOn();
        }

    }
    // new game button
    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
        LockCursorOn();
    }
    // quit button
    public void QuitGame()
    {
        Application.Quit();
    }
    // resume button
    public void Resume()
    {
        LockCursorOn();
        Time.timeScale = 1;
        UI.GetComponent<Canvas>().enabled = true;
        PauseMenu.GetComponent<Canvas>().enabled = false;
        DifficultySettings.GetComponent<Canvas>().enabled = false;
    }
    //retry button
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }
    //code below is for the difficulty settings
    public void DifficultySettingsMenu()
    {
        DifficultySettings.GetComponent<Canvas>().enabled = true;
        PauseMenu.GetComponent<Canvas>().enabled = false;
        UI.GetComponent<Canvas>().enabled = false;

    }
    //for the setting a go back button
    public void GoBack()
    {
        PauseMenu.GetComponent<Canvas>().enabled = true;
        DifficultySettings.GetComponent<Canvas>().enabled = false;
    }
    //exit pause menu button
    public void ExitMenu()
    {
        Resume();
    }

    //Easy Diffculty
    public void EasyMode()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
        PlayerPrefs.SetInt("Max HP", 5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    //Normal Diffculty
    public void NormalMode()
    {
        PlayerPrefs.SetInt("Difficulty", 2);
        PlayerPrefs.SetInt("Max HP", 3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    //Hard Diffculty
    public void HardMode()
    {
        PlayerPrefs.SetInt("Difficulty", 3);
        PlayerPrefs.SetInt("Max HP", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();

    }

    //Winscreen play again
    public void Playagain()
    {
        PlayerPrefs.SetInt("HelpCanvas", 1);
        SceneManager.LoadScene("Level1");
    }
   //WinScreen Not to Play again
   public void Backtomenu()
    {
        PlayerPrefs.SetInt("HelpCanvas", 1);
        SceneManager.LoadScene("TitleScene");
    }
    // lock cursor and unlock cursor
    public void LockCursorOn()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    public void LockCursorOff()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Load()
    {
        SaveMyPosition saveMyPosition = Player.GetComponent<SaveMyPosition>();
        saveMyPosition.Load();
    }
    public void Save()
    {
        SaveMyPosition saveMyPostion = Player.GetComponent<SaveMyPosition>();
        saveMyPostion.Save();
    }
    public void ToInfoMenu()
    {
        SceneManager.LoadScene("StoryArcText");
    }

}
