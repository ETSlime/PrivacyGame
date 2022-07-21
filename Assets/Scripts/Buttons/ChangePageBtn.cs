using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///
/// </summary>
public class ChangePageBtn : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.sceneCount == 1)
        {
            Transform Root;
            // result context root
            if (SceneManager.GetActiveScene().name == "Result Page")
                Root = this.transform.parent.Find("ResultContext");
            else
                Root = this.transform.parent.Find("TutorialContext");
            Transform leftBtn = this.transform.parent.Find("Left");
            Transform rightBtn = this.transform.parent.Find("Right");
            int curIndex = 0;
            int maxPage = Root.childCount - 1;
            // add listener for left btn
            leftBtn.GetComponent<GeneralIconButton>().onClick.AddListener(() =>
            {
                // disable current item
                Root.GetChild(curIndex).gameObject.SetActive(false);
                curIndex--;
                // enable previous item
                Root.GetChild(curIndex).gameObject.SetActive(true);

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
                Root.GetChild(curIndex).gameObject.SetActive(false);
                curIndex++;
                // enable next item
                Root.GetChild(curIndex).gameObject.SetActive(true);

                // enable left btn if index != 0
                if (curIndex != 0)
                    leftBtn.gameObject.SetActive(true);

                // disable right btn if index == max
                if (curIndex == maxPage)
                    rightBtn.gameObject.SetActive(false);
            });
        }
    }
}
