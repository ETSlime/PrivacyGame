using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TextCtrl : MonoBehaviour, IPointerClickHandler
{
    public GameObject TextPrefab;

    public string str;
    private Text tex;
    private int max_speed;
    private int speed;
    private int index = 0;
    private string str1 = "";
    private bool ison = true;

    private bool answerCorrect;

    private enum TextAttribute 
    {
        Default = 0,
        Text1 = 1,
        Text2 = 2,
        Text3 = 3,
        Text4 = 4,
        StageSelection = -1,
        cs_1_1_1 = 5,
        cs_1_1_2 = 6,
        cs_1_1_3 = 7,
        cs_1_1_4 = 8,
        cs_1_2_1 = 9,
        cs_1_2_2 = 10,
        cs_1_3_1 = 11,
        cs_1_3_2 = 12,
        cs_1_3_3 = 13,
        cs_1_4_1 = 14,
        cs_1_4_2 = 15,
        cs_1_4_3 = 16,
        cs_1_5_1 = 17,
        cs_1_5_2 = 18,
        cs_2_1_1 = 19,
        cs_2_1_2 = 20,
        cs_2_1_3 = 21,
        cs_2_1_4 = 22,
        cs_2_1_5 = 23,
        cs_2_1_6 = 24,
        cs_2_1_7 = 25,
        cs_2_2_1 = 26,
        cs_2_2_2 = 27,
        cs_2_3_1 = 28,
        cs_2_3_2 = 29,
        cs_2_4_1 = 30,
        cs_2_4_2 = 31,
        cs_2_4_3 = 32,
        cs_2_5_1 = 33,
        cs_2_5_2 = 34,
        cs_3_1_1 = 35,
        cs_3_1_2 = 36,
        cs_3_1_3 = 37,
        cs_3_1_4 = 38,
        cs_3_2_1 = 39,
        cs_3_2_2 = 40,
        cs_3_3_1 = 41,
        cs_3_3_2 = 42,
        cs_3_3_3 = 43,
        cs_3_4_1 = 44,
        cs_3_4_2 = 45,
        cs_3_4_3 = 46,
        cs_3_4_4 = 47,
        cs_3_4_5 = 48,
        cs_3_4_6 = 49,
        cs_3_5_1 = 50,
        cs_3_5_2 = 51,
        cs_3_5_3 = 52,
        lb_1_1_1 = 53,
        lb_1_1_2 = 54,
        lb_1_1_3 = 55,
        lb_1_1_4 = 56,
        lb_1_2_1 = 57,
        lb_1_2_2 = 58,
        lb_1_3_1 = 59,
        lb_1_3_2 = 60,
        lb_1_3_3 = 61,
        lb_1_4_1 = 62,
        lb_1_4_2 = 63,
        lb_1_4_3 = 64,
        lb_1_5_1 = 65,
        lb_1_5_2 = 66,
        lb_2_1_1 = 67,
        lb_2_1_2 = 68,
        lb_2_1_3 = 69,
        lb_2_1_4 = 70,
        lb_2_2_1 = 71,
        lb_2_2_2 = 72,
        lb_2_3_1 = 73,
        lb_2_3_2 = 74,
        lb_2_3_3 = 75,
        lb_2_3_4 = 76,
        lb_2_3_5 = 77,
        lb_2_3_6 = 78,
        lb_2_4_1 = 79,
        lb_2_4_2 = 80,
        lb_2_5_1 = 81,
        lb_2_5_2 = 82,
        lb_3_1_1 = 83,
        lb_3_1_2 = 84,
        lb_3_1_3 = 85,
        lb_3_1_4 = 86,
        lb_3_2_1 = 87,
        lb_3_2_2 = 88,
        lb_3_3_1 = 89,
        lb_3_3_2 = 90,
        lb_3_3_3 = 91,
        lb_3_3_4 = 92,
        lb_3_3_5 = 93,
        lb_3_3_6 = 94,
        lb_3_4_1 = 95,
        lb_3_4_2 = 96,
        lb_3_5_1 = 97,
        lb_3_5_2 = 98,
        lb_2_3_7 = 99,
        hm_1_1_1 = 100,
        hm_1_1_2 = 101,
        hm_1_1_3 = 102,
        hm_1_1_4 = 103,
        hm_1_1_5 = 104,
        hm_1_1_6 = 105,
        hm_1_1_7 = 106,
        hm_1_2_1 = 107,
        hm_1_2_2 = 108,
        hm_1_3_1 = 109,
        hm_1_3_2 = 110,
        hm_1_4_1 = 111,
        hm_1_4_2 = 112,
        hm_1_4_3 = 113,
        hm_1_4_4 = 114,
        hm_1_4_5 = 115,
        hm_1_4_6 = 116,
        hm_1_5_1 = 117,
        hm_1_5_2 = 118,
        hm_2_1_1 = 119,
        hm_2_1_2 = 120,
        hm_2_1_3 = 121,
        hm_2_1_4 = 122,
        hm_2_2_1 = 123,
        hm_2_2_2 = 124,
        hm_2_3_1 = 125,
        hm_2_3_2 = 126,
        hm_2_3_3 = 127,
        fh_1_1_1 = 128,
        fh_1_1_2 = 129,
        fh_1_1_3 = 130,
        fh_1_1_4 = 131,
        fh_1_2_1 = 132,
        fh_1_2_2 = 133,
        fh_1_3_1 = 134,
        fh_1_3_2 = 135,
        fh_1_3_3 = 136,
        fh_1_3_4 = 137,
        fh_1_4_1 = 138,
        fh_1_4_2 = 139,
        fh_2_1_1 = 140,
        fh_2_1_2 = 141,
        fh_2_1_3 = 142,
        fh_2_1_4 = 143,
        fh_2_1_5 = 144,
        fh_2_1_6 = 145,
        fh_2_1_7 = 146,
        fh_2_1_8 = 147,
        fh_2_2_1 = 148,
        fh_2_2_2 = 149,
        fh_2_2_3 = 150,
        fh_2_3_1 = 151,
        fh_2_3_2 = 152,
        wk_1_1_1 = 153,
        wk_1_1_2 = 154,
        wk_1_1_3 = 155,
        wk_1_1_4 = 156,
        wk_1_1_5 = 157,
        wk_1_2_1 = 158,
        wk_1_2_2 = 159,
        wk_1_3_1 = 160,
        wk_1_3_2 = 161,
        wk_1_3_3 = 162,
        wk_1_3_4 = 163,
        wk_1_4_1 = 164,
        wk_1_4_2 = 165,
        wk_1_5_1 = 166,
        wk_1_5_2 = 167,
        wk_1_5_3 = 168,
        wk_2_1_1 = 169,
        wk_2_1_2 = 170,
        wk_2_1_3 = 171,
        wk_2_1_4 = 172,
        wk_2_2_1 = 173,
        wk_2_2_2 = 174,
        wk_2_3_1 = 175,
        wk_2_3_2 = 176,
        wk_2_3_3 = 177,
        wk_2_4_1 = 178,
        wk_2_4_2 = 179,
        wk_2_4_3 = 180,
        wk_2_4_4 = 181,
        wk_2_4_5 = 182,
        wk_2_4_6 = 183,
        wk_2_4_7 = 184,
        wk_2_5_1 = 185,
        wk_2_5_2 = 186,
        wk_3_1_1 = 187,
        wk_3_1_2 = 188,
        wk_3_1_3 = 189,
        wk_3_1_4 = 190,
        wk_3_2_1 = 191,
        wk_3_2_2 = 192,
        wk_3_2_3 = 193,
        wk_3_3_1 = 194,
        wk_3_3_2 = 195,
        wk_3_4_1 = 196,
        wk_3_4_2 = 197,
        wk_3_4_3 = 198,
        wk_3_4_4 = 199,
        wk_3_4_5 = 200,
        wk_3_4_6 = 201,
        wk_3_4_7 = 202,
        wk_3_5_1 = 203,
        wk_3_5_2 = 204,
        lb_1_1_6 = 205,
        lb_1_1_5 = 206,
        lb_1_1_7 = 207,
        lb_1_4_4 = 208,
        pr_1_1_1 = 209,
        pr_1_1_2 = 210,
        pr_1_1_3 = 211,
        pr_1_1_4 = 212,
        pr_1_2_1 = 213,
        pr_1_2_2 = 214,
        pr_1_2_3 = 215,
        pr_1_3_1 = 216,
        pr_1_3_2 = 217,
        pr_1_3_3 = 218,
        pr_1_4_1 = 219,
        pr_1_4_2 = 220,
        pr_1_4_3 = 221,
        pr_1_5_1 = 222,
        pr_1_5_2 = 223,
        pr_2_1_1 = 224,
        pr_2_1_2 = 225,
        pr_2_1_3 = 226,
        pr_2_1_4 = 227,
        pr_2_2_1 = 228,
        pr_2_2_2 = 229,
        pr_2_3_1 = 230,
        pr_2_3_2 = 231,
        pr_2_3_3 = 232,
        pr_2_4_1 = 233,
        pr_2_4_2 = 234,
        pr_2_4_3 = 235,
        pr_2_5_1 = 236,
        pr_2_5_2 = 237,
        pr_3_1_1 = 238,
        pr_3_1_2 = 239,
        pr_3_1_3 = 240,
        pr_3_1_4 = 241,
        pr_3_2_1 = 242,
        pr_3_2_2 = 243,
        pr_3_3_1 = 244,
        pr_3_3_2 = 245,
        pr_3_3_3 = 246,
        pr_3_4_1 = 247,
        pr_3_4_2 = 248,
        pr_3_4_3 = 249,
        pr_3_5_1 = 250,
        pr_3_5_2 = 251,
        cs_1_5_3 = 252,
        hm_2_2_3 = 253,
    }
    // text base root
    private GameObject root;
    [SerializeField]
    private GameObject curText;
    private Transform nextTextTF;
    [SerializeField]
    private TextAttribute curTextIndex;

    public bool finished;

    // Start is called before the first frame update
    private void Start()
    {
        finished = false;

        curTextIndex = TextAttribute.Default;
        root = GameObject.Find("Text_Base");
        curText = root.GetComponentsInChildren<Text>()[1].gameObject;
        tex = this.GetComponent<Text>();

        // if tex is not null
        if (tex)
        {
            str = tex.text;
            tex.text = "";
        }
        max_speed = 4;
        speed = 4;
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (ison)
        {
            speed -= 1;
            if (speed <= 0 && str != null)
            {
                if (index >= str.Length)
                {
                    ison = false;
                    // determine text attribute
                    
                    switch (this.name)
                    {
                        // input field component
                        case "Text1":
                            curTextIndex = TextAttribute.Text1;
                            MainText(curTextIndex);
                            break;
                        case "Text2":
                            curTextIndex = TextAttribute.Text2;
                            break;
                        case "Text3":
                            curTextIndex = TextAttribute.Text3;
                            break;
                        case "StageSelection":
                            curTextIndex = TextAttribute.StageSelection;
                            break;
                        case "cs_1.1.1":
                            curTextIndex = TextAttribute.cs_1_1_1;
                            break;
                        case "cs_1.1.2":
                            curTextIndex = TextAttribute.cs_1_1_2;
                            break;
                        case "cs_1.3.1":
                            curTextIndex = TextAttribute.cs_1_3_1;
                            break;
                        case "cs_1.4.1":
                            curTextIndex = TextAttribute.cs_1_4_1;
                            break;
                        case "cs_1.5.1":
                            curTextIndex = TextAttribute.cs_1_5_1;
                            break;
                        case "cs_2.1.1":
                            curTextIndex = TextAttribute.cs_2_1_1;
                            break;
                        case "cs_2.1.3":
                            curTextIndex = TextAttribute.cs_2_1_3;
                            break;
                        case "cs_2.1.4":
                            curTextIndex = TextAttribute.cs_2_1_4;
                            break;
                        case "cs_2.1.5":
                            curTextIndex = TextAttribute.cs_2_1_5;
                            break;
                        case "cs_2.3.2":
                            curTextIndex = TextAttribute.cs_2_3_2;
                            break;
                        case "cs_2.4.1":
                            curTextIndex = TextAttribute.cs_2_4_1;
                            break;
                        case "cs_3.1.1":
                            curTextIndex = TextAttribute.cs_3_1_1;
                            break;
                        case "cs_3.1.2":
                            curTextIndex = TextAttribute.cs_3_1_2;
                            break;
                        case "cs_3.3.1":
                            curTextIndex = TextAttribute.cs_3_3_1;
                            break;
                        case "cs_3.4.1":
                            curTextIndex = TextAttribute.cs_3_4_1;
                            break;
                        case "cs_3.4.3":
                            curTextIndex = TextAttribute.cs_3_4_3;
                            break;
                        case "cs_3.4.4":
                            curTextIndex = TextAttribute.cs_3_4_4;
                            break;
                        case "cs_3.5.1":
                            curTextIndex = TextAttribute.cs_3_5_1;
                            break;
                        case "lb_1.1.1":
                            curTextIndex = TextAttribute.lb_1_1_1;
                            break;
                        case "lb_1.1.2":
                            curTextIndex = TextAttribute.lb_1_1_2;
                            break;
                        case "lb_1.1.4":
                            curTextIndex = TextAttribute.lb_1_1_4;
                            break;
                        case "lb_1.1.5":
                            curTextIndex = TextAttribute.lb_1_1_5;
                            break;
                        case "lb_1.4.1":
                            curTextIndex = TextAttribute.lb_1_4_1;
                            break;
                        case "lb_1.4.2":
                            curTextIndex = TextAttribute.lb_1_4_2;
                            break;
                        case "lb_2.1.1":
                            curTextIndex = TextAttribute.lb_2_1_1;
                            break;
                        case "lb_2.1.2":
                            curTextIndex = TextAttribute.lb_2_1_2;
                            break;
                        case "lb_2.3.1":
                            curTextIndex = TextAttribute.lb_2_3_1;
                            break;
                        case "lb_2.3.2":
                            curTextIndex = TextAttribute.lb_2_3_2;
                            break;
                        case "lb_2.3.4":
                            curTextIndex = TextAttribute.lb_2_3_4;
                            break;
                        case "lb_2.3.5":
                            curTextIndex = TextAttribute.lb_2_3_5;
                            break;
                        case "lb_3.1.1":
                            curTextIndex = TextAttribute.lb_3_1_1;
                            break;
                        case "lb_3.1.2":
                            curTextIndex = TextAttribute.lb_3_1_2;
                            break;
                        case "lb_3.3.1":
                            curTextIndex = TextAttribute.lb_3_3_1;
                            break;
                        case "lb_3.3.3":
                            curTextIndex = TextAttribute.lb_3_3_3;
                            break;
                        case "lb_3.3.4":
                            curTextIndex = TextAttribute.lb_3_3_4;
                            break;
                        case "hm_1.1.1":
                            curTextIndex = TextAttribute.hm_1_1_1;
                            break;
                        case "hm_1.1.2":
                            curTextIndex = TextAttribute.hm_1_1_2;
                            break;
                        case "hm_1.1.4":
                            curTextIndex = TextAttribute.hm_1_1_4;
                            break;
                        case "hm_1.1.5":
                            curTextIndex = TextAttribute.hm_1_1_5;
                            break;
                        case "hm_1.4.1":
                            curTextIndex = TextAttribute.hm_1_4_1;
                            break;
                        case "hm_1.4.3":
                            curTextIndex = TextAttribute.hm_1_4_3;
                            break;
                        case "hm_1.4.4":
                            curTextIndex = TextAttribute.hm_1_4_4;
                            break;
                        case "hm_2.1.1":
                            curTextIndex = TextAttribute.hm_2_1_1;
                            break;
                        case "hm_2.1.2":
                            curTextIndex = TextAttribute.hm_2_1_2;
                            break;
                        case "hm_2.2.1":
                            curTextIndex = TextAttribute.hm_2_2_1;
                            break;
                        case "hm_2.3.1":
                            curTextIndex = TextAttribute.hm_2_3_1;
                            break;
                        case "fh_1.1.1":
                            curTextIndex = TextAttribute.fh_1_1_1;
                            break;
                        case "fh_1.1.2":
                            curTextIndex = TextAttribute.fh_1_1_2;
                            break;
                        case "fh_1.3.1":
                            curTextIndex = TextAttribute.fh_1_3_1;
                            break;
                        case "fh_1.3.2":
                            curTextIndex = TextAttribute.fh_1_3_2;
                            break;
                        case "fh_2.1.1":
                            curTextIndex = TextAttribute.fh_2_1_1;
                            break;
                        case "fh_2.1.2":
                            curTextIndex = TextAttribute.fh_2_1_2;
                            break;
                        case "fh_2.1.3":
                            curTextIndex = TextAttribute.fh_2_1_3;
                            break;
                        case "fh_2.1.5":
                            curTextIndex = TextAttribute.fh_2_1_5;
                            break;
                        case "fh_2.1.6":
                            curTextIndex = TextAttribute.fh_2_1_6;
                            break;
                        case "fh_2.2.1":
                            curTextIndex = TextAttribute.fh_2_2_1;
                            break;
                        case "wk_1.1.1":
                            curTextIndex = TextAttribute.wk_1_1_1;
                            break;
                        case "wk_1.1.2":
                            curTextIndex = TextAttribute.wk_1_1_2;
                            break;
                        case "wk_1.1.3":
                            curTextIndex = TextAttribute.wk_1_1_3;
                            break;
                        case "wk_1.3.1":
                            curTextIndex = TextAttribute.wk_1_3_1;
                            break;
                        case "wk_1.3.2":
                            curTextIndex = TextAttribute.wk_1_3_2;
                            break;
                        case "wk_1.5.1":
                            curTextIndex = TextAttribute.wk_1_5_1;
                            break;
                        case "wk_2.1.1":
                            curTextIndex = TextAttribute.wk_2_1_1;
                            break;
                        case "wk_2.1.2":
                            curTextIndex = TextAttribute.wk_2_1_2;
                            break;
                        case "wk_2.3.1":
                            curTextIndex = TextAttribute.wk_2_3_1;
                            break;
                        case "wk_2.4.1":
                            curTextIndex = TextAttribute.wk_2_4_1;
                            break;
                        case "wk_2.4.3":
                            curTextIndex = TextAttribute.wk_2_4_3;
                            break;
                        case "wk_2.4.4":
                            curTextIndex = TextAttribute.wk_2_4_4;
                            break;
                        case "wk_2.4.5":
                            curTextIndex = TextAttribute.wk_2_4_5;
                            break;
                        case "wk_3.1.1":
                            curTextIndex = TextAttribute.wk_3_1_1;
                            break;
                        case "wk_3.1.2":
                            curTextIndex = TextAttribute.wk_3_1_2;
                            break;
                        case "wk_3.2.1":
                            curTextIndex = TextAttribute.wk_3_2_1;
                            break;
                        case "wk_3.4.1":
                            curTextIndex = TextAttribute.wk_3_4_1;
                            break;
                        case "wk_3.4.2":
                            curTextIndex = TextAttribute.wk_3_4_2;
                            break;
                        case "wk_3.4.4":
                            curTextIndex = TextAttribute.wk_3_4_4;
                            break;
                        case "wk_3.4.5":
                            curTextIndex = TextAttribute.wk_3_4_5;
                            break;
                        case "pr_1.1.1":
                            curTextIndex = TextAttribute.pr_1_1_1;
                            break;
                        case "pr_1.1.2":
                            curTextIndex = TextAttribute.pr_1_1_2;
                            break;
                        case "pr_1.2.1":
                            curTextIndex = TextAttribute.pr_1_2_1;
                            break;
                        case "pr_1.3.1":
                            curTextIndex = TextAttribute.pr_1_3_1;
                            break;
                        case "pr_1.4.1":
                            curTextIndex = TextAttribute.pr_1_4_1;
                            break;
                        case "pr_2.1.1":
                            curTextIndex = TextAttribute.pr_2_1_1;
                            break;
                        case "pr_2.1.2":
                            curTextIndex = TextAttribute.pr_2_1_2;
                            break;
                        case "pr_2.3.1":
                            curTextIndex = TextAttribute.pr_2_3_1;
                            break;
                        case "pr_2.4.1":
                            curTextIndex = TextAttribute.pr_2_4_1;
                            break;
                        case "pr_3.1.1":
                            curTextIndex = TextAttribute.pr_3_1_1;
                            break;
                        case "pr_3.1.2":
                            curTextIndex = TextAttribute.pr_3_1_2;
                            break;
                        case "pr_3.3.1":
                            curTextIndex = TextAttribute.pr_3_3_1;
                            break;
                        case "pr_3.4.1":
                            curTextIndex = TextAttribute.pr_3_4_1;
                            break;
                    }
                    return;
                }
                str1 = str1 + str[index].ToString();
                tex.text = str1;
                index += 1;
                speed = max_speed;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Text[] temp = root.GetComponentsInChildren<Text>();
        if (temp.Length > 1) curText = temp[1].gameObject;
        else curText = temp[0].gameObject;
        //curText = root.GetComponentsInChildren<Text>()[1].gameObject;
        TextCtrl textCtrl = curText.GetComponent<TextCtrl>();
        
        if (textCtrl.ison)
        {
            textCtrl.SpeedUp();
        }
        
        MainText(textCtrl.curTextIndex);
    }

    public void SpeedUp()
    {
        // set maximum speed
        max_speed = 0;
    }

    private void InputName()
    {
        if (this.transform.Find("InputName"))
        {
            GameObject inputName = this.transform.Find("InputName").gameObject;
            inputName.SetActive(true);
            InputField inputField = inputName.GetComponent<InputField>();
            // add listener
            ison = false;
            inputField.onEndEdit.AddListener(InputEnd);
        }
    }


    private void InputEnd(string name)
    {
        List<string> userList = Save.GetUserName();
        if(userList.Contains(name))
        {
            WarningText("warning1");
        }
        else if(name.Length >= 10)
        {
            WarningText("warning2");
        }
        else if(name.Length <= 2)
        {
            WarningText("warning3");
        }
        else
        {
            if (this.transform.Find("warning1")) GameObject.Destroy(this.transform.Find("warning1").gameObject);
            if (this.transform.Find("warning2")) GameObject.Destroy(this.transform.Find("warning2").gameObject);
            if (this.transform.Find("warning3")) GameObject.Destroy(this.transform.Find("warning3").gameObject);
            Player.userName = name;
            GameObject text = root.transform.Find("Text2").gameObject;
            Text tex = text.GetComponent<Text>();
            tex.text = "Nice to meet you, " + name + "! Welcom to the world of <color=red>Privacy Context Game</color>. " +
                "Throughout the game, you will explore some of the IoT devices that we usually used in our daily life " +
                ",as well as the potential privacy issues they bring to us.";

            ChangeTextNew("Text2", "Text1");
        }

        //Player.userName = name;
        //GameObject text = root.transform.Find("Text2").gameObject;
        //Text tex = text.GetComponent<Text>();
        //tex.text = "Nice to meet you, " + name + "! Welcom to the world of <color=red>Privacy Context Game</color>. " +
        //    "Throughout the game, you will explore some of the IoT devices that we usually used in our daily life " +
        //    ",as well as the potential privacy issues they bring to us.";

        //ChangeTextNew("Text2", "Text1");

    }

    private void WarningText(string warningName)
    {
        //在普通情况下，GameObject.Find以及Transform.Find和Transform.FindChild是可以做到相同的功能，但是他们有本质上的区别，望新手谨记：
        //GameObject.Find是遍历整个当前场景，挨个查找，效率偏低，非特殊情况一般不要使用
        //Transform.Find是只查找自己本身以及自己的子对象，效率比较高，用途比较大
        //Transform.FindChild是跟Transform.Find一样的用法，但是官方不建议继续使用，用Transform.Find代替之
        if (!this.transform.Find(warningName))
        {
            GameObject warning = new GameObject(warningName);
            warning.AddComponent<Text>();
            warning.transform.SetParent(this.transform);
            Text warningText = warning.GetComponent<Text>();
            switch (warningName)
            {
                case "warning1":
                    warningText.text = "This name is alreadey taken!";
                    if (this.transform.Find("warning2")) GameObject.Destroy(this.transform.Find("warning2").gameObject);
                    if (this.transform.Find("warning3")) GameObject.Destroy(this.transform.Find("warning3").gameObject);
                    break;
                case "warning2":
                    warningText.text = "This name is too long! Try to make it shorter than 10 characters please.";
                    if (this.transform.Find("warning1")) GameObject.Destroy(this.transform.Find("warning1").gameObject);
                    if (this.transform.Find("warning3")) GameObject.Destroy(this.transform.Find("warning3").gameObject);
                    break;
                case "warning3":    
                    warningText.text = "This name is too short! Try to make it longer than 2 characters please.";
                    if (this.transform.Find("warning1")) GameObject.Destroy(this.transform.Find("warning1").gameObject);
                    if (this.transform.Find("warning2")) GameObject.Destroy(this.transform.Find("warning2").gameObject);
                    break;
            } 
            warningText.font = Resources.Load<Font>("Fonts/Quicksand-Bold");
            warningText.color = Color.red;
            warningText.fontSize = 50;
            RectTransform warningRTF = warning.GetComponent<RectTransform>();
            warningRTF.anchorMin = new Vector2(0, 0);
            warningRTF.anchorMax = new Vector2(1, 1);
            // new Vector2(left, bottom)
            warningRTF.offsetMin = new Vector2(-5, -592);
            // new Vector2(-right, -top)
            warningRTF.offsetMax = new Vector2(95, -492);
        }
    }

    // define the behaviors for each text object
    private void MainText(TextAttribute index)
    {
        string textContent;

        switch (index)
        {
            case TextAttribute.Text1:
                InputName();
                break;

            case TextAttribute.Text2:
                curText = root.transform.Find("Text3").gameObject;
                tex = curText.GetComponent<Text>();
                tex.text = "this is page3this is page3this is page3this is page3this is page3this is page3" +
                    "this is page3this is page3this is page3this is page3this is page3this is page3this is page3" +
                    "this is page3this is page3this is page3this is page3this is page3this is page3this is page3";
                ChangeTextNew("Text3", "Text2");
                break;

            case TextAttribute.Text3:
                curText = root.transform.Find("StageSelection").gameObject;
                tex = curText.GetComponent<Text>();
                tex.text = "this is page4";
                ChangeTextNew("StageSelection", "Text3");
                break;

            case TextAttribute.StageSelection:
                // initialize player info
                Player.Init();
                Save.SaveByJSON();
                LoadGame.LoadScene("Select Location");
                break;

            // this is the start of text for department store
            case TextAttribute.cs_1_1_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific position", "Smartphone", "None" ,"Determine possible escape routes");
                ChangeText("cs_1.1.2", MainTextContent.cs_ID_1[0]);
                break;

            case TextAttribute.cs_1_1_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific position", "Smartphone", "Until you leave");
                ChangeText("cs_1.1.3", MainTextContent.cs_ID_1[1]);
                CheckComfortableLevel(TextAttribute.cs_1_1_3, ScenarioCode.cs_ID_1);
                break;

            case TextAttribute.cs_1_1_3:
                ChangeText("cs_1.1.4", MainTextContent.allow);
                CheckDecision(TextAttribute.cs_1_1_4, ScenarioCode.cs_ID_1);
                break;

            case TextAttribute.cs_1_1_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific position", "Smartphone", "Not deleted");
                ChangeText("cs_1.2.1", MainTextContent.cs_ID_2[0]);
                CheckComfortableLevel(TextAttribute.cs_1_2_1, ScenarioCode.cs_ID_2);
                break;

            case TextAttribute.cs_1_2_1:
                ChangeText("cs_1.2.2", MainTextContent.allow);
                CheckDecision(TextAttribute.cs_1_2_2, ScenarioCode.cs_ID_2);
                break;

            case TextAttribute.cs_1_2_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific position", "Smartwatch", 
                    "None", "None");
                ChangeText("cs_1.3.1", MainTextContent.cs_ID_3[0]);
                break;

            case TextAttribute.cs_1_3_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific position", "Smartwatch",
                    "Not told", "You are not told what the data is uesd for", "Device manufacturer");
                ChangeText("cs_1.3.2", MainTextContent.cs_ID_3[1]);
                CheckComfortableLevel(TextAttribute.cs_1_3_2, ScenarioCode.cs_ID_3);
                break;

            case TextAttribute.cs_1_3_2:
                ChangeText("cs_1.3.3", MainTextContent.allow);
                CheckDecision(TextAttribute.cs_1_3_3, ScenarioCode.cs_ID_3);
                break;

            case TextAttribute.cs_1_3_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific position", "Smartwatch", 
                    "One week", "You are not told what the data is uesd for", "Device manufacturer");
                ChangeText("cs_1.4.1", MainTextContent.cs_ID_4[0]);
                break;

            case TextAttribute.cs_1_4_1:
                ChangeText("cs_1.4.2", MainTextContent.comfortable);
                CheckComfortableLevel(TextAttribute.cs_1_4_2, ScenarioCode.cs_ID_4);
                break;

            case TextAttribute.cs_1_4_2:
                ChangeText("cs_1.4.3", MainTextContent.allow);
                CheckDecision(TextAttribute.cs_1_4_3, ScenarioCode.cs_ID_4);
                break;

            case TextAttribute.cs_1_4_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific position", "Smartphone", 
                    "None", "Determine possible escape routes", "Device manufacturer");
                ChangeText("cs_1.5.1", MainTextContent.cs_ID_5[0]);
                break;

            case TextAttribute.cs_1_5_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific position", "Smartphone", "Until you leave");
                ChangeText("cs_1.5.2", MainTextContent.cs_ID_5[1]);
                CheckComfortableLevel(TextAttribute.cs_1_5_2, ScenarioCode.cs_ID_5);
                break;

            case TextAttribute.cs_1_5_2:
                ChangeText("cs_1.5.3", MainTextContent.allow);
                CheckDecision(TextAttribute.cs_1_5_3, ScenarioCode.cs_ID_5);
                break;

            case TextAttribute.cs_1_5_3:
                ChangeText("cs_1.6.0", MainTextContent.finishScene);
                finished = true;
                AddQuestionState("cs_1");
                Save.SaveByJSON();
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                break;

            case TextAttribute.cs_2_1_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Facial information", "Your answer");
                ChangeText("cs_2.1.2", MainTextContent.select);
                SelectIcon("facial recognition", TextAttribute.cs_2_1_2);
                ShowTips(true, "cs_2.1");
                break;

            case TextAttribute.cs_2_1_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Facial information", "Facial recognition system");
                if (answerCorrect)
                {
                    AddAnswer("cs_2.1");
                    textContent = MainTextContent.correct + "<color=green>facial recognition</color>.";
                }
                else
                {
                    textContent = MainTextContent.wrong + "<color=green>facial recognition</color>.";
                }
                ChangeText("cs_2.1.3", textContent);
                ShowTips(false);
                break;

            case TextAttribute.cs_2_1_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Customers' faces", "Facial recognition system");
                DestroyCorrectWrongGO();
                ChangeText("cs_2.1.4", MainTextContent.cs_ID_6[0]);
                break;

            case TextAttribute.cs_2_1_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Customers' faces", "Facial recognition system", 
                    "None", "Keep track of your orders and make suggestions");
                ChangeText("cs_2.1.5", MainTextContent.cs_ID_6[1]);
                break;

            case TextAttribute.cs_2_1_5:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Customers' faces", "Facial recognition system", "One week");
                ChangeText("cs_2.1.6", MainTextContent.cs_ID_6[2]);
                CheckComfortableLevel(TextAttribute.cs_2_1_6, ScenarioCode.cs_ID_6);
                break;

            case TextAttribute.cs_2_1_6:
                ChangeText("cs_2.1.7", MainTextContent.allow);
                CheckDecision(TextAttribute.cs_2_1_7, ScenarioCode.cs_ID_6);
                break;

            case TextAttribute.cs_2_1_7:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Customers' faces", "Facial recognition system", "Never deleted");
                ChangeText("cs_2.2.1", MainTextContent.cs_ID_7[0]);
                CheckComfortableLevel(TextAttribute.cs_2_2_1, ScenarioCode.cs_ID_7);
                break;

            case TextAttribute.cs_2_2_1:
                ChangeText("cs_2.2.2", MainTextContent.allow);
                CheckDecision(TextAttribute.cs_2_2_2, ScenarioCode.cs_ID_7);
                break;

            case TextAttribute.cs_2_2_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Customers' faces", "Facial recognition system", 
                    "One week", "You are not told what the data is uesd for");
                ChangeText("cs_2.3.1", MainTextContent.cs_ID_8[0]);
                CheckComfortableLevel(TextAttribute.cs_2_3_1, ScenarioCode.cs_ID_8);
                break;

            case TextAttribute.cs_2_3_1:
                ChangeText("cs_2.3.2", MainTextContent.allow);
                CheckDecision(TextAttribute.cs_2_3_2, ScenarioCode.cs_ID_8);
                break;


            case TextAttribute.cs_2_3_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Temperature sensor", 
                    "One year", "Indicate potential hazards, e.g., fire");
                ChangeText("cs_2.4.1", MainTextContent.cs_ID_9[0]);
                // fade in
                fade(true);
                break;

            case TextAttribute.cs_2_4_1:
                ChangeText("cs_2.4.2", MainTextContent.comfortable);
                // fade out
                fade(false);
                CheckComfortableLevel(TextAttribute.cs_2_4_2, ScenarioCode.cs_ID_9);
                break;

            case TextAttribute.cs_2_4_2:
                ChangeText("cs_2.4.3", MainTextContent.allow);
                CheckDecision(TextAttribute.cs_2_4_3, ScenarioCode.cs_ID_9);
                break;

            case TextAttribute.cs_2_4_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Temperature sensor", 
                    "Not deleted", "Indicate potential hazards, e.g., fire");
                ChangeText("cs_2.5.1", MainTextContent.cs_ID_10[0]);
                CheckComfortableLevel(TextAttribute.cs_2_5_1, ScenarioCode.cs_ID_10);
                break;

            case TextAttribute.cs_2_5_1:
                ChangeText("cs_2.5.2", MainTextContent.allow);
                CheckDecision(TextAttribute.cs_2_5_2, ScenarioCode.cs_ID_10);
                break;

            case TextAttribute.cs_2_5_2:
                ChangeText("cs_2.6.0", MainTextContent.finishScene);
                finished = true;
                AddQuestionState("cs_2");
                Save.SaveByJSON();
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                break;

            case TextAttribute.cs_3_1_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Recording video", "Camera", 
                    "None", "Determine whether the shop can reduce the number of staff");
                ChangeText("cs_3.1.2", MainTextContent.cs_ID_11[0]);
                // fade in
                fade(true);
                break;

            case TextAttribute.cs_3_1_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Recording video", "Camera", 
                    "Until it is reviewed at the end of the shift");
                ChangeText("cs_3.1.3", MainTextContent.cs_ID_11[1]);
                // fade out
                fade(false);
                CheckComfortableLevel(TextAttribute.cs_3_1_3, ScenarioCode.cs_ID_11);
                break;

            case TextAttribute.cs_3_1_3:
                ChangeText("cs_3.1.4", MainTextContent.allow);
                CheckDecision(TextAttribute.cs_3_1_4, ScenarioCode.cs_ID_11);
                break;

            case TextAttribute.cs_3_1_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Recording video", "Camera", "One year");
                ChangeText("cs_3.2.1", MainTextContent.cs_ID_12[0]);
                CheckComfortableLevel(TextAttribute.cs_3_2_1, ScenarioCode.cs_ID_12);
                break;

            case TextAttribute.cs_3_2_1:
                ChangeText("cs_3.2.2", MainTextContent.allow);
                CheckDecision(TextAttribute.cs_3_2_2, ScenarioCode.cs_ID_12);
                break;

            case TextAttribute.cs_3_2_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Recording video", "Camera", "Not deleted", 
                    "You are not told what the data is uesd for");
                ChangeText("cs_3.3.1", MainTextContent.cs_ID_13[0]);
                break;

            case TextAttribute.cs_3_3_1:
                ChangeText("cs_3.3.2", MainTextContent.comfortable);
                CheckComfortableLevel(TextAttribute.cs_3_3_2, ScenarioCode.cs_ID_13);
                break;

            case TextAttribute.cs_3_3_2:
                ChangeText("cs_3.3.3", MainTextContent.allow);
                CheckDecision(TextAttribute.cs_3_3_3, ScenarioCode.cs_ID_13);
                break;

            case TextAttribute.cs_3_3_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Your answer", "None", "None");
                ChangeText("cs_3.4.1", MainTextContent.cs_ID_14[0]);
                break;

            case TextAttribute.cs_3_4_1:
                ChangeText("cs_3.4.2", MainTextContent.select);
                SelectIcon("presence sensor", TextAttribute.cs_3_4_2);
                ShowTips(true, "cs_3.4");
                break;

            case TextAttribute.cs_3_4_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor");
                if (answerCorrect)
                {
                    AddAnswer("cs_3.4");
                    textContent = MainTextContent.correct + "<color=green>presence sensor</color>.";
                }
                else
                {
                    textContent = MainTextContent.wrong + "<color=green>presence sensor</color>.";
                }
                ChangeText("cs_3.4.3", textContent);
                ShowTips(false);
                break;

            case TextAttribute.cs_3_4_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Whether someone is present", "Presence sensor", 
                    "None", "Determine whether they can reduce the number of staff at these times");
                DestroyCorrectWrongGO();
                ChangeText("cs_3.4.4", MainTextContent.cs_ID_14[1]);
                break;

            case TextAttribute.cs_3_4_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Whether someone is present", "Presence sensor", 
                    "Until it is reviewed at the end of the shift", "Determine whether they can reduce the number of staff at these times");
                ChangeText("cs_3.4.5", MainTextContent.cs_ID_14[2]);
                CheckComfortableLevel(TextAttribute.cs_3_4_5, ScenarioCode.cs_ID_14);
                break;

            case TextAttribute.cs_3_4_5:
                ChangeText("cs_3.4.6", MainTextContent.allow);
                CheckDecision(TextAttribute.cs_3_4_6, ScenarioCode.cs_ID_14);
                break;

            case TextAttribute.cs_3_4_6:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Whether someone is present", "Your answer",
                "Until the room is no longer occupied", "Determine when to switch on and off the lights to reduce costs and save energy");
                ChangeText("cs_3.5.1", MainTextContent.cs_ID_15[0]);
                break;

            case TextAttribute.cs_3_5_1:
                ChangeText("cs_3.5.2", MainTextContent.comfortable);
                CheckComfortableLevel(TextAttribute.cs_3_5_2, ScenarioCode.cs_ID_15);
                break;

            case TextAttribute.cs_3_5_2:
                ChangeText("cs_3.5.3", MainTextContent.allow);
                CheckDecision(TextAttribute.cs_3_5_3, ScenarioCode.cs_ID_15);
                break;

            case TextAttribute.cs_3_5_3:
                ChangeText("cs_3.6.0", MainTextContent.finishLocation);
                finished = true;
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                AddQuestionState("cs_3");
                Save.SaveByJSON();
                break;

            // this is the start of text for library
            case TextAttribute.lb_1_1_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Biometric data");
                ChangeText("lb_1.1.2", MainTextContent.lb_ID_1[0]);
                break;

            case TextAttribute.lb_1_1_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Biometric data", "Your answer");
                ChangeText("lb_1.1.3", MainTextContent.select);
                SelectIcon("iris scanner", TextAttribute.lb_1_1_3);
                ShowTips(true, "lb_1.1");
                break;

            case TextAttribute.lb_1_1_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Biometric data", "Iris scanner");
                if (answerCorrect)
                {
                    AddAnswer("lb_1.1");
                    textContent = MainTextContent.correct + "<color=green>iris scanner</color>.";
                }
                else
                {
                    textContent = MainTextContent.wrong + "<color=green>iris scanner</color>.";
                }
                ChangeText("lb_1.1.4", textContent);
                ShowTips(false);
                break;

            case TextAttribute.lb_1_1_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Iris scan", "Iris scanner",
                    "None", "Keep track of your visits and make suggestions based on your habits regardless of whether you are a registered library user or not");
                DestroyCorrectWrongGO();
                ChangeText("lb_1.1.5", MainTextContent.lb_ID_1[1]);
                break;

            case TextAttribute.lb_1_1_5:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Iris scan", "Iris scanner", "Not told");
                ChangeText("lb_1.1.6", MainTextContent.lb_ID_1[2]);
                CheckComfortableLevel(TextAttribute.lb_1_1_6, ScenarioCode.lb_ID_1);
                break;

            case TextAttribute.lb_1_1_6:
                ChangeText("lb_1.1.7", MainTextContent.allow);
                CheckDecision(TextAttribute.lb_1_1_7, ScenarioCode.lb_ID_1);
                break;

            case TextAttribute.lb_1_1_7:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Iris scan", "Iris scanner", "Not deleted");
                ChangeText("lb_1.2.1", MainTextContent.lb_ID_2[0]);
                CheckComfortableLevel(TextAttribute.lb_1_2_1, ScenarioCode.lb_ID_2);
                break;

            case TextAttribute.lb_1_2_1:
                ChangeText("lb_1.2.2", MainTextContent.allow);
                CheckDecision(TextAttribute.lb_1_2_2, ScenarioCode.lb_ID_2);
                break;

            case TextAttribute.lb_1_2_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Iris scan", "Iris scanner", "Until door is closed again");
                ChangeText("lb_1.3.1", MainTextContent.lb_ID_3[0]);
                CheckComfortableLevel(TextAttribute.lb_1_3_1, ScenarioCode.lb_ID_3);
                break;

            case TextAttribute.lb_1_3_1:
                ChangeText("lb_1.3.2", MainTextContent.allow);
                CheckDecision(TextAttribute.lb_1_3_2, ScenarioCode.lb_ID_3);
                break;

            case TextAttribute.lb_1_3_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Your picture of face", "Facial recognition", "None", "None");
                ChangeText("lb_1.4.1", MainTextContent.lb_ID_4[0]);
                // fade in
                fade(true);
                break;

            case TextAttribute.lb_1_4_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Your picture of face", "Facial recognition",
                    "None", "Keep track of your visits and make suggestions based on your habits regardless of whether you are a registered library user or not");
                ChangeText("lb_1.4.2", MainTextContent.lb_ID_4[1]);
                // fade out
                fade(false);
                break;

            case TextAttribute.lb_1_4_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Your picture of face", "Facial recognition", "Until door is closed again");
                ChangeText("lb_1.4.3", MainTextContent.lb_ID_4[2]);
                CheckComfortableLevel(TextAttribute.lb_1_4_3, ScenarioCode.lb_ID_4);
                break;

            case TextAttribute.lb_1_4_3:
                ChangeText("lb_1.4.4", MainTextContent.allow);
                CheckDecision(TextAttribute.lb_1_4_4, ScenarioCode.lb_ID_4);
                break;

            case TextAttribute.lb_1_4_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Your picture of face", "Facial recognition", "Not deleted");
                ChangeText("lb_1.5.1", MainTextContent.lb_ID_5[0]);
                CheckComfortableLevel(TextAttribute.lb_1_5_1, ScenarioCode.lb_ID_5);
                break;

            case TextAttribute.lb_1_5_1:
                ChangeText("lb_1.5.2", MainTextContent.allow);
                CheckDecision(TextAttribute.lb_1_5_2, ScenarioCode.lb_ID_5);
                break;

            case TextAttribute.lb_1_5_2:
                ChangeText("cs_1.6.0", MainTextContent.finishScene);
                finished = true;
                AddQuestionState("lb_1");
                Save.SaveByJSON();
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                break;

            case TextAttribute.lb_2_1_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Temperature sensor",
                    "None", "Indicate potential hazards, e.g., fire");
                ChangeText("lb_2.1.2", MainTextContent.lb_ID_6[0]);
                // fade in
                fade(true);
                break;

            case TextAttribute.lb_2_1_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Temperature sensor", "Not told");
                ChangeText("lb_2.1.3", MainTextContent.lb_ID_6[1]);
                CheckComfortableLevel(TextAttribute.lb_2_1_3, ScenarioCode.lb_ID_6);
                // fade out
                fade(false);
                break;

            case TextAttribute.lb_2_1_3:
                ChangeText("lb_2.1.4", MainTextContent.allow);
                CheckDecision(TextAttribute.lb_2_1_4, ScenarioCode.lb_ID_6);
                break;

            case TextAttribute.lb_2_1_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Temperature sensor", "One week");
                ChangeText("lb_2.2.1", MainTextContent.lb_ID_7[0]);
                CheckComfortableLevel(TextAttribute.lb_2_2_1, ScenarioCode.lb_ID_7);
                break;

            case TextAttribute.lb_2_2_1:
                ChangeText("lb_2.2.2", MainTextContent.allow);
                CheckDecision(TextAttribute.lb_2_2_2, ScenarioCode.lb_ID_7);
                break;

            case TextAttribute.lb_2_2_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Biometric information", "None", "None", "None");
                ChangeText("lb_2.3.1", MainTextContent.lb_ID_8[0]);
                break;

            case TextAttribute.lb_2_3_1:
                ChangeText("lb_2.3.2", MainTextContent.lb_ID_8[1]);
                break;

            case TextAttribute.lb_2_3_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Biometric information", "Your answer", "None", "None");
                ChangeText("lb_2.3.3", MainTextContent.select);
                SelectIcon("fingerprint scanner", TextAttribute.lb_2_3_3);
                ShowTips(true, "lb_2.3");
                break;

            case TextAttribute.lb_2_3_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Fingerprint", "Fingerprint scanner");
                if (answerCorrect)
                {
                    AddAnswer("lb_2.3");
                    textContent = MainTextContent.correct + "<color=green>fingerprint scanner</color>.";
                }
                else
                {
                    textContent = MainTextContent.wrong + "<color=green>fingerprint scanner</color>.";
                }
                ChangeText("lb_2.3.4", textContent);
                ShowTips(false);
                break;

            case TextAttribute.lb_2_3_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Your fingerprint", "Fingerprint scanner",
                    "None", "Not told");
                DestroyCorrectWrongGO();
                ChangeText("lb_2.3.5", MainTextContent.lb_ID_8[2]);
                break;

            case TextAttribute.lb_2_3_5:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Your fingerprint", "Fingerprint scanner", "Not deleted");
                ChangeText("lb_2.3.6", MainTextContent.lb_ID_8[3]);
                CheckComfortableLevel(TextAttribute.lb_2_3_6, ScenarioCode.lb_ID_8);
                break;

            case TextAttribute.lb_2_3_6:
                ChangeText("lb_2.3.7", MainTextContent.allow);
                CheckDecision(TextAttribute.lb_2_3_7, ScenarioCode.lb_ID_8);
                break;

            case TextAttribute.lb_2_3_7:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Your fingerprint", "Fingerprint scanner", 
                    "Not deleted" , "Identify patrons and allow them to check out books without presenting their library card");
                ChangeText("lb_2.4.1", MainTextContent.lb_ID_9[0]);
                CheckComfortableLevel(TextAttribute.lb_2_4_1, ScenarioCode.lb_ID_9);
                break;

            case TextAttribute.lb_2_4_1:
                ChangeText("lb_2.4.2", MainTextContent.allow);
                CheckDecision(TextAttribute.lb_2_4_2, ScenarioCode.lb_ID_9);
                break;

            case TextAttribute.lb_2_4_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Your fingerprint", "Fingerprint scanner", "Until your library card expires");
                ChangeText("lb_2.5.1", MainTextContent.lb_ID_10[0]);
                CheckComfortableLevel(TextAttribute.lb_2_5_1, ScenarioCode.lb_ID_10);
                break;

            case TextAttribute.lb_2_5_1:
                ChangeText("lb_2.5.2", MainTextContent.allow);
                CheckDecision(TextAttribute.lb_2_5_2, ScenarioCode.lb_ID_10);
                break;

            case TextAttribute.lb_2_5_2:
                ChangeText("lb_2.6.0", MainTextContent.finishScene);
                finished = true;
                AddQuestionState("lb_2");
                Save.SaveByJSON();
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                break;

            case TextAttribute.lb_3_1_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Recording video", "Camera",
                    "None", "Get feedback on how to improve wait times for people");
                ChangeText("lb_3.1.2", MainTextContent.lb_ID_11[0]);
                // fade in
                fade(true);
                break;

            case TextAttribute.lb_3_1_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Recording video", "Camera",
                "Until it is reviewed at the end of the shift", "Get feedback on how to improve wait times for people");
                ChangeText("lb_3.1.3", MainTextContent.lb_ID_11[1]);
                CheckComfortableLevel(TextAttribute.lb_3_1_3, ScenarioCode.lb_ID_11);
                // fade out
                fade(false);
                break;

            case TextAttribute.lb_3_1_3:
                ChangeText("lb_3.1.4", MainTextContent.allow);
                CheckDecision(TextAttribute.lb_3_1_4, ScenarioCode.lb_ID_11);
                break;

            case TextAttribute.lb_3_1_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Recording video", "Camera", "One year");
                ChangeText("lb_3.2.1", MainTextContent.lb_ID_12[0]);
                CheckComfortableLevel(TextAttribute.lb_3_2_1, ScenarioCode.lb_ID_12);
                break;

            case TextAttribute.lb_3_2_1:
                ChangeText("lb_3.2.2", MainTextContent.allow);
                CheckDecision(TextAttribute.lb_3_2_2, ScenarioCode.lb_ID_12);
                break;

            case TextAttribute.lb_3_2_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "None", "None", "None");
                ChangeText("lb_3.3.1", MainTextContent.lb_ID_13[0]);
                break;

            case TextAttribute.lb_3_3_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Your answer", "None", "None");
                ChangeText("lb_3.3.2", MainTextContent.select);
                SelectIcon("presence sensor", TextAttribute.lb_3_3_2);
                ShowTips(true, "lb_3.3");
                break;

            case TextAttribute.lb_3_3_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor");
                if (answerCorrect)
                {
                    AddAnswer("lb_3.3");
                    textContent = MainTextContent.correct + "<color=green>presence sensor</color>.";
                }
                else
                {
                    textContent = MainTextContent.wrong + "<color=green>presence sensor</color>.";
                }
                ChangeText("lb_3.3.3", textContent);
                ShowTips(false);
                break;

            case TextAttribute.lb_3_3_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor",
                    "None", "Determine whether they can reduce the number of staff at these times");
                DestroyCorrectWrongGO();
                ChangeText("lb_3.3.4", MainTextContent.lb_ID_13[1]);
                break;

            case TextAttribute.lb_3_3_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor",
                "Until it is reviewed at the end of the shift", "Determine whether they can reduce the number of staff at these times");
                ChangeText("lb_3.3.5", MainTextContent.lb_ID_13[2]);
                CheckComfortableLevel(TextAttribute.lb_3_3_5, ScenarioCode.lb_ID_13);
                break;

            case TextAttribute.lb_3_3_5:
                ChangeText("lb_3.3.6", MainTextContent.allow);
                CheckDecision(TextAttribute.lb_3_3_6, ScenarioCode.lb_ID_13);
                break;

            case TextAttribute.lb_3_3_6:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor",
                "Until the room is no longer occupied", "Determine when to switch on and off the lights to reduce costs and save energy");
                ChangeText("lb_3.4.1", MainTextContent.lb_ID_14[0]);
                CheckComfortableLevel(TextAttribute.lb_3_4_1, ScenarioCode.lb_ID_14);
                break;

            case TextAttribute.lb_3_4_1:
                ChangeText("lb_3.4.2", MainTextContent.allow);
                CheckDecision(TextAttribute.lb_3_4_2, ScenarioCode.lb_ID_14);
                break;

            case TextAttribute.lb_3_4_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor", "One year");
                ChangeText("lb_3.5.1", MainTextContent.lb_ID_15[0]);
                CheckComfortableLevel(TextAttribute.lb_3_5_1, ScenarioCode.lb_ID_15);
                break;

            case TextAttribute.lb_3_5_1:
                ChangeText("lb_3.5.2", MainTextContent.allow);
                CheckDecision(TextAttribute.lb_3_5_2, ScenarioCode.lb_ID_15);
                break;

            case TextAttribute.lb_3_5_2:
                ChangeText("lb_3.6.0", MainTextContent.finishLocation);
                finished = true;
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                AddQuestionState("lb_3");
                Save.SaveByJSON();
                break;

            // this is the start of text for home
            case TextAttribute.hm_1_1_1:
                ChangeText("hm_1.1.2", MainTextContent.hm_ID_1[0]);
                break;

            case TextAttribute.hm_1_1_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "None", "Your answer", "None", "None");
                ChangeText("hm_1.1.3", MainTextContent.select);
                SelectIcon("presence sensor", TextAttribute.hm_1_1_3);
                ShowTips(true, "hm_1.1");
                break;

            case TextAttribute.hm_1_1_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "None", "Presence sensor");
                if (answerCorrect)
                {
                    AddAnswer("hm_1.1");
                    textContent = MainTextContent.correct + "<color=green>presence sensor</color>.";
                }
                else
                {
                    textContent = MainTextContent.wrong + "<color=green>presence sensor</color>.";
                }
                ChangeText("hm_1.1.4", textContent);
                ShowTips(false);
                ResetTip();
                break;

            case TextAttribute.hm_1_1_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor", 
                    "None", "Determine when to switch on and off the lights to reduce costs and save energy");
                DestroyCorrectWrongGO();
                ChangeText("hm_1.1.5", MainTextContent.hm_ID_1[1]);
                break;

            case TextAttribute.hm_1_1_5:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor",
                "Not told", "Determine when to switch on and off the lights to reduce costs and save energy");
                ChangeText("hm_1.1.6", MainTextContent.hm_ID_1[2]);
                CheckComfortableLevel(TextAttribute.hm_1_1_6, ScenarioCode.hm_ID_1);
                break;

            case TextAttribute.hm_1_1_6:
                ChangeText("hm_1.1.7", MainTextContent.allow);
                CheckDecision(TextAttribute.hm_1_1_7, ScenarioCode.hm_ID_1);
                break;

            case TextAttribute.hm_1_1_7:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor", "One week");
                ChangeText("hm_1.2.1", MainTextContent.hm_ID_2[0]);
                CheckComfortableLevel(TextAttribute.hm_1_2_1, ScenarioCode.hm_ID_2);
                break;

            case TextAttribute.hm_1_2_1:
                ChangeText("hm_1.2.2", MainTextContent.allow);
                CheckDecision(TextAttribute.hm_1_2_2, ScenarioCode.hm_ID_2);
                break;

            case TextAttribute.hm_1_2_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor", "One year");
                ChangeText("hm_1.3.1", MainTextContent.hm_ID_3[0]);
                CheckComfortableLevel(TextAttribute.hm_1_3_1, ScenarioCode.hm_ID_3);
                break;

            case TextAttribute.hm_1_3_1:
                ChangeText("hm_1.3.2", MainTextContent.allow);
                CheckDecision(TextAttribute.hm_1_3_2, ScenarioCode.hm_ID_3);
                break;

            case TextAttribute.hm_1_3_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "None", "None", "None", "None");
                ChangeText("hm_1.4.1", MainTextContent.hm_ID_4[0]);
                break;

            case TextAttribute.hm_1_4_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "None", "Your answer", "None", "None");
                ChangeText("hm_1.4.2", MainTextContent.select);
                SelectIcon("camera", TextAttribute.hm_1_4_2);
                ShowTips(true, "hm_1.4");
                break;

            case TextAttribute.hm_1_4_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "None", "Camera");
                if (answerCorrect)
                {
                    AddAnswer("hm_1.4");
                    textContent = MainTextContent.correct + "<color=green>camera</color>.";
                }
                else
                {
                    textContent = MainTextContent.wrong + "<color=green>camera</color>.";
                }
                ChangeText("hm_1.4.3", textContent);
                ShowTips(false);
                break;

            case TextAttribute.hm_1_4_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Video", "Camera", "None", "Improve public safety", "Law enforcement");
                DestroyCorrectWrongGO();
                ChangeText("hm_1.4.4", MainTextContent.hm_ID_4[1]);
                break;

            case TextAttribute.hm_1_4_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Video", "Camera", "Not told");
                ChangeText("hm_1.4.5", MainTextContent.hm_ID_4[2]);
                CheckComfortableLevel(TextAttribute.hm_1_4_5, ScenarioCode.hm_ID_4);
                break;

            case TextAttribute.hm_1_4_5:
                ChangeText("hm_1.4.6", MainTextContent.allow);
                CheckDecision(TextAttribute.hm_1_4_6, ScenarioCode.hm_ID_4);
                break;

            case TextAttribute.hm_1_4_6:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Video", "Camera", "One week");
                ChangeText("hm_1.5.1", MainTextContent.hm_ID_5[0]);
                CheckComfortableLevel(TextAttribute.hm_1_5_1, ScenarioCode.hm_ID_5);
                break;

            case TextAttribute.hm_1_5_1:
                ChangeText("hm_1.5.2", MainTextContent.allow);
                CheckDecision(TextAttribute.hm_1_5_2, ScenarioCode.hm_ID_5);
                break;

            case TextAttribute.hm_1_5_2:
                ChangeText("hm_1.6.0", MainTextContent.finishScene);
                finished = true;
                AddQuestionState("hm_1");
                Save.SaveByJSON();
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                break;

            case TextAttribute.hm_2_1_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Room temperature", "Temperature sensor", "None", "None", "Security company");
                ChangeText("hm_2.1.2", MainTextContent.hm_ID_6[0]);
                // fade in
                fade(true);
                break;

            case TextAttribute.hm_2_1_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Room temperature", "Temperature sensor",
                    "One year", "You are not told what the data is uesd for", "Security company");
                ChangeText("hm_2_1_3", MainTextContent.hm_ID_6[1]);
                // fade out
                fade(false);
                CheckComfortableLevel(TextAttribute.hm_2_1_3, ScenarioCode.hm_ID_6);
                break;

            case TextAttribute.hm_2_1_3:
                ChangeText("hm_2_1_4", MainTextContent.allow);
                CheckDecision(TextAttribute.hm_2_1_4, ScenarioCode.hm_ID_6);
                break;

            case TextAttribute.hm_2_1_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Room temperature", "Temperature sensor", 
                    "None", "Check for abnormal temperatures, which indicate potential hazards, e.g., fire", "Security company");
                ChangeText("hm_2.2.1", MainTextContent.hm_ID_7[0]);
                break;

            case TextAttribute.hm_2_2_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Room temperature", "Temperature sensor", "One year");
                ChangeText("hm_2.2.2", MainTextContent.hm_ID_7[1]);
                CheckComfortableLevel(TextAttribute.hm_2_2_2, ScenarioCode.hm_ID_7);
                break;

            case TextAttribute.hm_2_2_2:
                ChangeText("hm_2.2.3", MainTextContent.allow);
                CheckDecision(TextAttribute.hm_2_2_3, ScenarioCode.hm_ID_7);
                break;

            case TextAttribute.hm_2_2_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Room temperature", "Temperature sensor", "Not deleted");
                ChangeText("hm_2.3.1", MainTextContent.hm_ID_8[0]);
                break;

            case TextAttribute.hm_2_3_1:
                ChangeText("hm_2.3.2", MainTextContent.comfortable);
                CheckComfortableLevel(TextAttribute.hm_2_3_2, ScenarioCode.hm_ID_8);
                break;

            case TextAttribute.hm_2_3_2:
                ChangeText("hm_2.3.3", MainTextContent.allow);
                CheckDecision(TextAttribute.hm_2_3_3, ScenarioCode.hm_ID_8);
                break;

            case TextAttribute.hm_2_3_3:
                ChangeText("hm_2.6.0", MainTextContent.finishLocation);
                finished = true;
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                AddQuestionState("hm_2");
                Save.SaveByJSON();
                break;

            case TextAttribute.fh_1_1_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor",
                "Until the room is no longer occupied", "Determine when to switch on and off the lights to reduce costs and save energy");
                ChangeText("fh_1.1.2", MainTextContent.fh_ID_1[0]);
                // fade in
                fade(true);
                break;

            case TextAttribute.fh_1_1_2:
                ChangeText("fh_1.1.3", MainTextContent.comfortable);
                // fade out
                fade(false);
                CheckComfortableLevel(TextAttribute.fh_1_1_3, ScenarioCode.fh_ID_1);
                break;

            case TextAttribute.fh_1_1_3:
                ChangeText("fh_1_1_4", MainTextContent.allow);
                CheckDecision(TextAttribute.fh_1_1_4, ScenarioCode.fh_ID_1);
                break;

            case TextAttribute.fh_1_1_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor", "One year");
                ChangeText("fh_1.2.1", MainTextContent.fh_ID_2[0]);
                CheckComfortableLevel(TextAttribute.fh_1_2_1, ScenarioCode.fh_ID_2);
                break;

            case TextAttribute.fh_1_2_1:
                ChangeText("fh_1_2_2", MainTextContent.allow);
                CheckDecision(TextAttribute.fh_1_2_2, ScenarioCode.fh_ID_2);
                break;

            case TextAttribute.fh_1_2_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "None", "Camera", "None", "None");
                ChangeText("fh_1.3.1", MainTextContent.fh_ID_3[0]);
                // second fade in
                fade(true, true);
                break;

            case TextAttribute.fh_1_3_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Video", "Camera", "Not told", "Improve public safety", "Law enforcement");
                ChangeText("fh_1.3.2", MainTextContent.fh_ID_3[1]);
                // second fade out
                fade(false, true);
                break;

            case TextAttribute.fh_1_3_2:
                ChangeText("fh_1.3.3", MainTextContent.comfortable);
                CheckComfortableLevel(TextAttribute.fh_1_3_3, ScenarioCode.fh_ID_3);
                break;

            case TextAttribute.fh_1_3_3:
                ChangeText("fh_1.3.4", MainTextContent.allow);
                CheckDecision(TextAttribute.fh_1_3_4, ScenarioCode.fh_ID_3);
                break;

            case TextAttribute.fh_1_3_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Video", "Camera", "One week", "Law enforcement");
                ChangeText("fh_1.4.1", MainTextContent.fh_ID_4[0]);
                CheckComfortableLevel(TextAttribute.fh_1_4_1, ScenarioCode.fh_ID_4);
                break;

            case TextAttribute.fh_1_4_1:
                ChangeText("fh_1.4.2", MainTextContent.allow);
                CheckDecision(TextAttribute.fh_1_4_2, ScenarioCode.fh_ID_4);
                break;

            case TextAttribute.fh_1_4_2:
                ChangeText("fh_1.6.0", MainTextContent.finishScene);
                finished = true;
                AddQuestionState("fh_1");
                Save.SaveByJSON();
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                break;

            case TextAttribute.fh_2_1_1:
                ChangeText("fh_2.1.2", MainTextContent.fh_ID_5[0]);
                break;

            case TextAttribute.fh_2_1_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Temperature sensor");
                ChangeText("fh_2.1.3", MainTextContent.fh_ID_5[1]);
                break;

            case TextAttribute.fh_2_1_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Your answer");
                ChangeText("fh_2.1.4", MainTextContent.select);
                SelectIcon("temperature sensor", TextAttribute.fh_2_1_4);
                ShowTips(true, "fh_2.1");
                break;

            case TextAttribute.fh_2_1_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Temperature sensor");
                if (answerCorrect)
                {
                    AddAnswer("hm_1.4");
                    textContent = MainTextContent.correct + "<color=green>temperature sensor</color>.";
                }
                else
                {
                    textContent = MainTextContent.wrong + "<color=green>temperature sensor</color>.";
                }
                ChangeText("fh_2.1.5", textContent);
                ShowTips(false);
                break;

            case TextAttribute.fh_2_1_5:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Temperature sensor", "None", "None", "Security company");
                ChangeText("fh_2.1.6", MainTextContent.fh_ID_5[2]);
                break;

            case TextAttribute.fh_2_1_6:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Temperature sensor", 
                    "Not told", "You are not told what the data is uesd for");
                ChangeText("fh_2.1.7", MainTextContent.fh_ID_5[3]);
                CheckComfortableLevel(TextAttribute.fh_2_1_7, ScenarioCode.fh_ID_5);
                break;

            case TextAttribute.fh_2_1_7:
                ChangeText("fh_2.1.8", MainTextContent.allow);
                CheckDecision(TextAttribute.fh_2_1_8, ScenarioCode.fh_ID_5);
                break;

            case TextAttribute.fh_2_1_8:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Temperature sensor",
                    "None", "Check for abnormal temperatures, which indicate potential hazards, e.g., fire", "Security company");
                ChangeText("fh_2.2.1", MainTextContent.fh_ID_6[0]);
                break;

            case TextAttribute.fh_2_2_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Temperature sensor", "Not told");
                ChangeText("fh_2.2.2", MainTextContent.fh_ID_6[1]);
                CheckComfortableLevel(TextAttribute.fh_2_2_2, ScenarioCode.fh_ID_6);
                break;

            case TextAttribute.fh_2_2_2:
                ChangeText("fh_2.2.3", MainTextContent.allow);
                CheckDecision(TextAttribute.fh_2_2_3, ScenarioCode.fh_ID_6);
                break;

            case TextAttribute.fh_2_2_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Temperature sensor", "One year");
                ChangeText("fh_2.3.1", MainTextContent.fh_ID_7[0]);
                CheckComfortableLevel(TextAttribute.fh_2_3_1, ScenarioCode.fh_ID_7);
                break;

            case TextAttribute.fh_2_3_1:
                ChangeText("fh_2.3.2", MainTextContent.allow);
                CheckDecision(TextAttribute.fh_2_3_2, ScenarioCode.fh_ID_7);
                break;

            case TextAttribute.fh_2_3_2:
                ChangeText("fh_2.6.0", MainTextContent.finishLocation);
                finished = true;
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                AddQuestionState("fh_2");
                Save.SaveByJSON();
                break;

            // this is the start of the text for work
            case TextAttribute.wk_1_1_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific position", "Smartwatch");
                ChangeText("wk_1.1.2", MainTextContent.wk_ID_1[0]);
                break;

            case TextAttribute.wk_1_1_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific position", "Smartwatch", "None", "Determine possible escape routes", "Device manufacturer");
                ChangeText("wk_1.1.3", MainTextContent.wk_ID_1[1]);
                break;

            case TextAttribute.wk_1_1_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific position", "Smartwatch", "One week");
                ChangeText("wk_1.1.4", MainTextContent.wk_ID_1[2]);
                CheckComfortableLevel(TextAttribute.wk_1_1_4, ScenarioCode.wk_ID_1);
                break;

            case TextAttribute.wk_1_1_4:
                ChangeText("wk_1.1.5", MainTextContent.allow);
                CheckDecision(TextAttribute.wk_1_1_5, ScenarioCode.wk_ID_1);
                break;

            case TextAttribute.wk_1_1_5:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific position", "Smartwatch", "Not deleted");
                ChangeText("wk_1.2.1", MainTextContent.wk_ID_2[0]);
                CheckComfortableLevel(TextAttribute.wk_1_2_1, ScenarioCode.wk_ID_2);
                break;

            case TextAttribute.wk_1_2_1:
                ChangeText("wk_1.2.2", MainTextContent.allow);
                CheckDecision(TextAttribute.wk_1_2_2, ScenarioCode.wk_ID_2);
                break;

            case TextAttribute.wk_1_2_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Video", "Camera", "None", "None", "None");
                ChangeText("wk_1.3.1", MainTextContent.wk_ID_3[0]);
                break;

            case TextAttribute.wk_1_3_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Video", "Camera", 
                    "Not told", "Optimize heating and cooling to reduce energy costs");
                ChangeText("wk_1.3.2", MainTextContent.wk_ID_3[1]);
                break;

            case TextAttribute.wk_1_3_2:
                ChangeText("wk_1.3.3", MainTextContent.comfortable);
                CheckComfortableLevel(TextAttribute.wk_1_3_3, ScenarioCode.wk_ID_3);
                break;

            case TextAttribute.wk_1_3_3:
                ChangeText("wk_1.3.4", MainTextContent.allow);
                CheckDecision(TextAttribute.wk_1_3_4, ScenarioCode.wk_ID_3);
                break;

            case TextAttribute.wk_1_3_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Video", "Camera", "One year");
                ChangeText("wk_1.4.1", MainTextContent.wk_ID_4[0]);
                CheckComfortableLevel(TextAttribute.wk_1_4_1, ScenarioCode.wk_ID_4);
                break;

            case TextAttribute.wk_1_4_1:
                ChangeText("wk_1.4.2", MainTextContent.allow);
                CheckDecision(TextAttribute.wk_1_4_2, ScenarioCode.wk_ID_4);
                break;

            case TextAttribute.wk_1_4_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Video", "Camera", "One year", "Improve public safety", "Law enforcement");
                ChangeText("wk_1.5.1", MainTextContent.wk_ID_5[0]);
                break;

            case TextAttribute.wk_1_5_1:
                ChangeText("wk_1.5.2", MainTextContent.comfortable);
                CheckComfortableLevel(TextAttribute.wk_1_5_2, ScenarioCode.wk_ID_5);
                break;

            case TextAttribute.wk_1_5_2:
                ChangeText("wk_1.5.3", MainTextContent.allow);
                CheckDecision(TextAttribute.wk_1_5_3, ScenarioCode.wk_ID_5);
                break;

            case TextAttribute.wk_1_5_3:
                ChangeText("wk_1.6.0", MainTextContent.finishScene);
                finished = true;
                AddQuestionState("wk_1");
                Save.SaveByJSON();
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                break;

            case TextAttribute.wk_2_1_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor", 
                    "None", "Optimize heating and cooling to make the employees most comfortable");
                ChangeText("wk_2.1.2", MainTextContent.wk_ID_6[0]);
                // fade in
                fade(true);
                break;

            case TextAttribute.wk_2_1_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor",
                    "Not told");
                ChangeText("wk_2.1.3", MainTextContent.wk_ID_6[1]);
                // fade out
                fade(false);
                CheckComfortableLevel(TextAttribute.wk_2_1_3, ScenarioCode.wk_ID_6);
                break;

            case TextAttribute.wk_2_1_3:
                ChangeText("wk_2.1.4", MainTextContent.allow);
                CheckDecision(TextAttribute.wk_2_1_4, ScenarioCode.wk_ID_6);
                break;

            case TextAttribute.wk_2_1_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor", "One year");
                ChangeText("wk_2.2.1", MainTextContent.wk_ID_7[0]);
                CheckComfortableLevel(TextAttribute.wk_2_2_1, ScenarioCode.wk_ID_7);
                break;

            case TextAttribute.wk_2_2_1:
                ChangeText("wk_2.2.2", MainTextContent.allow);
                CheckDecision(TextAttribute.wk_2_2_2, ScenarioCode.wk_ID_7);
                break;

            case TextAttribute.wk_2_2_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor", 
                    "One year", "Determine when to switch on and off the lights in each room to reduce costs and save energy");
                ChangeText("wk_2.3.1", MainTextContent.wk_ID_8[0]);
                break;

            case TextAttribute.wk_2_3_1:
                ChangeText("wk_2.3.2", MainTextContent.comfortable);
                CheckComfortableLevel(TextAttribute.wk_2_3_2, ScenarioCode.wk_ID_8);
                break;

            case TextAttribute.wk_2_3_2:
                ChangeText("wk_2.3.3", MainTextContent.allow);
                CheckDecision(TextAttribute.wk_2_3_3, ScenarioCode.wk_ID_8);
                break;

            case TextAttribute.wk_2_3_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "None", "None", "None", "None");
                ChangeText("wk_2.4.1", MainTextContent.wk_ID_9[0]);
                break;

            case TextAttribute.wk_2_4_1:
                ChangeText("wk_2.4.2", MainTextContent.select);
                SelectIcon("smartphone", TextAttribute.wk_2_4_2);
                ShowTips(true, "wk_2.4");
                break;

            case TextAttribute.wk_2_4_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "None", "Smartphone");
                if (answerCorrect)
                {
                    AddAnswer("wk_2.4");
                    textContent = MainTextContent.correct + "<color=green>smartphone</color>.";
                }
                else
                {
                    textContent = MainTextContent.wrong + "<color=green>smartphone</color>.";
                }
                ChangeText("wk_2.4.3", textContent);
                ShowTips(false);
                break;

            case TextAttribute.wk_2_4_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific position", "Smartphone");
                ChangeText("wk_2.4.4", MainTextContent.wk_ID_9[1]);
                break;

            case TextAttribute.wk_2_4_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific position", "Smartphone",
                    "One year", "You are not told what the data is used for");
                ChangeText("wk_2.4.5", MainTextContent.wk_ID_9[2]);
                break;

            case TextAttribute.wk_2_4_5:
                ChangeText("wk_2.4.6", MainTextContent.comfortable);
                CheckComfortableLevel(TextAttribute.wk_2_4_6, ScenarioCode.wk_ID_9);
                break;

            case TextAttribute.wk_2_4_6:
                ChangeText("wk_2.4.7", MainTextContent.allow);
                CheckDecision(TextAttribute.wk_2_4_7, ScenarioCode.wk_ID_9);
                break;

            case TextAttribute.wk_2_4_7:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific position", "Smartphone",
                    "One year", "Determine possible escape routes in the case of an emergency or a hazard");
                ChangeText("wk_2.5.1", MainTextContent.wk_ID_10[0]);
                CheckComfortableLevel(TextAttribute.wk_2_5_1, ScenarioCode.wk_ID_10);
                break;

            case TextAttribute.wk_2_5_1:
                ChangeText("wk_2.5.2", MainTextContent.allow);
                CheckDecision(TextAttribute.wk_2_5_2, ScenarioCode.wk_ID_10);
                break;

            case TextAttribute.wk_2_5_2:
                ChangeText("wk_2.6.0", MainTextContent.finishScene);
                finished = true;
                AddQuestionState("wk_2");
                Save.SaveByJSON();
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                break;

            case TextAttribute.wk_3_1_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient Temperature", "Temperature sensor",
                    "Not told", "You are not told what the data is used for");
                ChangeText("wk_3.1.2", MainTextContent.wk_ID_11[0]);
                // fade in
                fade(true);
                break;

            case TextAttribute.wk_3_1_2:
                ChangeText("wk_3.1.3", MainTextContent.comfortable);
                // fade out
                fade(false);
                CheckComfortableLevel(TextAttribute.wk_3_1_3, ScenarioCode.wk_ID_11);
                break;

            case TextAttribute.wk_3_1_3:
                ChangeText("wk_3.1.4", MainTextContent.allow);
                CheckDecision(TextAttribute.wk_3_1_4, ScenarioCode.wk_ID_11);
                break;

            case TextAttribute.wk_3_1_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient Temperature", "Temperature sensor",
                    "Not told", "Check for abnormal temperatures, which indicate potential hazards, e.g., fire");
                ChangeText("wk_3.2.1", MainTextContent.wk_ID_12[0]);
                break;

            case TextAttribute.wk_3_2_1:
                ChangeText("wk_3.2.2", MainTextContent.wk_ID_12[1]);
                CheckComfortableLevel(TextAttribute.wk_3_2_2, ScenarioCode.wk_ID_12);
                break;

            case TextAttribute.wk_3_2_2:
                ChangeText("wk_3.2.3", MainTextContent.allow);
                CheckDecision(TextAttribute.wk_3_2_3, ScenarioCode.wk_ID_12);
                break;

            case TextAttribute.wk_3_2_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient Temperature", "Temperature sensor", "One week");
                ChangeText("wk_3.3.1", MainTextContent.wk_ID_13[0]);
                CheckComfortableLevel(TextAttribute.wk_3_3_1, ScenarioCode.wk_ID_13);
                break;

            case TextAttribute.wk_3_3_1:
                ChangeText("wk_3.3.2", MainTextContent.allow);
                CheckDecision(TextAttribute.wk_3_3_2, ScenarioCode.wk_ID_13);
                break;

            case TextAttribute.wk_3_3_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Biometric data", "None", "None", "None");
                ChangeText("wk_3.4.1", MainTextContent.wk_ID_14[0]);
                break;

            case TextAttribute.wk_3_4_1:
                ChangeText("wk_3.4.2", MainTextContent.wk_ID_14[1]);
                break;

            case TextAttribute.wk_3_4_2:
                ChangeText("wk_3.4.3", MainTextContent.select);
                SelectIcon("fingerprint scanner", TextAttribute.wk_3_4_3);
                ShowTips(true, "wk_3.4");
                break;

            case TextAttribute.wk_3_4_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Biometric data", "Fingerprint scanner");
                if (answerCorrect)
                {
                    AddAnswer("wk_2.4");
                    textContent = MainTextContent.correct + "<color=green>fingerprint scanner</color>.";
                }
                else
                {
                    textContent = MainTextContent.wrong + "<color=green>fingerprint scanner</color>.";
                }
                ChangeText("wk_3.4.4", textContent);
                ShowTips(false);
                break;

            case TextAttribute.wk_3_4_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Biometric data", "Fingerprint scanner", 
                    "None", "Unlock certain rooms, like the supply closet or the kitchen");
                ChangeText("wk_3.4.5", MainTextContent.wk_ID_14[2]);
                break;

            case TextAttribute.wk_3_4_5:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Fingerprint", "Fingerprint scanner",
                    "Until you no longer work for this company", "Unlock certain rooms, like the supply closet or the kitchen");
                ChangeText("wk_3.4.6", MainTextContent.wk_ID_14[3]);
                CheckComfortableLevel(TextAttribute.wk_3_4_6, ScenarioCode.wk_ID_14);
                break;

            case TextAttribute.wk_3_4_6:
                ChangeText("wk_3.4.7", MainTextContent.allow);
                CheckDecision(TextAttribute.wk_3_4_7, ScenarioCode.wk_ID_14);
                break;

            case TextAttribute.wk_3_4_7:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Fingerprint", "Fingerprint scanner", "Not deleted");
                ChangeText("wk_3.5.1", MainTextContent.wk_ID_15[0]);
                CheckComfortableLevel(TextAttribute.wk_3_5_1, ScenarioCode.wk_ID_15);
                break;

            case TextAttribute.wk_3_5_1:
                ChangeText("wk_3.5.2", MainTextContent.allow);
                CheckDecision(TextAttribute.wk_3_5_2, ScenarioCode.wk_ID_15);
                break;

            case TextAttribute.wk_3_5_2:
                ChangeText("wk_3.6.0", MainTextContent.finishLocation);
                finished = true;
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                AddQuestionState("wk_3");
                Save.SaveByJSON();
                break;

            // this is the start of text for public restroom
            case TextAttribute.pr_1_1_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Video", "Camera", "Not told", 
                    "You are not told what the data is uesd for", "Law enforcement");
                ChangeText("pr_1.1.2", MainTextContent.pr_ID_1[0]);
                // fade in
                fade(true);
                break;

            case TextAttribute.pr_1_1_2:
                ChangeText("pr_1.1.3", MainTextContent.comfortable);
                // fade out
                fade(false);
                CheckComfortableLevel(TextAttribute.pr_1_1_3, ScenarioCode.pr_ID_1);
                break;

            case TextAttribute.pr_1_1_3:
                ChangeText("pr_1.1.4", MainTextContent.allow);
                CheckDecision(TextAttribute.pr_1_1_4, ScenarioCode.pr_ID_1);
                break;

            case TextAttribute.pr_1_1_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Video", "Camera", "Not told", "Improve public safety", "Law enforcement");
                ChangeText("pr_1.2.1", MainTextContent.pr_ID_2[0]);
                break;

            case TextAttribute.pr_1_2_1:
                ChangeText("pr_1.2.2", MainTextContent.comfortable);
                CheckComfortableLevel(TextAttribute.pr_1_2_2, ScenarioCode.pr_ID_2);
                break;

            case TextAttribute.pr_1_2_2:
                ChangeText("pr_1.2.3", MainTextContent.allow);
                CheckDecision(TextAttribute.pr_1_2_3, ScenarioCode.pr_ID_2);
                break;

            case TextAttribute.pr_1_2_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Video", "Camera", "Not deleted", "Improve public safety", "Law enforcement");
                ChangeText("pr_1.3.1", MainTextContent.pr_ID_3[0]);
                break;

            case TextAttribute.pr_1_3_1:
                ChangeText("pr_1.3.2", MainTextContent.comfortable);
                CheckComfortableLevel(TextAttribute.pr_1_3_2, ScenarioCode.pr_ID_3);
                break;

            case TextAttribute.pr_1_3_2:
                ChangeText("pr_1.3.3", MainTextContent.allow);
                CheckDecision(TextAttribute.pr_1_3_3, ScenarioCode.pr_ID_3);
                break;

            case TextAttribute.pr_1_3_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor",
                    "None", "Determine when to switch on and off the lights to reduce costs and save energy", "None");
                ChangeText("pr_1.4.1", MainTextContent.pr_ID_4[0]);
                // second fade in
                fade(true, true);
                break;

            case TextAttribute.pr_1_4_1:
                ChangeText("pr_1.4.2", MainTextContent.pr_ID_4[1]);
                CheckComfortableLevel(TextAttribute.pr_1_4_2, ScenarioCode.pr_ID_4);
                // second fade out
                fade(false, true);
                break;

            case TextAttribute.pr_1_4_2:
                ChangeText("pr_1.4.3", MainTextContent.allow);
                CheckDecision(TextAttribute.pr_1_4_3, ScenarioCode.pr_ID_4);
                break;

            case TextAttribute.pr_1_4_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor", "Not deleted");
                ChangeText("pr_1.5.1", MainTextContent.pr_ID_5[0]);
                CheckComfortableLevel(TextAttribute.pr_1_5_1, ScenarioCode.pr_ID_5);
                break;

            case TextAttribute.pr_1_5_1:
                ChangeText("pr_1.5.2", MainTextContent.allow);
                CheckDecision(TextAttribute.pr_1_5_2, ScenarioCode.pr_ID_5);
                break;

            case TextAttribute.pr_1_5_2:
                ChangeText("pr_1.6.0", MainTextContent.finishScene);
                finished = true;
                AddQuestionState("pr_1");
                Save.SaveByJSON();
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                break;

            case TextAttribute.pr_2_1_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor", "None", "Improve public safety", "Law enforcement");
                ChangeText("pr_2.1.2", MainTextContent.pr_ID_6[0]);
                // fade in
                fade(true);
                break;

            case TextAttribute.pr_2_1_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor", "Not told", "Improve public safety", "Law enforcement");
                ChangeText("pr_2.1.3", MainTextContent.pr_ID_6[1]);
                // fade out
                fade(false);
                CheckComfortableLevel(TextAttribute.pr_2_1_3, ScenarioCode.pr_ID_6);
                break;

            case TextAttribute.pr_2_1_3:
                ChangeText("pr_2.1.4", MainTextContent.allow);
                CheckDecision(TextAttribute.pr_2_1_4, ScenarioCode.pr_ID_6);
                break;

            case TextAttribute.pr_2_1_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Presence", "Presence sensor", "One week", "Improve public safety", "Law enforcement");
                ChangeText("pr_2.2.1", MainTextContent.pr_ID_7[0]);
                CheckComfortableLevel(TextAttribute.pr_2_2_1, ScenarioCode.pr_ID_7);
                break;

            case TextAttribute.pr_2_2_1:
                ChangeText("pr_2.2.2", MainTextContent.allow);
                CheckDecision(TextAttribute.pr_2_2_2, ScenarioCode.pr_ID_7);
                break;

            case TextAttribute.pr_2_2_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Temperature sensor",
                    "Not told", "You are not told what the data is uesd for", "None");
                ChangeText("pr_2.3.1", MainTextContent.pr_ID_8[0]);
                // second fade in
                fade(true, true);
                break;

            case TextAttribute.pr_2_3_1:
                ChangeText("pr_2.3.2", MainTextContent.comfortable);
                CheckComfortableLevel(TextAttribute.pr_2_3_2, ScenarioCode.pr_ID_8);
                // second fade out
                fade(false, true);
                break;

            case TextAttribute.pr_2_3_2:
                ChangeText("pr_2.3.3", MainTextContent.allow);
                CheckDecision(TextAttribute.pr_2_3_3, ScenarioCode.pr_ID_8);
                break;

            case TextAttribute.pr_2_3_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Temperature sensor",
                    "Not deleted", "You are not told what the data is uesd for");
                ChangeText("pr_2.4.1", MainTextContent.pr_ID_9[0]);
                break;

            case TextAttribute.pr_2_4_1:
                ChangeText("pr_2.4.2", MainTextContent.comfortable);
                CheckComfortableLevel(TextAttribute.pr_2_4_2, ScenarioCode.pr_ID_9);
                break;

            case TextAttribute.pr_2_4_2:
                ChangeText("pr_2.4.3", MainTextContent.allow);
                CheckDecision(TextAttribute.pr_2_4_3, ScenarioCode.pr_ID_9);
                break;

            case TextAttribute.pr_2_4_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Ambient temperature", "Temperature sensor",
                     "Not deleted", "Check for abnormal temperatures, which indicate potential hazards, e.g., fire");
                ChangeText("pr_2.5.1", MainTextContent.pr_ID_10[0]);
                CheckComfortableLevel(TextAttribute.pr_2_5_1, ScenarioCode.pr_ID_10);
                break;

            case TextAttribute.pr_2_5_1:
                ChangeText("pr_2.5.2", MainTextContent.allow);
                CheckDecision(TextAttribute.pr_2_5_2, ScenarioCode.pr_ID_10);
                break;

            case TextAttribute.pr_2_5_2:
                ChangeText("pr_2.6.0", MainTextContent.finishScene);
                finished = true;
                AddQuestionState("pr_2");
                Save.SaveByJSON();
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                break;

            case TextAttribute.pr_3_1_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific location", "Smartphone", "None", "Determine possible escape routes");
                ChangeText("pr_3.1.2", MainTextContent.pr_ID_11[0]);
                break;

            case TextAttribute.pr_3_1_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific location", "Smartphone", "Until you leave");
                ChangeText("pr_3.1.3", MainTextContent.pr_ID_11[1]);
                CheckComfortableLevel(TextAttribute.pr_3_1_3, ScenarioCode.pr_ID_11);
                break;

            case TextAttribute.pr_3_1_3:
                ChangeText("pr_3.1.4", MainTextContent.allow);
                CheckDecision(TextAttribute.pr_3_1_4, ScenarioCode.pr_ID_11);
                break;

            case TextAttribute.pr_3_1_4:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific location", "Smartphone", "Not deleted");
                ChangeText("pr_3.2.1", MainTextContent.pr_ID_12[0]);
                CheckComfortableLevel(TextAttribute.pr_3_2_1, ScenarioCode.pr_ID_12);
                break;

            case TextAttribute.pr_3_2_1:
                ChangeText("pr_3.2.2", MainTextContent.allow);
                CheckDecision(TextAttribute.pr_3_2_2, ScenarioCode.pr_ID_12);
                break;

            case TextAttribute.pr_3_2_2:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific location", "Smartwatch",
                    "None", "You are not told what the data is uesd for", "Device manufacturer");
                ChangeText("pr_3.3.1", MainTextContent.pr_ID_13[0]);
                break;

            case TextAttribute.pr_3_3_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific location", "Smartwatch", "One week");
                ChangeText("pr_3.3.2", MainTextContent.pr_ID_13[1]);
                CheckComfortableLevel(TextAttribute.pr_3_3_2, ScenarioCode.pr_ID_13);
                break;

            case TextAttribute.pr_3_3_2:
                ChangeText("pr_3.3.3", MainTextContent.allow);
                CheckDecision(TextAttribute.pr_3_3_3, ScenarioCode.pr_ID_13);
                break;

            case TextAttribute.pr_3_3_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific location", "Smartwatch",
                    "None", "Determine possible escape routes", "Law enforcement");
                ChangeText("pr_3.4.1", MainTextContent.pr_ID_14[0]);
                break;

            case TextAttribute.pr_3_4_1:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific location", "Smartwatch", "One week");
                ChangeText("pr_3.4.2", MainTextContent.pr_ID_14[1]);
                CheckComfortableLevel(TextAttribute.pr_3_4_2, ScenarioCode.pr_ID_14);
                break;

            case TextAttribute.pr_3_4_2:
                ChangeText("pr_3.4.3", MainTextContent.allow);
                CheckDecision(TextAttribute.pr_3_4_3, ScenarioCode.pr_ID_14);
                break;

            case TextAttribute.pr_3_4_3:
                EventDispatcher.instance.DispatchEvent(Checklist.CHECKLIST_UPDATE, "Specific location", "Smartwatch", "One year");
                ChangeText("pr_3.5.1", MainTextContent.pr_ID_15[0]);
                CheckComfortableLevel(TextAttribute.pr_3_5_1, ScenarioCode.pr_ID_15);
                break;

            case TextAttribute.pr_3_5_1:
                ChangeText("pr_3.5.2", MainTextContent.allow);
                CheckDecision(TextAttribute.pr_3_5_2, ScenarioCode.pr_ID_15);
                break;

            case TextAttribute.pr_3_5_2:
                ChangeText("pr_3.6.0", MainTextContent.finishScene);
                finished = true;
                AddQuestionState("pr_3");
                Save.SaveByJSON();
                root.transform.parent.parent.Find("InitArrow").GetChild(0).gameObject.SetActive(true);
                break;
        }
    }

    private static void AddQuestionState(string qustionId)
    {
        QuestionState questionState = new QuestionState();
        questionState.questionId = qustionId;
        questionState.answered = true;
        if (!Player.questionFinished.Exists(questionState => questionState.questionId == qustionId)) Player.questionFinished.Add(questionState);
    }

    private void AddAnswer(string quizID)
    {
        GetCoins getCoins = new GetCoins();
        getCoins.quizID = quizID;
        getCoins.get = true;
        if (!Player.getCoins.Exists(getCoins => getCoins.quizID == quizID))
        {
            Player.getCoins.Add(getCoins);
            Player.AddCorrect();
            Save.SaveByJSON();
            GameObject coin = root.transform.parent.parent.Find("Coin").gameObject;
            if (!coin.GetComponent<AudioSource>()) coin.AddComponent<AudioSource>();
            coin.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/coin");
            coin.SetActive(true);
            coin.GetComponent<Text>().CrossFadeAlpha(0, 2.0f, false);
        }

    }

    private void DestroyCorrectWrongGO()
    {
        Transform tobeDestroyed;
        if (answerCorrect) tobeDestroyed = root.transform.Find("Correct");
        else tobeDestroyed = root.transform.Find("Wrong");
        if (tobeDestroyed) GameObject.Destroy(tobeDestroyed.gameObject);
    }

    private void fade(bool fadeIn, bool second = false)
    {
        GameObject circle;
        Image circleImg;
        GameObject arrow;
        Image arrowImg;

        // if true, find the second one
        if (second) circle = root.transform.parent.parent.Find("Circle2").gameObject;
        else circle = root.transform.parent.parent.Find("Circle").gameObject;
        if (second) arrow = root.transform.parent.parent.Find("Pointer2").gameObject;
        else arrow = root.transform.parent.parent.Find("Pointer").gameObject;

        if (fadeIn)
        {
            if (!circle.GetComponent<AudioSource>()) circle.AddComponent<AudioSource>();
            circle.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/flush");
            circle.SetActive(true);
            circleImg = circle.GetComponent<Image>();
            circleImg.canvasRenderer.SetAlpha(0.0f);
            circleImg.CrossFadeAlpha(1.0f, 1.0f, false);

            if (!arrow.GetComponent<AudioSource>()) arrow.AddComponent<AudioSource>();
            arrow.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/flush");
            arrow.SetActive(true);
            arrowImg = arrow.GetComponent<Image>();
            arrowImg.canvasRenderer.SetAlpha(0.0f);
            arrowImg.CrossFadeAlpha(1.0f, 1.0f, false);
        }
        else
        {
            circleImg = circle.GetComponent<Image>();
            circleImg.CrossFadeAlpha(0.0f, 1.0f, false);

            arrowImg = arrow.GetComponent<Image>();
            arrowImg.CrossFadeAlpha(0.0f, 1.0f, false);
        }

    }

    /// <param name="newText"></param> next text to show up
    /// <param name="textContent"></param> string to show and put in the backlog
    private void ChangeText(string newText, string textContent)
    {
        curText.SetActive(false);
        nextTextTF = root.transform.Find(newText);
        if (nextTextTF) GameObject.Destroy(nextTextTF.gameObject);
        GameObject text = Instantiate(TextPrefab, root.transform);
        text.name = newText;
        curText = text.gameObject;
        curText.SetActive(true);
        tex = curText.GetComponent<Text>();
        tex.text = textContent;
        Backlog.backlog.Add(textContent);
    }

    private void ChangeTextNew(string textIn, string textOut)
    {
        curText = root.transform.Find(textOut).gameObject;
        nextTextTF = root.transform.Find(textIn);
        curText.SetActive(false);
        nextTextTF.gameObject.SetActive(true);
    }

    private void CheckComfortableLevel(TextAttribute textIndex, string scenarioID)
    {
        GameObject[] comfortableBtns = new GameObject[5];
        string[] comfortableNames = { "Very Uncomfortable", "Uncomfortable", "Neither comfortable nor uncomfortable", "Comfortable", "Very Comfortable" };
        
        // create comfortable level btn
        GameObject comfortableLevel = new GameObject("ComfortableLevel");
        comfortableLevel.transform.SetParent(curText.transform);
        

        for (int i = 0; i < comfortableNames.Length; i++)
        {
            // set btn
            comfortableBtns[i] = new GameObject(comfortableNames[i]);
            comfortableBtns[i].transform.SetParent(comfortableLevel.transform);
            comfortableBtns[i].AddComponent<GeneralIconButton>();
            comfortableBtns[i].AddComponent<AudioSource>();
            comfortableBtns[i].AddComponent<Image>();
            comfortableBtns[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Button_Demo_Light/Btn_Rectangle04_Green");
            comfortableBtns[i].GetComponent<Image>().type = Image.Type.Sliced;
            comfortableBtns[i].GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/Btn_SE3");
            comfortableBtns[i].GetComponent<AudioSource>().playOnAwake = false;
            comfortableBtns[i].GetComponent<RectTransform>().position = new Vector3(-731 + 315 * i, 380, 0);
            comfortableBtns[i].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 230);
            comfortableBtns[i].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 200);

            // set text
            GameObject text = new GameObject("Text");
            text.transform.SetParent(comfortableBtns[i].transform);
            
            text.AddComponent<Text>();
            text.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
            text.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            text.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            text.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            text.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            text.GetComponent<Text>().text = comfortableNames[i];
            text.GetComponent<Text>().color = Color.black;
            text.GetComponent<Text>().font = Resources.GetBuiltinResource<Font>("Arial.ttf");

            // set Neither nor font to 30
            if (i == 2) text.GetComponent<Text>().fontSize = 30;
            else text.GetComponent<Text>().fontSize = 33;

            // add listerner
            int temp = i;
            comfortableBtns[i].GetComponent<GeneralIconButton>().onClick.AddListener(() =>
            {
                PrivacyQuestion privacyQuestion = new PrivacyQuestion();
                privacyQuestion.scenarioID = scenarioID;
                privacyQuestion.comfortable = temp;
                if (!Player.answers.Exists(PrivacyQuestion => PrivacyQuestion.scenarioID == scenarioID))
                {
                    Player.answers.Add(privacyQuestion);
                }
                else
                {
                    Player.answers.Find(PrivacyQuestion => PrivacyQuestion.scenarioID == scenarioID).comfortable = temp;
                }
                Save.SaveByJSON();
                // 必须先add再换下一个text，否则的话下一个text的backlog会出现在add之前
                Backlog.backlog.Add("You chose: " + "<color=purple>" + comfortableBtns[temp].name + "</color>");
                MainText(textIndex);
                GameObject.Destroy(comfortableLevel);
            });
        }

        comfortableLevel.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);

    }

    private void CheckDecision(TextAttribute textIndex, string scenarioID)
    {
        // set btn
        GameObject decision = new GameObject("decision");
        GameObject allow = new GameObject("allow");
        GameObject deny = new GameObject("deny");
        decision.transform.SetParent(curText.transform);
        allow.transform.SetParent(decision.transform);
        deny.transform.SetParent(decision.transform);

        allow.AddComponent<GeneralIconButton>();
        allow.AddComponent<Image>();
        allow.AddComponent<AudioSource>();
        allow.GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("Sprite/Icon/yes-no")[0];
        allow.GetComponent<Image>().type = Image.Type.Sliced;
        allow.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/Btn_SE3");
        allow.GetComponent<AudioSource>().playOnAwake = false;
        allow.GetComponent<RectTransform>().position = new Vector3(-416, 400, 0);
        allow.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 230);
        allow.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);

        allow.GetComponent<GeneralIconButton>().onClick.AddListener(()=>
        {
            Player.answers.Find(PrivacyQuestion => PrivacyQuestion.scenarioID == scenarioID).decision = 1;
            Save.SaveByJSON();
            Backlog.backlog.Add("You chose: <color=green>Allow data collection</color>");
            MainText(textIndex);
            GameObject.Destroy(decision);
        });

        deny.AddComponent<GeneralIconButton>();
        deny.AddComponent<Image>();
        deny.AddComponent<AudioSource>();
        deny.GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("Sprite/Icon/yes-no")[1];
        deny.GetComponent<Image>().type = Image.Type.Sliced;
        deny.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/Btn_SE3");
        deny.GetComponent<AudioSource>().playOnAwake = false;
        deny.GetComponent<RectTransform>().position = new Vector3(244, 400, 0);
        deny.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 230);
        deny.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);

        deny.GetComponent<GeneralIconButton>().onClick.AddListener(() =>
        {
            Player.answers.Find(PrivacyQuestion => PrivacyQuestion.scenarioID == scenarioID).decision = 0;
            Save.SaveByJSON();
            Backlog.backlog.Add("You chose: <color=red>Deny data collection</color>");
            MainText(textIndex);
            GameObject.Destroy(decision);
        });

        decision.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
    }

    private void SelectIcon(string name, TextAttribute textIndex)
    {
        GameObject iconParent = new GameObject("iconParent");
        iconParent.transform.SetParent(curText.transform);

        string[] iconName = { "headphone", "iris scanner", "presence sensor", "fingerprint scanner", 
            "facial recognition", "temperature sensor", "computer", "camera", "smartphone", "smartwatch" };
        System.Random rnd = new System.Random();
        GameObject[] icons = new GameObject[5];
        int[] index = new int[iconName.Length];
        for (int i = 0; i < iconName.Length; i++)
        {
            index[i] = i;
        }
        int idx; // 获取index数组中索引为idx位置的数据，赋给结果数组array的j索引位置
        int site = iconName.Length;  // 设置上限
        List<string> names = new List<string>();
        for (int j = 0; j < icons.Length; j++)
        {
            idx = rnd.Next(0, site - 1);  // 生成随机索引数
            icons[j] = new GameObject(iconName[index[idx]]); // 在随机索引位置取出一个数，保存到结果数组 
            index[idx] = index[site - 1];   // 作废当前索引位置数据，并用数组的最后一个数据代替之
            site--;                         // 索引位置的上限减一（弃置最后一个数据）

            // set btn
            icons[j].transform.SetParent(iconParent.transform);
            icons[j].AddComponent<GeneralIconButton>();
            icons[j].AddComponent<AudioSource>();
            icons[j].AddComponent<Image>();
            icons[j].GetComponent<Image>().sprite = Resources.Load<Sprite>("Button_Demo_Light/Btn_Rectangle04_Sky");
            icons[j].GetComponent<Image>().type = Image.Type.Sliced;
            icons[j].GetComponent<Image>().color = new Vector4(1, 1, 1, 233f / 255f);
            icons[j].GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/Btn_SE3");
            icons[j].GetComponent<AudioSource>().playOnAwake = false;
            icons[j].GetComponent<RectTransform>().position = new Vector3(-731 + 315 * j, 380, 0);
            icons[j].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 230);
            icons[j].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 230);

            // set image
            GameObject image = new GameObject("Image");
            image.transform.SetParent(icons[j].transform);
            image.AddComponent<Image>();
            image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/Icon/" + icons[j].name);
            image.GetComponent<Image>().type = Image.Type.Sliced;
            image.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 210);
            image.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 210);
            image.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);

            names.Add(icons[j].name);

            int iconIndex = j;
            icons[j].GetComponent<GeneralIconButton>().onClick.AddListener(() => 
            {
                Backlog.backlog.Add("You chose: " + "<color=blue>" + icons[iconIndex].name + "</color>");
                if (name == icons[iconIndex].name)
                {
                    GameObject correct = new GameObject("Correct");
                    correct.transform.SetParent(root.transform);
                    correct.AddComponent<Image>();
                    correct.AddComponent<AudioSource>();
                    correct.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/correct");
                    correct.GetComponent<AudioSource>().Play();
                    correct.GetComponent<Image>().sprite = Resources.Load<Sprite>("Demo_Icon/Icon_WhiteIcon_check_s");
                    correct.GetComponent<Image>().color = Color.green;
                    correct.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                    correct.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300);
                    correct.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 300);
                    correct.GetComponent<Image>().CrossFadeAlpha(0.0f, 2.0f, false);

                    answerCorrect = true;
                    MainText(textIndex);
                }
                else
                {
                    GameObject wrong = new GameObject("Wrong");
                    wrong.transform.SetParent(root.transform);
                    wrong.AddComponent<Image>();
                    wrong.AddComponent<AudioSource>();
                    wrong.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/wrong");
                    wrong.GetComponent<AudioSource>().Play();
                    wrong.GetComponent<Image>().sprite = Resources.Load<Sprite>("Demo_Icon/Icon_WhiteIcon_Close");
                    wrong.GetComponent<Image>().color = Color.red;
                    wrong.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                    wrong.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300);
                    wrong.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 300);
                    wrong.GetComponent<Image>().CrossFadeAlpha(0.0f, 2.0f, false);

                    answerCorrect = false;
                    MainText(textIndex);
                }
                GameObject.Destroy(iconParent);
            }); 
        }

        // change icon if there is no correct answer
        if (!names.Contains(name))
        {
            int change = rnd.Next(icons.Length);
            icons[change].name = name;
            icons[change].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/Icon/" + name);
        }
        iconParent.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
    }

    private void ShowTips(bool enable, string quizID = null)
    {
        Transform tipsTF = root.transform.parent.parent.Find("Tips");
        if(tipsTF)
        {
            if (enable)
            {
                tipsTF.gameObject.SetActive(true);
                tipsTF.GetComponent<Tips>().SetEvent(quizID);
            }
            else tipsTF.gameObject.SetActive(false);
        }
    }

    private void ResetTip()
    {
        Transform tipsTF = root.transform.parent.parent.Find("Tips");
        if (tipsTF)
        {
            tipsTF.GetComponent<Tips>().ResetLevel();
        }
    }
}