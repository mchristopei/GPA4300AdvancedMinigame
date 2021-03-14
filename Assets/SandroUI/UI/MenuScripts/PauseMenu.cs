using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    [SerializeField] private GameObject BackGround;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameIsPaused)
        {
                Pause();
        }

    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        BackGround.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }


    void Pause ()
    {
        pauseMenuUi.SetActive(true);
        BackGround.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

   
 

    public void LoadMenu()
    {
        Time.timeScale = 3f;
        SceneManager.LoadScene("StartMenu");
    }

    

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

}
