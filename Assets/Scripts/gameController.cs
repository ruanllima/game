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

    void Start()
    {
        instance = this;
    }

    public void updateScore()
    {
        scoreText.text = totalScore.ToString();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
