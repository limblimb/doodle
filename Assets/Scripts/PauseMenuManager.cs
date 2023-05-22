using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);   
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; 
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu"); 
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game Scene");
    }
}
