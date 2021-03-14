using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("CheeseNuggets69");
        Debug.Log("Restart Game");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }


    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
