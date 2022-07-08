using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///
/// </summary>
public class JumpBtnInit : MonoBehaviour
{
    private void Start()
    {
        if(Player.questionFinished != null)
        {
            switch (this.transform.GetChild(0).name)
            {
                case "RightArrow_cs_1":
                    if (Player.questionFinished.Exists(questionState => questionState.questionId == "cs_1"))
                        this.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case "RightArrow_cs_2":
                    if (Player.questionFinished.Exists(questionState => questionState.questionId == "cs_2"))
                        this.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case "RightArrow_lb_1":
                    if (Player.questionFinished.Exists(questionState => questionState.questionId == "lb_1"))
                        this.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case "RightArrow_lb_2":
                    if (Player.questionFinished.Exists(questionState => questionState.questionId == "lb_2"))
                        this.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case "RightArrow_hm_1":
                    if (Player.questionFinished.Exists(questionState => questionState.questionId == "hm_1"))
                        this.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case "RightArrow_fh_1":
                    if (Player.questionFinished.Exists(questionState => questionState.questionId == "fh_1"))
                        this.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case "BackArrow":
                    switch (SceneManager.GetActiveScene().name)
                    {
                        case "Department Store":
                            if (Player.questionFinished.Exists(questionState => questionState.questionId == "cs_3"))
                                this.transform.GetChild(0).gameObject.SetActive(true);
                            break;
                        case "Library":
                            if (Player.questionFinished.Exists(questionState => questionState.questionId == "lb_3"))
                                this.transform.GetChild(0).gameObject.SetActive(true);
                            break;
                        case "Home":
                            if (Player.questionFinished.Exists(questionState => questionState.questionId == "hm_2"))
                                this.transform.GetChild(0).gameObject.SetActive(true);
                            break;
                        case "Friend's home":
                            if (Player.questionFinished.Exists(questionState => questionState.questionId == "fh_2"))
                                this.transform.GetChild(0).gameObject.SetActive(true);
                            break;
                        case "Work":
                            if (Player.questionFinished.Exists(questionState => questionState.questionId == "wk_3"))
                                this.transform.GetChild(0).gameObject.SetActive(true);
                            break;
                        case "Restroom":
                            if (Player.questionFinished.Exists(questionState => questionState.questionId == "pr_3"))
                                this.transform.GetChild(0).gameObject.SetActive(true);
                            break;
                    }
                    break;
            }
        }

    }
}
