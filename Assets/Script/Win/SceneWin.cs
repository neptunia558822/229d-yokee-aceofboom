using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaneWin : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ResetGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void UpdateScore()
    {
        scoreText.text = GameManager.nScore.ToString($"You Score : {GameManager.nScore}");
    }

    void Update()
    {
        UpdateScore();
    }
}
