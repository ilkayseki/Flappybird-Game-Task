using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    #region Singleton 

    public static GameManager Instance { get; private set; }
    private void Awake() 
    { 
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    #endregion


    public GameObject gameOverScreen;
    
    public GameObject gameStartScreen;
    
    public bool gameOver = false;

    public bool isGameStarted;

    public float scrollSpeed=-2.1f;

    
    public TextMeshProUGUI scoreText;
    private int score = 0;
    
   
    public Bomb bomb;
    
    void Start()
    {
        Time.timeScale = 1;
        isGameStarted=false;
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }

        score++;
        scoreText.text = score.ToString();
        
        if (score % 10 == 0)
        {
            bomb.CreateBomb();
        }
    }
    
   public void BirdDied()
    {
        gameOverScreen.SetActive(true);
        gameOver = true;
        Leaderboard.Instance.GetScore(score);
        Time.timeScale = 0;
    }

   public void GameStart()
   {
       isGameStarted = true;
       gameStartScreen.SetActive(false);
       scoreText.gameObject.SetActive(true);
   }

   public void RestartGame()
   {
       SceneManager.LoadScene(0);
   }
   
   
}
