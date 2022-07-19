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
            // initially 2 tips
            int tipsUsed = Player.tipsBought - Player.tips - 2;
            int numOfQuestion = 10;
            // device count of quizzes
            int num_fr = 1, num_ps = 3, num_is = 1, num_fs = 2, num_c = 1, num_ts = 1, num_sp = 1;
            // correct device count
            int num_fr_c = 0, num_ps_c = 0, num_is_c = 0, num_fs_c = 0, num_c_c = 0, num_ts_c = 0, num_sp_c = 0;
            foreach(var item in Player.getCoins)
            {
                string device = item.device;
                if (device == "facial recognition")
                    num_fr_c++;
                if (device == "presence sensor")
                    num_ps_c++;
                if (device == "iris scanner")
                    num_is_c++;
                if (device == "fingerprint scanner")
                    num_fs_c++;
                if (device == "camera")
                    num_c_c++;
                if (device == "temperature sensor")
                    num_ts_c++;
                if (device == "smartphone")
                    num_sp++;
            }

            // calculate overall correctness
            double overallCorrectness = Player.correct / numOfQuestion;

            // calculate correctness for each device
            double fr_correctness = num_fr_c / num_fr,
                ps_correctness = num_ps_c / num_ps,
                is_correctness = num_is_c / num_is,
                fs_correctness = num_fs_c / num_fs,
                c_correctness = num_c_c / num_c,
                ts_correctness = num_ts_c / num_ts,
                sp_correctness = num_sp_c / num_sp;

            // correctness with tips
            Dictionary<string, string> oneCorrect = new Dictionary<string, string>();
            Dictionary<string, string> twoCorrect = new Dictionary<string, string>();
            Dictionary<string, string> oneIncorrect = new Dictionary<string, string>();
            foreach (var item in Player.tipStates)
            {
                string device = item.device;
                string id = item.quizID;
                // use the second tip
                if(item.tips[1])
                {
                    twoCorrect.Add(id, device);
                }
                // use the first tip
                else if(item.tips[0])
                {
                    // correct
                    if (Player.getCoins.Exists(getcoins => getcoins.quizID == id))
                        oneCorrect.Add(id, device);
                    else
                        oneIncorrect.Add(id, device);
                }
            }
        }
    }
}
