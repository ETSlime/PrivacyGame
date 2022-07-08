using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class PageInit : MonoBehaviour
{
    // canvas
    private Transform root;
    private bool isActivate;
    

    private void Start()
    {
        isActivate = true;

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

        this.gameObject.AddComponent<AudioSource>();
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>("SE/Btn_SE4");
        
        // add listener for each btn
        root.GetChild(1).Find("store").GetComponent<GeneralIconButton>().onClick.AddListener(()=>
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
        root.GetChild(1).Find("library").GetComponent<GeneralIconButton>().onClick.AddListener(() => 
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
        root.GetChild(1).Find("home").GetComponent<GeneralIconButton>().onClick.AddListener(() => 
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
        root.GetChild(1).Find("friend's home").GetComponent<GeneralIconButton>().onClick.AddListener(() => 
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
        root.GetChild(1).Find("work").GetComponent<GeneralIconButton>().onClick.AddListener(() => 
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
        root.GetChild(1).Find("restroom").GetComponent<GeneralIconButton>().onClick.AddListener(() => 
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
