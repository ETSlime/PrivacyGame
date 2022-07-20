using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
using DG.Tweening;

/// <summary>
///
/// </summary>
public class SaveSlot : MonoBehaviour
{
    // is the save slot button activate
    private bool isActivate;
    private Transform root;
    private void Start()
    {
        // delete children first, if exist
        Image[] texts = this.GetComponentsInChildren<Image>();
        foreach (Image text in texts)
        {
            GameObject.Destroy(text.gameObject);
        }
        // initialize
        if (Directory.Exists(Application.dataPath + "/Save/"))
        {
            List<string> userList = Save.GetUserName();
            if (userList != null) Init(userList);
        }

    }
    public void Init(List<string> userList)
    {
        // find the scrollView transform
        root = this.transform.parent.parent;
        isActivate = true;

        int count = 0;
        foreach (var name in userList)
        {
            count++;
            CreateSaveBtn(name);
        }
        if (count < 3)
        {
            for (; count < 3; count++)
            {
                CreateSaveBtn("Empty");
            }
        }
        RectTransform contentRTF = this.GetComponent<RectTransform>();
        // sizeDelta = (n-1)*(Spacing X+CellSize X)
        float bottom = 50;
        float size = (count - 0) * (50 + 200) + bottom;
        contentRTF.sizeDelta = new Vector2(0, size);
    }
    private void CreateSaveBtn(string userName)
    {
        PlayerInfo playerInfo = new PlayerInfo();
        if (userName != "Empty")
        {
            playerInfo = Save.LoadByJSON(userName);
        }
        
        // btn component
        GameObject slot = new GameObject(userName);
        slot.AddComponent<MyButton>();
        slot.AddComponent<Image>();
        slot.AddComponent<AudioSource>();
        slot.transform.SetParent(this.transform);

        // text component
        GameObject text = new GameObject("Text");
        text.AddComponent<Text>();
        text.transform.SetParent(slot.transform);

        // rtf
        RectTransform btnRTF = slot.GetComponent<RectTransform>();
        btnRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1123);
        btnRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 200);
        // audio
        AudioSource audio = slot.GetComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>("SE/Btn_SE");
        audio.playOnAwake = false;

        Button btn = slot.GetComponent<MyButton>();



        // lambda expression
        btn.onClick.AddListener(() => 
        {
            audio.Play();

            if (userName != "Empty")
            {
                isActivate = false;

                // disable close btn
                root.Find("CloseBtn").GetComponent<Button>().interactable = false;
                // disable saveslot btn
                MyButton[] buttons = root.GetChild(0).GetChild(0).GetComponentsInChildren<MyButton>();
                foreach (var button in buttons)
                {
                    button.enabled = false;
                }
                string content = "Do you want to load this data?";

                void load()
                {
                    LoadGame.LoadScene(3);
                }

                if (!root.Find("ConfirmImage")) ConfirmationPanel.CreatePanel(root, content, load);

                // load save data
                Save.LoadData(playerInfo);
            }

        } );

        // set text
        Text btnText = text.GetComponent<Text>();
        if (userName == "Empty")
        {
            btnText.text = "Empty Data";
            btnText.color = Color.black;
            btnText.fontSize = 45;
            btnText.font = Resources.Load<Font>("Fonts/Electronic Highway Sign");
            RectTransform textRTF = text.GetComponent<RectTransform>();
            textRTF.anchorMin = new Vector2(0, 0);
            textRTF.anchorMax = new Vector2(1, 1);
            // new Vector2(left, bottom)
            textRTF.offsetMin = new Vector2(443, -347);
            // new Vector2(-right, -top)
            textRTF.offsetMax = new Vector2(-397, -77);
        }
        else
        {
            btnText.text = "Name: " + playerInfo.userName;
            btnText.color = Color.black;
            btnText.fontSize = 50;
            btnText.font = Resources.Load<Font>("Fonts/Electronic Highway Sign");
            RectTransform textRTF = text.GetComponent<RectTransform>();

            //��ʹ�� transform.position.Set(x, y, z);ʱ����ʵ���positionֻ�ǵ�����transform��get������
            //�õ���һ��transform��ļ�¼λ�õ�Vector3˽�г�Ա����ʱ�����������������ӵ�integer����
            //Ȼ���ٶ����Vector3�ĸ���ִ��Set�����Բ�����ĵ�transform����ʵ��˽�г�Ա��
            //����ʹ��transform.position = new Vector3(x, y, z);ʱ��
            //C#������Ҫ��transform��˽�г�Ա�����޸ģ����Զ�����set�����������set���������޸�transform��˽�г�Ա�ġ�
            textRTF.position = new Vector3(90, -124, 0);
            textRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 500);
            textRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 300);

            // score text
            GameObject score = new GameObject("Score");
            score.AddComponent<Text>();
            score.transform.SetParent(slot.transform);
            Text scoreText = score.GetComponent<Text>();
            scoreText.text = "Current Points: " + playerInfo.points;
            scoreText.color = Color.black;
            scoreText.fontSize = 25;
            scoreText.font = Resources.Load<Font>("Fonts/Electronic Highway Sign");
            scoreText.alignment = TextAnchor.MiddleRight;
            RectTransform scoreRTF = scoreText.GetComponent<RectTransform>();
            scoreRTF.position = new Vector3(365, -57, 0);
            scoreRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350);
            scoreRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 80);

            // coin text
            GameObject answer = new GameObject("Answer");
            answer.AddComponent<Text>();
            answer.transform.SetParent(slot.transform);
            Text answerText = answer.GetComponent<Text>();
            answerText.text = "correct answer: " + playerInfo.correct;
            answerText.color = Color.black;
            answerText.fontSize = 25;
            answerText.font = Resources.Load<Font>("Fonts/Electronic Highway Sign");
            answerText.alignment = TextAnchor.MiddleRight;
            RectTransform answerRTF = answerText.GetComponent<RectTransform>();
            answerRTF.position = new Vector3(390, 61, 0);
            answerRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300);
            answerRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 80);

            // test text
            GameObject test = new GameObject("TestFinish");
            test.AddComponent<Text>();
            test.transform.SetParent(slot.transform);
            Text testText = test.GetComponent<Text>();
            if (playerInfo.finished)
                testText.text = "Finish test: " + "<color=red>" + playerInfo.finished + "</color>";
            else
                testText.text = "Finish test: " + playerInfo.finished;
            testText.color = Color.black;
            testText.fontSize = 25;
            testText.font = Resources.Load<Font>("Fonts/Electronic Highway Sign");
            RectTransform testRTF = testText.GetComponent<RectTransform>();
            testRTF.position = new Vector3(-350, 51, 0);
            testRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 320);
            testRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 50);

            // create delete save btn
            GameObject deleteSave = new GameObject("DeleteBtn");
            deleteSave.transform.SetParent(slot.transform);
            deleteSave.AddComponent<MyButton>();
            deleteSave.AddComponent<Image>();
            deleteSave.AddComponent<AudioSource>();
            deleteSave.GetComponent<MyButton>().onClick.AddListener(() =>
            {
                audio.Play();

                isActivate = false;
                // disable close btn
                root.Find("CloseBtn").GetComponent<Button>().interactable = false;
                // disable saveslot btn
                MyButton[] buttons = root.GetChild(0).GetChild(0).GetComponentsInChildren<MyButton>();
                foreach (var button in buttons)
                {
                    button.enabled = false;
                }

                void delete()
                {
                    Save.deleteSave(playerInfo.userName);
                    root.Find("CloseBtn").GetComponent<BtnBehavior>().CloseSaveSlot();

                    void delay()
                    {
                        root.parent.Find("Buttons").Find("Continue").GetComponent<BtnBehavior>().ContinueGame();
                    }
                    Sequence seq = DOTween.Sequence();
                    seq.AppendInterval(0);
                    seq.AppendCallback(delay);

                    // enable close btn
                    root.Find("CloseBtn").GetComponent<Button>().interactable = true;
                }

                string content = "Do you want to delete this save file: <color=red>" + playerInfo.userName + "</color>?";
                if (!root.Find("ConfirmImage")) ConfirmationPanel.CreatePanel(root, content, delete);


            });

            // text component
            GameObject deleteText = new GameObject("Text");
            deleteText.AddComponent<Text>();
            deleteText.transform.SetParent(deleteSave.transform);
            deleteText.GetComponent<Text>().text = "Delete";
            deleteText.GetComponent<Text>().color = Color.red;
            deleteText.GetComponent<Text>().fontSize = 30;
            deleteText.GetComponent<Text>().font = Resources.Load<Font>("Fonts/Quicksand-Bold");
            deleteText.GetComponent<RectTransform>().anchoredPosition = new Vector2(7, -28);
            deleteSave.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button_Custom/Btn_Rectangle03_White2");
            deleteSave.GetComponent<Image>().type = Image.Type.Sliced;
            deleteSave.GetComponent<RectTransform>().anchoredPosition = new Vector2(-428, -34);
            // rtf
            deleteSave.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
            deleteSave.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
            // audio
            deleteSave.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/Btn_SE");
            deleteSave.GetComponent<AudioSource>().playOnAwake = false;
        }

        // set btn image
        Image image = slot.GetComponent<Image>();
        image.sprite = Resources.Load<Sprite>("Button_Demo_Common/Btn_MenuButton_Rectangle03_Blue");
        image.type = Image.Type.Sliced;
    }



    public void Update()
    {
        if (!isActivate)
        {
            if(!root.Find("ConfirmImage"))
            {
                // enable close btn
                root.Find("CloseBtn").GetComponent<Button>().interactable = true;
                // enable saveslot btn
                MyButton[] buttons = root.GetChild(0).GetChild(0).GetComponentsInChildren<MyButton>();
                foreach (var button in buttons)
                {
                    button.enabled = true;
                }
            }
        }
    }
}
