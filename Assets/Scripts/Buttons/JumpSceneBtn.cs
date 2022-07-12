using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class JumpSceneBtn : GeneralIconButton
{
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        Transform image = this.transform.parent.parent;
        if (!this.GetComponent<AudioSource>()) this.gameObject.AddComponent<AudioSource>();
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>("SE/Btn_SE");
        audio.playOnAwake = false;
        audio.Play();
        bool finished = image.Find("ChatFrame").Find("Text_Base").GetComponent<TextCtrl>().finished;
        if (!finished)
        {
            string content;
            switch (this.name.Substring(0, 1))
            {
                case "R":
                    content = "Do you want to jump to the next scene?";
                    if (!this.transform.parent.Find("ConfirmImage")) ConfirmationPanel.CreatePanel(this.transform.parent, content, JumpScene);
                    break;
                case "L":
                    content = "Do you want to return to the previous scene?";
                    if (!this.transform.parent.Find("ConfirmImage")) ConfirmationPanel.CreatePanel(this.transform.parent, content, JumpScene);
                    break;
                case "B":
                    content = "Do you want to skip this scene and return to the location selection stage?";
                    int[] imageSize = { 750, 300 };
                    int[] textSize = { 600, 150 };
                    if (!this.transform.parent.Find("ConfirmImage")) ConfirmationPanel.CreatePanel(this.transform.parent, content, JumpScene, imageSize, textSize);
                    break;
            }
        }
        else JumpScene();

    }
    public void JumpScene()
    {
        // canvas root
        Transform root = this.transform.parent.parent.parent;
        // current active scene
        Transform curImage = this.transform.parent.parent;
        // next scene
        GameObject imageGO;
        // enable next image
        switch (this.name)
        {
            case "BackArrow":
                imageGO = null;
                LoadGame.LoadScene("Select Location");
                break;
            case "RightArrow_cs_1":
            case "RightArrow_lb_1":
            case "RightArrow_hm_1":
            case "RightArrow_fh_1":
            case "RightArrow_wk_1":
            case "RightArrow_pr_1":
                imageGO = root.Find("Image2").gameObject;
                imageGO.SetActive(true);
                break;
            case "LeftArrow_cs_2":
            case "LeftArrow_lb_2":
            case "LeftArrow_hm_2":
            case "LeftArrow_fh_2":
            case "LeftArrow_wk_2":
            case "LeftArrow_pr_2":
                imageGO = root.Find("Image1").gameObject;
                imageGO.SetActive(true);
                break;
            case "RightArrow_cs_2":
            case "RightArrow_lb_2":
            case "RightArrow_wk_2":
            case "RightArrow_pr_2":
                imageGO = root.Find("Image3").gameObject;
                imageGO.SetActive(true);
                break;
            case "LeftArrow_cs_3":
            case "LeftArrow_lb_3":
            case "LeftArrow_wk_3":
            case "LeftArrow_pr_3":
                imageGO = root.Find("Image2").gameObject;
                imageGO.SetActive(true);
                break;
            default:
                imageGO = null;
                break;

        }

        if (imageGO != null)
        {
            // disable current image
            curImage.gameObject.SetActive(false);
            Transform circleTF = imageGO.transform.Find("Circle");
            Transform pointerTF = imageGO.transform.Find("Pointer");
            Transform circleTF2 = imageGO.transform.Find("Circle2");
            Transform pointerTF2 = imageGO.transform.Find("Pointer2");
            Transform coinTF = imageGO.transform.Find("Coin");
            Transform tipsTF = imageGO.transform.Find("Tips");
            if (circleTF) circleTF.gameObject.SetActive(false);
            if (pointerTF) pointerTF.gameObject.SetActive(false);
            if (circleTF2) circleTF.gameObject.SetActive(false);
            if (pointerTF2) pointerTF.gameObject.SetActive(false);
            if (coinTF) coinTF.gameObject.SetActive(false);
            if (tipsTF) tipsTF.gameObject.SetActive(false);


            // destroy correct/wrong game object
            Transform nextChatframe = imageGO.transform.Find("ChatFrame");
            Text[] curTexts = nextChatframe.Find("Text_Base").GetComponentsInChildren<Text>();
            Transform tobeDestroyed;
            tobeDestroyed = curTexts[0].transform.Find("Correct");
            if (tobeDestroyed) GameObject.Destroy(tobeDestroyed.gameObject);
            tobeDestroyed = curTexts[0].transform.Find("Wrong");
            if (tobeDestroyed) GameObject.Destroy(tobeDestroyed.gameObject);
            // destroy confirm panel && warning text
            Transform curTips = curImage.Find("Tips");
            Transform confirmImage = curTips.Find("ConfirmImage");
            Transform warningText = curTips.Find("Warning Text");
            if (confirmImage) GameObject.Destroy(confirmImage.gameObject);
            if (warningText) GameObject.Destroy(warningText.gameObject);

            // disable backlog view
            Transform backlog = curImage.Find("ChatFrame").Find("Backlog View");
            if (backlog)
            {
                backlog.gameObject.SetActive(false);
                Transform content = backlog.GetChild(0).GetChild(0);
                Image[] texts = content.GetComponentsInChildren<Image>();
                foreach (Image text in texts)
                {
                    GameObject.Destroy(text.gameObject);
                }
                
                void delay()
                {
                    // clear backlog view content
                    Backlog.backlog = new List<string>();
                    // load next scene backlog
                    Backlog.backlog.Add(nextChatframe.Find("Text_Base").GetChild(0).GetComponent<TextCtrl>().str);
                }

                // 这里要做延迟是因为要等下一页的text能被读取出来
                Sequence seq = DOTween.Sequence();
                seq.AppendInterval(0.1f);
                seq.AppendCallback(delay);
            }
            
            // disable current text
            foreach (var curText in curTexts)
            {
                if (curText.gameObject.activeInHierarchy && curText.name != "Text_Base")
                {
                    // destroy child game object in current text
                    if (curText.transform.childCount > 0) GameObject.Destroy(curText.transform.GetChild(0).gameObject);
                    // disable current text
                    curText.gameObject.SetActive(false);
                }
            }
            // enable 1st text
            curTexts[0].transform.GetChild(0).gameObject.SetActive(true);

            // after jump, set finished to false
            curImage.Find("ChatFrame").Find("Text_Base").GetComponent<TextCtrl>().finished = false;

            // initialize checklist
            EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "None", "None", "None", "None");

            // save current info
            Save.SaveByJSON();
        }
    }
}
