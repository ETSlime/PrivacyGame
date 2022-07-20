using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
            int tipsUsed = Player.tipsBought - Player.tips + 2;
            int numOfQuestion = 10;
            // device count of quizzes
            double num_fr = 1, num_ps = 3, num_is = 1, num_fs = 2, num_c = 1, num_ts = 1, num_sp = 1;
            // correct device count
            double num_fr_c = 0, num_ps_c = 0, num_is_c = 0, num_fs_c = 0, num_c_c = 0, num_ts_c = 0, num_sp_c = 0;
            foreach(var item in Player.getCoins)
            {
                string device = item.device;
                bool get = item.get;
                if (device == "facial recognition" && get)
                    num_fr_c++;
                if (device == "presence sensor" && get)
                    num_ps_c++;
                if (device == "iris scanner" && get)
                    num_is_c++;
                if (device == "fingerprint scanner" && get)
                    num_fs_c++;
                if (device == "camera" && get)
                    num_c_c++;
                if (device == "temperature sensor" && get)
                    num_ts_c++;
                if (device == "smartphone" && get)
                    num_sp_c++;
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
            Dictionary<string, string> twoIncorrect = new Dictionary<string, string>();
            foreach (var item in Player.tipStates)
            {
                string device = item.device;
                string id = item.quizID;
                // use the second tip
                if(item.tips[1])
                {
                    // correct
                    if (Player.getCoins.Exists(getcoins => getcoins.quizID == id && getcoins.get == true))
                        twoCorrect.Add(id, device);
                    else
                        twoIncorrect.Add(id, device);
                }
                // use the first tip
                else if(item.tips[0])
                {
                    // correct
                    if (Player.getCoins.Exists(getcoins => getcoins.quizID == id && getcoins.get == true))
                        oneCorrect.Add(id, device);
                    else
                        oneIncorrect.Add(id, device);
                }
            }

            // text2 context
            Text text2 = resultRoot.Find("Text2").GetComponent<Text>();
            string correct;
            if (Player.correct == numOfQuestion)
                correct = "Congratulations! You got all questions (<color=green>10</color>/10) right! You have mastered the knowledge about IoT devices.";
            else if (Player.correct >= 7)
                correct = "You got <color=green>" + Player.correct + "</color>/10 questions right. Great job!";
            else if (Player.correct >= 3)
                correct = "You got <color=yellow>" + Player.correct + "</color>/10 questions right. Find the quiz difficult? Check the tip button to get some help!";
            else
                correct = "You got <color=red>" + Player.correct + "</color>/10 questions right. Are you seriously taking the quiz?";
            List<string> familiarList = new List<string>();
            List<string> unfamiliarList = new List<string>();
            string fr_color, ps_color, is_color, fs_color, c_color, ts_color, sp_color;

            if (fr_correctness > 0.6)
            {
                familiarList.Add("facial recognition");
                fr_color = "<color=green>";
            }
            else
            {
                unfamiliarList.Add("facial recognition");
                fr_color = "<color=red>";
            }
                
            if (ps_correctness > 0.6)
            {
                familiarList.Add("presence sensor");
                ps_color = "<color=green>";
            }
            else
            {
                unfamiliarList.Add("presence sensor");
                ps_color = "<color=red>";
            }
                
            if (is_correctness > 0.6)
            {
                familiarList.Add("iris scanner");
                is_color = "<color=green>";
            }
            else
            {
                unfamiliarList.Add("iris scanner");
                is_color = "<color=red>";
            }
                
            if (fs_correctness > 0.6)
            {
                familiarList.Add("fingerprint scanner");
                fs_color = "<color=green>";
            }
            else
            {
                unfamiliarList.Add("fingerprint scanner");
                fs_color = "<color=red>";
            }
                
            if (c_correctness > 0.6)
            {
                familiarList.Add("camera");
                c_color = "<color=green>";
            }
            else
            {
                unfamiliarList.Add("camera");
                c_color = "<color=red>";
            }
                
            if (ts_correctness > 0.6)
            {
                familiarList.Add("temperature sensor");
                ts_color = "<color=green>";
            }  
            else
            {
                unfamiliarList.Add("temperature sensor");
                ts_color = "<color=red>";
            }
                
            if (sp_correctness > 0.6)
            {
                familiarList.Add("smartphone");
                sp_color = "<color=green>";
            }
            else
            {
                unfamiliarList.Add("smartphone");
                sp_color = "<color=red>";
            }
                
            string familiar = null, unfamiliar = null;
            foreach (var item in familiarList)
            {
                familiar += "<i><color=green>" + item + "</color></i>" + ", ";
            }
            foreach (var item in unfamiliarList)
            {
                unfamiliar += "<i><color=red>" + item + "</color></i>" + ", ";
            }
            if (familiar == null)
                familiar = "You are not familiar with any IoT device, so sad.";
            if (unfamiliar == null)
                unfamiliar = "You are familiar with every IoT device in this game, nice!";
            text2.text = "Number of correct:\n" + correct + "\nYou are familiar with the following IoT devices:\n" 
                + familiar + "\nYou are not familiar with the following IoT devices:\n" + unfamiliar;

            // text3 context
            Text text3 = resultRoot.Find("Text3").GetComponent<Text>();
            string accuracy;
            accuracy = "facial recognition: " + fr_color + fr_correctness.ToString("P") + "</color>" + " , " + "presence sensor: " + 
                ps_color + ps_correctness.ToString("P") + "</color>" + " , " + "iris scanner: " + is_color + is_correctness.ToString("P") + 
                "</color>" + " , " + "fingerprint scanner: " + fs_color + fs_correctness.ToString("P") + "</color>" + " , " +
                "camera: " + c_color + c_correctness.ToString("P") + "</color>" + " , " + "temperature sensor: " + ts_color + 
                ts_correctness.ToString("P") + "</color>" + " , " + "smartphone: " + sp_color + sp_correctness.ToString("P") + "</color>";
            text3.text = "Your accuracy for each specific device:\n" + accuracy;

            // text4 context
            Text text4 = resultRoot.Find("Text4").GetComponent<Text>();
            string tipsComment;
            if (tipsUsed == 0)
                tipsComment = "You didn't use any tips. You are so brave!";
            else if (tipsUsed > 10)
                tipsComment = "Wow! You used so many tips. Did you acquire some knowledge after reading them?";
            else
                tipsComment = "";

            string oneCorrectText = null, twoCorrectText = null, oneIncorrectText = null, twoIncorrectText = null;

            string convert(string id)
            {
                switch (id)
                {
                    case "cs_2.1":
                        return "store_1";
                    case "cs_3.4":
                        return "store_2";
                    case "lb_1.1":
                        return "library_1";
                    case "lb_2.3":
                        return "library_2";
                    case "lb_3.3":
                        return "library_3";
                    case "hm_1.1":
                        return "home_1";
                    case "hm_1.4":
                        return "home_2";
                    case "fh_2.1":
                        return "friend's home_1";
                    case "wk_2.4":
                        return "work_1";
                    case "wk_3.4":
                        return "work_2";
                    default:
                        return null;
                }
            }

            foreach (var item in oneCorrect)
            {
                string quizID = item.Key, device = item.Value;
                oneCorrectText += "<color=green>" + convert(quizID) + "</color>" + ", ";
            }
            foreach (var item in twoCorrect)
            {
                string quizID = item.Key, device = item.Value;
                twoCorrectText += "<color=green>" + convert(quizID) + "</color>" + ", ";
            }
            foreach (var item in oneIncorrect)
            {
                string quizID = item.Key, device = item.Value;
                oneIncorrectText += "<color=red>" + convert(quizID) + "</color>" + ", ";
            }
            foreach (var item in twoIncorrect)
            {
                string quizID = item.Key, device = item.Value;
                twoIncorrectText += "<color=red>" + convert(quizID) + "</color>" + ", ";
            }



            string oneIncorrectComment = "", twoIncorrectComment = "";
            if (oneCorrectText == null)
                oneCorrectText = "None";
            if (twoCorrectText == null)
                twoCorrectText = "None";
            if (oneIncorrectText == null)
                oneIncorrectText = "";
            else
                oneIncorrectComment = "\nYou still got the following questions <color=red>wrong</color> after reading tips <i>once</i>: " + oneIncorrectText;
            if (twoIncorrectText == null)
                twoIncorrectText = "";
            else
                twoIncorrectComment = "\nAre you seriously? You got the following questiongs <color=red>wrong</color> after reading tips <i>twice</i>: " + twoIncorrectText;
            text4.text = "For the usage of tips, you totally used <color=red>" + tipsUsed + "</color>. " + tipsComment +
                "\nYou correctly answered the following questions after reading tips <i>once</i>: " + oneCorrectText +
                "\nYou correctly answered the following questions after reading tips <i>twice</i>: " + twoCorrectText + oneIncorrectComment + twoIncorrectComment;
        }
    }
}
