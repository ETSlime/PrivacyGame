using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class PageInit : MonoBehaviour
{
    // canvas
    private Transform root;
    private bool isActivate;
    private int numFinished;
    

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Select Location" && SceneManager.sceneCount == 1)
        {
            isActivate = true;
            numFinished = 0;

            // canvas root
            root = this.transform.parent;
            root.Find("Points").GetComponent<Text>().text = "Current Points: " + Player.points;
            root.Find("Name").GetComponent<Text>().text = "Name: " + Player.userName;
            root.Find("Answers").GetComponent<Text>().text = "Correct Answers: " + Player.correct;
            Image[] buttons = root.Find("Location").GetComponentsInChildren<Image>();
            // add btn for location
            foreach (var button in buttons)
            {
                button.gameObject.AddComponent<GeneralIconButton>();
            }

            // add btn for game
            GameObject game = root.Find("Game").gameObject;
            game.AddComponent<GeneralIconButton>();

            // add btn for shop
            GameObject shop = root.Find("Shop").gameObject;
            shop.AddComponent<GeneralIconButton>();

            // add btn for result page
            GameObject result = root.Find("Check Results").gameObject;
            result.AddComponent<GeneralIconButton>();

            // add btn for tutorial
            GameObject tutorial = root.Find("Tutorial").gameObject;
            tutorial.AddComponent<GeneralIconButton>();

            this.gameObject.AddComponent<AudioSource>();
            AudioSource audio = this.GetComponent<AudioSource>();
            audio.clip = Resources.Load<AudioClip>("SE/Btn_SE4");

            // add listener for each btn
            Transform store = root.GetChild(1).Find("store");
            store.GetComponent<GeneralIconButton>().onClick.AddListener(() =>
            {
                audio.Play();
                string content = "Do you want to go to the department store?";
                void load()
                {
                    LoadGame.LoadScene("Department Store");
                }
                DisableBtn();
                ConfirmationPanel.CreatePanel(root, content, load);
            });

            Transform library = root.GetChild(1).Find("library");
            library.GetComponent<GeneralIconButton>().onClick.AddListener(() =>
            {
                audio.Play();
                string content = "Do you want to go to the library?";
                void load()
                {
                    LoadGame.LoadScene("Library");
                }
                DisableBtn();
                ConfirmationPanel.CreatePanel(root, content, load);
            });

            Transform home = root.GetChild(1).Find("home");
            home.GetComponent<GeneralIconButton>().onClick.AddListener(() =>
            {
                audio.Play();
                string content = "Do you want to go home?";
                void load()
                {
                    LoadGame.LoadScene("Home");
                }
                DisableBtn();
                ConfirmationPanel.CreatePanel(root, content, load);
            });

            Transform friendshome = root.GetChild(1).Find("friend's home");
            friendshome.GetComponent<GeneralIconButton>().onClick.AddListener(() =>
            {
                audio.Play();
                string content = "Do you want to go friend's home?";
                void load()
                {
                    LoadGame.LoadScene("Friend's home");
                }
                DisableBtn();
                ConfirmationPanel.CreatePanel(root, content, load);
            });

            Transform work = root.GetChild(1).Find("work");
            work.GetComponent<GeneralIconButton>().onClick.AddListener(() =>
            {
                audio.Play();
                string content = "Do you want to go to the company?";
                void load()
                {
                    LoadGame.LoadScene("Work");
                }
                DisableBtn();
                ConfirmationPanel.CreatePanel(root, content, load);
            });

            Transform restroom = root.GetChild(1).Find("restroom");
            restroom.GetComponent<GeneralIconButton>().onClick.AddListener(() =>
            {
                audio.Play();
                string content = "Do you want to go to the public restroom?";
                void load()
                {
                    LoadGame.LoadScene("Restroom");
                }
                DisableBtn();
                ConfirmationPanel.CreatePanel(root, content, load);
            });

            game.GetComponent<GeneralIconButton>().onClick.AddListener(() =>
            {
                audio.Play();
                string content = "Do you want to play the mini game?";
                void load()
                {
                    LoadGame.LoadScene("Mini game");
                }
                DisableBtn();
                ConfirmationPanel.CreatePanel(root, content, load);
            });

            shop.GetComponent<GeneralIconButton>().onClick.AddListener(() =>
            {
                audio.Play();
                string content = "Do you want to go to the shop?";
                void load()
                {
                    LoadGame.LoadScene("Shop");
                }
                DisableBtn();
                ConfirmationPanel.CreatePanel(root, content, load);
            });

            result.GetComponent<GeneralIconButton>().onClick.AddListener(() =>
            {
                audio.Play();
                string content = "Do you want to check your results?";
                void load()
                {
                    LoadGame.LoadScene("Result Page");
                }
                DisableBtn();
                ConfirmationPanel.CreatePanel(root, content, load);
            });

            tutorial.GetComponent<GeneralIconButton>().onClick.AddListener(() =>
            {
                audio.Play();
                string content = "Do you want to read the tutorial?";
                void load()
                {
                    LoadGame.LoadScene("Main Tutorial");
                }
                DisableBtn();
                ConfirmationPanel.CreatePanel(root, content, load);
            });

            // check finished location
            if (Player.questionFinished.Exists(QuestionState => QuestionState.questionId == "cs_3"))
            {
                numFinished++;
                store.GetChild(1).gameObject.SetActive(true);
            }
            if (Player.questionFinished.Exists(QuestionState => QuestionState.questionId == "lb_3"))
            {
                numFinished++;
                library.GetChild(1).gameObject.SetActive(true);
            }
            if (Player.questionFinished.Exists(QuestionState => QuestionState.questionId == "hm_2"))
            {
                numFinished++;
                home.GetChild(1).gameObject.SetActive(true);
            }
            if (Player.questionFinished.Exists(QuestionState => QuestionState.questionId == "fh_2"))
            {
                numFinished++;
                friendshome.GetChild(1).gameObject.SetActive(true);
            }
            if (Player.questionFinished.Exists(QuestionState => QuestionState.questionId == "wk_3"))
            {
                numFinished++;
                work.GetChild(1).gameObject.SetActive(true);
            }
            if (Player.questionFinished.Exists(QuestionState => QuestionState.questionId == "pr_3"))
            {
                numFinished++;
                restroom.GetChild(1).gameObject.SetActive(true);
            }

            // enable results page btn
            if (numFinished == 6)
            {
                result.SetActive(true);
                Player.finished = true;
                Save.SaveByJSON();
            }
                
        }

    }

    private void DisableBtn()
    {
        isActivate = false;
        Button[] buttons = root.GetComponentsInChildren<Button>();
        foreach (var button in buttons)
        {
            button.interactable = false;
        }
        root.Find("Return").GetComponent<Button>().enabled = false;
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Select Location" && SceneManager.sceneCount == 1)
        {
            if (!isActivate)
            {
                if (!root.Find("ConfirmImage"))
                {
                    Button[] buttons = root.GetComponentsInChildren<Button>();
                    foreach (var button in buttons)
                    {
                        button.interactable = true;
                    }
                    isActivate = true;
                }
                root.Find("Return").GetComponent<Button>().enabled = true;
            }
        }

    }
}
