using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



/// <summary>
///
/// </summary>
public class LoadGame : MonoBehaviour
{

    // load scene by index
    static public void LoadScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    // load scene by name
    static public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void LoadScene0()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void LoadScene1()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadScene2()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void EndGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
