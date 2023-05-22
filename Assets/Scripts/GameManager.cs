using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject pauseMenu;
    public GameObject ui;
    public Transform cameraPos;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI deadScoreText;
    private int score;
    private int startCameraPosY;
    private float screenHeight;
    


    // Start is called before the first frame update
    void Start()
    {
        startCameraPosY = (int)cameraPos.transform.position.y;

        gameOverScreen.SetActive(false);
        pauseMenu.SetActive(false);
        screenHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        MakeGameOverScreenFollow();
        UpdateScore();
    }

    private void MakeGameOverScreenFollow()
    {
        if (PlayerController.isAlive)
        {
            gameOverScreen.transform.position = new Vector3(gameOverScreen.transform.position.x, cameraPos.position.y - screenHeight, gameOverScreen.transform.position.z);
        }
        else
        {
            gameOverScreen.SetActive(true);
            ui.SetActive(false);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        ui.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        ui.SetActive(true);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game Scene");
    }
    
    public void UpdateScore()
    {
        if (PlayerController.isAlive)
        {
            score = ((int)cameraPos.transform.position.y - startCameraPosY) * 33;
            scoreText.text = "Score: " + score;
            deadScoreText.text = "Your score is " + score;
        }
    }
}
