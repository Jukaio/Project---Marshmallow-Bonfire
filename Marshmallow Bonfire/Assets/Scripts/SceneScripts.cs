using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScripts : MonoBehaviour
{
    public void LoadRandom()
    {
        int index = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        SceneManager.LoadScene(index);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
