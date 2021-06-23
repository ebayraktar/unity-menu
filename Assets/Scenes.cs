using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour {


    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
    public void PlayPuzzle()
    {
        SceneManager.LoadScene("Puzzle");
    }
}
