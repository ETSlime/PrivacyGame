using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class ReturnBtn : MonoBehaviour
{

    public void Return()
    {
        GameObject root = GameObject.Find("Return");
        GameObject panel = root.transform.Find("PopUp").gameObject;
        AudioSource audio = this.GetComponent<AudioSource>();
        switch (this.gameObject.name) 
        {
            case "Return":
                panel.SetActive(true);
                DisableBtn();
                break;
            case "Yes":
                if (audio) audio.Play();
                panel.SetActive(false);
                LoadGame.LoadScene(1);
                break;
            case "No":
                EnableBtn();
                if (audio) audio.Play();
                panel.SetActive(false);
                break;

        }
    }

    private void DisableBtn()
    {
        GameObject canvas = GameObject.Find("Canvas");
        Button[] buttons = canvas.GetComponentsInChildren<Button>();
        foreach (var button in buttons)
        {
            if(button.name != "Yes" && button.name != "No") button.enabled = false;
        }
    }
    private void EnableBtn()
    {
        GameObject canvas = GameObject.Find("Canvas");
        Button[] buttons = canvas.GetComponentsInChildren<Button>();
        foreach (var button in buttons)
        {
            button.enabled = true;
        }
    }
}
