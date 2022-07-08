using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
///
/// </summary>
public class Timer : MonoBehaviour
{
    private float time;
    private Slider slider;
    private Transform myTransform;

    public static bool stop;

    private void Start()
    {
        time = 120;
        stop = false;
        myTransform = this.transform;
        slider = myTransform.GetComponent<Slider>();
        InvokeRepeating("CountDown", 0, 1.0f);
    }

    private void CountDown()
    {
        if (!stop) slider.value -= 1f / time * GlobalDef.TIMESLICE;
        if (slider.value <= 0)
        {
            if (GamePanel.m_totalScore >= Player.points) 
                Player.points = GamePanel.m_totalScore;
            
            // destroy confirmImage
            Transform confirmImage = myTransform.parent.parent.Find("confirmImage");
            if (confirmImage) GameObject.Destroy(confirmImage.gameObject);
            // disable btn
            myTransform.parent.Find("HomeButton").GetComponent<GeneralIconButton>().enabled = false;
            myTransform.parent.Find("Pause").GetComponent<GeneralIconButton>().enabled = false;
            EventDispatcher.instance.UnRegistALL(EventDef.EVENT_FRUIT_SELECTED);
            Sequence seq = DOTween.Sequence();
            seq.AppendInterval(0.8f);
            seq.AppendCallback(CreatePanel);
            CancelInvoke("CountDown");
        }
        
    }

    private void CreatePanel()
    {
        GameObject PanelGO = new GameObject("Panel");
        GameObject PanelTextGO = new GameObject("PanelText");
        GameObject ReturnBtnGO = new GameObject("ReturnBtn");
        GameObject PlayBtnGO = new GameObject("PlayBtn");
        GameObject ReturnTextGO = new GameObject("ReturnText");
        GameObject PlayTextGO = new GameObject("PlayText");

        PanelGO.transform.SetParent(myTransform);
        PanelTextGO.transform.SetParent(PanelGO.transform);
        ReturnBtnGO.transform.SetParent(PanelGO.transform);
        PlayBtnGO.transform.SetParent(PanelGO.transform);
        ReturnTextGO.transform.SetParent(ReturnBtnGO.transform);
        PlayTextGO.transform.SetParent(PlayBtnGO.transform);

        Image Panel = PanelGO.AddComponent<Image>();
        Panel.sprite = Resources.Load<Sprite>("Sprite/CardFrame02,03_BackFrame_d");
        RectTransform PaneleRTF = PanelGO.GetComponent<RectTransform>();

        PaneleRTF.anchoredPosition = new Vector3(0, 450, 0);
        PaneleRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1000);
        PaneleRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 400);

        Text PanelText = PanelTextGO.AddComponent<Text>();
        PanelText.text = "Time's up! Your  score is: " + "<color=red><size=55>"+ GamePanel.m_totalScore + "</size></color>" +
            ". Do you want to play again?";
        PanelText.font = Resources.Load<Font>("Fonts/Quicksand-Bold");
        PanelText.fontSize = 50;
        PanelText.color = Color.black;
        RectTransform PanelTextRTF = PanelText.GetComponent<RectTransform>();
        PanelTextRTF.anchoredPosition = new Vector3(9, 54, 0);
        PanelTextRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 800);
        PanelTextRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 200);

        ReturnBtnGO.AddComponent<MyButton>();
        ReturnBtnGO.AddComponent<Image>();
        ReturnBtnGO.AddComponent<AudioSource>();

        PlayBtnGO.AddComponent<MyButton>();
        PlayBtnGO.AddComponent<Image>();
        PlayBtnGO.AddComponent<AudioSource>();

        ReturnBtnGO.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/warning");
        ReturnBtnGO.GetComponent<AudioSource>().playOnAwake = false;
        ReturnBtnGO.GetComponent<Image>().sprite = Resources.Load<Sprite>("Frame_Custom/TabMenuFrame_White");
        ReturnBtnGO.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200);
        ReturnBtnGO.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
        ReturnBtnGO.GetComponent<Image>().type = Image.Type.Sliced;

        PlayBtnGO.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/Btn_SE");
        PlayBtnGO.GetComponent<AudioSource>().playOnAwake = false;
        PlayBtnGO.GetComponent<Image>().sprite = Resources.Load<Sprite>("Frame_Custom/TabMenuFrame_White");
        PlayBtnGO.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200);
        PlayBtnGO.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
        PlayBtnGO.GetComponent<Image>().type = Image.Type.Sliced;

        Text ReturnText = ReturnTextGO.AddComponent<Text>();
        Text PlayText = PlayTextGO.AddComponent<Text>();
        ReturnText.text = "Exit the mini-game";
        ReturnText.color = Color.black;
        ReturnText.font = Resources.Load<Font>("Fonts/Quicksand-Bold");
        ReturnText.fontSize = 30;
        ReturnText.alignment = TextAnchor.MiddleCenter;
        ReturnTextGO.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200);
        ReturnTextGO.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
        ReturnBtnGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(-220, -90);
        PlayText.text = "Play again";
        PlayText.color = Color.black;
        PlayText.font = Resources.Load<Font>("Fonts/Quicksand-Bold");
        PlayText.fontSize = 30;
        PlayText.alignment = TextAnchor.MiddleCenter;
        PlayTextGO.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200);
        PlayTextGO.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
        PlayBtnGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(220, -90);

        PlayBtnGO.GetComponent<MyButton>().onClick.AddListener(() =>
        {
            Save.SaveByJSON();
            LoadGame.LoadScene("Mini Game");
        });
        ReturnBtnGO.GetComponent<MyButton>().onClick.AddListener(() =>
        {
            Save.SaveByJSON();
            LoadGame.LoadScene("Select Location");
        });
    }
}
