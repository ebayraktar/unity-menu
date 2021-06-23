using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameManager gm;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        gm.clickable = true;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        gm.clickable = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        gm.clickable = true;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }

}
