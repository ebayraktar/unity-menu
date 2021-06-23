using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Dropdown categoryDDown;
    public int category;

    private void Start()
    {
        category = PlayerPrefs.GetInt("Category", 2);
        categoryDDown.value = category;
    }

    public void Category(int _category)
    {
        category = _category;
        PlayerPrefs.SetInt("Category", category);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void PopAudio()
    {
        FindObjectOfType<AudioManager>().Play("Pop");
    }
}
