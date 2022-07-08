using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


/// <summary>
///
/// </summary>
public class StartGame : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene(1);
    }
}
