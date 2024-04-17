using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string newScene;

    public void NewGame()
    {
        SceneManager.LoadScene(newScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
