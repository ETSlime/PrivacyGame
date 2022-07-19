using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

/// <summary>
///
/// </summary>
public class StartGame : MonoBehaviour
{
    private void Awake()
    {
        // set frame rate
        Application.targetFrameRate = 500;
    }
    private void Start()
    {
        if (!Directory.Exists(Application.dataPath + "/Save/"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Save/");
        }
        SceneManager.LoadScene(1);
    }
}
