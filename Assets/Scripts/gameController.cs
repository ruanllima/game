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
    public string[] scenes;
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

    public void showCanvas(GameObject canvas)
    {
        canvas.gameObject.SetActive(true);
    }

    public void hideCanvas(GameObject canvas)
    {
        canvas.gameObject.SetActive(false);
    }

    // Checks the current level and gets the value for next level and loads the scene for that level
    public void loadNextLevel(){
        string currentScene = SceneManager.GetActiveScene().name;
        string[] array = currentScene.Split(" ");
        int lvl = int.Parse(array[1]);
        string nextLevel = "lvl " + (lvl + 1);
        SceneManager.LoadScene(nextLevel);
    }
}
