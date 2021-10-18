using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lastPlayedStage;

    public int bestScore;
    public int currentScore;

    public int currentLevel = 0;

    public static GameManager singleton;
    
    
    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }

        bestScore = PlayerPrefs.GetInt("HighScore");
    }


    public void NextLevel()
    {
        currentLevel++;
        FindObjectOfType<HelixController>().LoadStage(currentLevel);
        FindObjectOfType<BallController>().ResetBall();
        Debug.Log("Nuevo Nivel" + currentLevel);
    }
    public void RestartLevel()
    {
        Debug.Log("Restart");
        singleton.currentScore = 0;
        lastPlayedStage = PlayerPrefs.GetInt("LastPlayedStage");
        FindObjectOfType<HelixController>().LoadStage(lastPlayedStage);
        FindObjectOfType<BallController>().ResetBall();
        Debug.Log("Message: " + PlayerPrefs.GetInt("LastPlayedStage"));
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }
    
    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
    
    public void SalirDelJuego() 
    {
            Application.Quit();
    }
    
}
