using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


/// <summary>
///
/// </summary>
public class BtnBehavior : MonoBehaviour
{
    public void CloseSaveSlot()
    {
        Transform content = this.transform.parent.GetChild(0).GetChild(0);
        MyButton[] buttons = content.GetComponentsInChildren<MyButton>();
        foreach (MyButton button in buttons)
        {
            GameObject.Destroy(button.gameObject);
        }

        // 调亮背景
        Image[] images = this.transform.parent.parent.Find("Buttons").GetComponentsInChildren<Image>();
        foreach (var image in images)
        {
            image.color = new Vector4(116f / 255f, 203f / 255f, 243f / 255f, 1);
        }
        this.transform.parent.parent.Find("Image").GetComponent<Image>().color = Color.white;
        GameObject closeObject = this.transform.parent.gameObject;
        closeObject.SetActive(false);
    }

    public void ContinueGame()
    {
        // 调暗背景
        Image[] images = this.transform.parent.GetComponentsInChildren<Image>();
        foreach (var image in images)
        {
            image.color = image.color * new Vector4(1, 1, 1, 100f / 255f);
        }
        this.transform.parent.parent.Find("Image").GetComponent<Image>().color = new Vector4(1, 1, 1, 60f / 255f);
        GameObject scrollView = this.transform.parent.parent.gameObject.transform.Find("Scroll View").gameObject;
        scrollView.SetActive(true);
        // get scroll view content
        void delay()
        {
            Transform content = scrollView.transform.GetChild(0).GetChild(0);
            if (content.childCount == 0)
            {
                List<string> userList = Save.GetUserName();
                content.GetComponent<SaveSlot>().Init(userList);
            }
        }

        // 用dotween不用invoke做延迟的原因是，invoke只能在start或者update里调用
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(0);
        seq.AppendCallback(delay);
    }

    public void CloseView()
    {
        Transform content;
        if (this.name == "CloseBtn")
        {
            this.transform.parent.gameObject.SetActive(false);
            content = this.transform.parent.GetChild(0).GetChild(0);
        }
        else 
        {
            this.transform.parent.Find("Backlog View").gameObject.SetActive(false);
            content = this.transform.parent.Find("Backlog View").GetChild(0).GetChild(0);
        }
        Image[] texts = content.GetComponentsInChildren<Image>();
        foreach (Image text in texts)
        {
            GameObject.Destroy(text.gameObject);
        }

        
    }

    public void Backlog()
    {
        GameObject backlog = this.transform.parent.Find("Backlog View").gameObject;
        if (backlog.activeInHierarchy) CloseView();
        else
        {
            void delay()
            {
                Transform content = backlog.transform.GetChild(0).GetChild(0);
                if (content.childCount == 0)
                {
                    this.GetComponent<Backlog>().Init();
                }
            }

            // 延迟0.1秒是为了先让backlog的start先运行，再运行init
            Sequence seq = DOTween.Sequence();
            seq.AppendInterval(0.1f);
            seq.AppendCallback(delay);
            backlog.gameObject.SetActive(true);
        }
    }

    public void UpBtn()
    {
        this.transform.parent.Find("LeftUpBtn").gameObject.SetActive(false);
        this.transform.parent.Find("RightUpBtn").gameObject.SetActive(false);
        Transform leftDownBtn = this.transform.parent.Find("LeftDownBtn");
        Transform rightDownBtn = this.transform.parent.Find("RightDownBtn");
        // get new position
        Vector3 leftPos = new Vector3(leftDownBtn.localPosition.x, leftDownBtn.localPosition.y + 400, 0);
        Vector3 rightPos = new Vector3(rightDownBtn.localPosition.x, rightDownBtn.localPosition.y + 400, 0);
        leftDownBtn.DOLocalMove(leftPos, 1.5f);
        rightDownBtn.DOLocalMove(rightPos, 1.5f);
        this.transform.parent.parent.Find("ChatFrame").Find("Checklist").DOLocalMove(new Vector3(-800, 0, 0), 1.5f);

        void delay()
        {
            // enable down btn
            leftDownBtn.GetComponent<GeneralIconButton>().interactable = true;
            rightDownBtn.GetComponent<GeneralIconButton>().interactable = true;
        }

        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(1.3f);
        seq.AppendCallback(delay);
    }

    public void DownBtn()
    {
        Transform leftDownBtn = this.transform.parent.Find("LeftDownBtn");
        Transform rightDownBtn = this.transform.parent.Find("RightDownBtn");
        // disable down btn
        leftDownBtn.GetComponent<GeneralIconButton>().interactable = false;
        rightDownBtn.GetComponent<GeneralIconButton>().interactable = false;
        // get new position
        Vector3 leftPos = new Vector3(leftDownBtn.localPosition.x, leftDownBtn.localPosition.y - 400, 0);
        Vector3 rightPos = new Vector3(rightDownBtn.localPosition.x, rightDownBtn.localPosition.y - 400, 0);
        leftDownBtn.DOLocalMove(leftPos, 1.5f);
        rightDownBtn.DOLocalMove(rightPos, 1.5f);
        this.transform.parent.parent.Find("ChatFrame").Find("Checklist").DOLocalMove(new Vector3(-800, -400, 0), 1.5f);

        void delay()
        {
            this.transform.parent.Find("LeftUpBtn").gameObject.SetActive(true);
            this.transform.parent.Find("RightUpBtn").gameObject.SetActive(true);
        }

        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(1.3f);
        seq.AppendCallback(delay);
    }

    public void game()
    {
        LoadGame.LoadScene("Game");
    }


}
