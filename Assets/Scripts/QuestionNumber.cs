using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class QuestionNumber : MonoBehaviour
{
    Text text;
    Transform textBase;
    Text[] curTexts;
    // number of questions in each scene
    int number;
    public void Start()
    {
        text = this.transform.GetChild(0).GetComponent<Text>();
        textBase = this.transform.parent.Find("Text_Base");
        InvokeRepeating("UpdateNumber", 0, 0.2f);
        number = 5;
    }

    private void UpdateNumber()
    {
        curTexts = textBase.GetComponentsInChildren<Text>();
        foreach(var curText in curTexts)
        {
            if(curText.gameObject.activeInHierarchy && curText.name != "Text_Base")
            {
                int questionNumber = int.Parse(curText.name.Substring(curText.name.Length - 3, 1));
                int sceneNumber = int.Parse(curText.name.Substring(curText.name.Length - 5, 1));
                int curNumber = (sceneNumber - 1) * 5 + questionNumber;
                string sceneName = SceneManager.GetActiveScene().name;

                if (questionNumber <= number)
                {
                    if (sceneName == "Home") text.text = "Question: " + curNumber + "/8";
                    else if (sceneName == "Friend's home") text.text = "Question: " + curNumber + "/7";
                    else text.text = "Question: " + curNumber + "/15";

                }
                break;
            }
            
        }
    }
}
