using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public static Action OnGameOver;
    public static bool isGameOver = false;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Text highscoreText;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isGameOver = false;
        OnGameOver += ShowGameOverPanel;
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retry(){
        SceneManager.LoadScene("Gameplay");
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowGameOverPanel(){
        isGameOver = true;
        Time.timeScale = 0;
        int score = Score.score;
        if(score > PlayerPrefs.GetInt("Highscore", 0)){
            PlayerPrefs.SetInt("Highscore", score);
        }
        gameOverPanel.SetActive(true);
        highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        scoreText.text = score.ToString();
    }

    void OnDestroy(){
        OnGameOver -= ShowGameOverPanel;
    }
}
