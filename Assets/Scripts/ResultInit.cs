using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///
/// </summary>
public class ResultInit : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Result Page" && SceneManager.sceneCount == 1)
        {
            // result context root
            Transform resultRoot = this.transform.parent.Find("ResultContext");
            Transform leftBtn = this.transform.parent.Find("Left");
            Transform rightBtn = this.transform.parent.Find("Right");
            int curIndex = 0;
            int maxPage = resultRoot.childCount - 1;
            // add listener for left btn
            leftBtn.GetComponent<GeneralIconButton>().onClick.AddListener(()=>
            {
                // disable current item
                resultRoot.GetChild(curIndex).gameObject.SetActive(false);
                curIndex--;
                // enable previous item
                resultRoot.GetChild(curIndex).gameObject.SetActive(true);

                // enable right btn if index != max
                if (curIndex != maxPage)
                    rightBtn.gameObject.SetActive(true);

                // disable left btn if index == 0
                if (curIndex == 0)
                    leftBtn.gameObject.SetActive(false);
            });

            // add listener for right btn
            rightBtn.GetComponent<GeneralIconButton>().onClick.AddListener(() =>
            {
                // disable current item
                resultRoot.GetChild(curIndex).gameObject.SetActive(false);
                curIndex++;
                // enable next item
                resultRoot.GetChild(curIndex).gameObject.SetActive(true);

                // enable left btn if index != 0
                if (curIndex != 0)
                    leftBtn.gameObject.SetActive(true);

                // disable right btn if index == max
                if (curIndex == maxPage)
                    rightBtn.gameObject.SetActive(false);
            });

            // quizzes feedback
            int tipsUsed = Player.tipsBought - Player.tips;
            int numOfQuestion = 10;
            double overallCorrectness = Player.correct / numOfQuestion;
        }
    }
}
