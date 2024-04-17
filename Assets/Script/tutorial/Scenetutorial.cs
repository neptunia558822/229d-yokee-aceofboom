using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenetutorial : MonoBehaviour
{
    public void GameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ManuScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
