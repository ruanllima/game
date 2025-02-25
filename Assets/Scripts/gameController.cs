using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public int totalScore;
    public TextMeshProUGUI scoreText;   
    public static gameController instance;
    public GameObject winCanvas;
    public GameObject loserCanvas;

    void Start()
    {
        instance = this;
    }

    public void updateScore()
    {
        scoreText.text = totalScore.ToString();
    }

    public void ChangeScene(string sceneName = "")
    {   
        if(string.IsNullOrEmpty(sceneName))
        {
            sceneName = SceneManager.GetActiveScene().name;
        }
        SceneManager.LoadScene(sceneName);
    }

    public void showWinCanvas()
    {
        winCanvas.gameObject.SetActive(true);
    }

    public void showLoseCanvas()
    {
        loserCanvas.gameObject.SetActive(true);
    }
}
