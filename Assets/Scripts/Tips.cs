using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class Tips : MonoBehaviour
{
    private GeneralIconButton tipsBtn;
    // index of tips for each quiz
    private int tipsLevel;
    private string quizID;
    [SerializeField]
    private GameObject warningTextPrefab;


    private void Start()
    {
        tipsLevel = 0;
        tipsBtn = this.transform.GetChild(0).GetComponent<GeneralIconButton>();
        tipsBtn.onClick.AddListener(TipsEvent);

    }

    // set current question id
    public void SetEvent(string quizID)
    {
        this.quizID = quizID;
    }

    // tips btn listener func.
    private void TipsEvent()
    {
        if (tipsLevel == 2)
        {
            ShowTipsContent();
            return;
        }
        // check if player has bought tips
        if (!Player.tipStates.Exists(tipStates => tipStates.quizID == quizID && tipStates.tips[tipsLevel] == true))
        {
            int[] imageSize = { 780, 400 };
            int[] textSize = { 730, 200 };
            string content;

            if (tipsLevel == 0) content = "You can use one chance of hints to get some help. You have " +
                    "<color=red>" + Player.tips + "</color>" + " chance(s) of tips available.";
            else content = "Still get stuck? You can use one chance of hints once more to get the correct answer. You have " +
                    "<color=red>" + Player.tips + "</color>" + " chance(s) of tips available.";
            // show tips
            if (!this.transform.Find("ConfirmImage"))
                ConfirmationPanel.CreatePanel(this.transform, content, ShowTips, imageSize, textSize);
        }
        else
        {
            if (!this.transform.Find("Warning Text"))
            {
                ShowTipsContent();
                GameObject warningText = Instantiate(warningTextPrefab);
                warningText.name = "Warning Text";
                warningText.transform.SetParent(this.transform);
                warningText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                warningText.transform.GetChild(1).GetComponent<MyButton>().onClick.AddListener(() => GameObject.Destroy(warningText.gameObject));
                warningText.transform.GetChild(0).GetComponent<Text>().text = "You have already bought this tip. You can check the hints directly.";
            }
        }

    }
    private void ShowTips()
    {
        // check if player has enough tips
        if (Player.tips == 0)
        {
            // price of current tips
            int curPrice = ShopInit.tipsPrice + Player.tipsBought * ShopInit.tipsFactor;

            // call back func. for buying tips
            void buy()
            {
                
                if (!this.transform.Find("Warning Text"))
                {
                    GameObject warningText = Instantiate(warningTextPrefab);
                    warningText.name = "Warning Text";
                    warningText.transform.SetParent(this.transform);
                    warningText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                    warningText.transform.GetChild(1).GetComponent<MyButton>().onClick.AddListener(() => GameObject.Destroy(warningText.gameObject));

                    // check if player has enough points
                    if (Player.points >= curPrice)
                    {
                        Player.points -= curPrice;
                        Player.tipsBought++;
                        Player.tips++;
                        warningText.transform.GetChild(0).GetComponent<Text>().text = "Nice! Now you get one tip chance. Come on and have a try!";
                    }
                }
            }

            string content = "Sorry, you don't have enough chance of tips. Do you want to quickly buy one? " +
                "The current price for one chance of tip is: " + "<color=red>" + curPrice + "</color>";
            int[] imageSize = { 900, 400 };
            int[] textSize = { 850, 150 };
            ConfirmationPanel.CreatePanel(this.transform, content, buy, imageSize, textSize);
        }
        else
        {
            // add tip to player
            TipState tipState = new TipState();
            tipState.quizID = quizID;
            tipState.tips[tipsLevel] = true;
            Player.tipStates.Add(tipState);
            Player.tips--;
            ShowTipsContent();
        }

    }

    private void ShowTipsContent()
    {
        // show tips by its id and level
        GameObject tipTextGO;
        tipTextGO = SetTipText();
        switch (quizID)
        {
            case "cs_2.1":
                switch(tipsLevel)
                {
                    case 0:
                        tipTextGO.transform.GetChild(0).GetComponent<Text>().text = "Considering that the function of this IoT device is collecting facial information, " +
                            "it mush have sensors in order to detect customer's faces.";
                        break;
                    case 1:
                    case 2:
                        tipTextGO.transform.GetChild(0).GetComponent<Text>().text = "The correct answer is <color=blue>facial recognition</color>.";
                        break;
                }
                break;

            case "cs_3.4":
                switch (tipsLevel)
                {
                    case 0:
                        tipTextGO.transform.GetChild(0).GetComponent<Text>().text = "Considering that this IoT device aims to determine whether there is someone presenting, " +
                            "it mush have sensors in order to detect the presence of people.";
                        break;
                    case 1:
                    case 2:
                        tipTextGO.transform.GetChild(0).GetComponent<Text>().text = "The correct answer is <color=blue>presence sensor</color>.";
                        break;
                }
                break;

            case "lb_2.3":
                switch (tipsLevel)
                {
                    case 0:
                        tipTextGO.transform.GetChild(0).GetComponent<Text>().text = "Think about what kind of device is requiring you to touch it, " +
                            "and you usually use what to touch the device";
                        break;
                    case 1:
                    case 2:
                        tipTextGO.transform.GetChild(0).GetComponent<Text>().text = "The correct answer is <color=blue>fingerprint scanner</color>.";
                        break;
                }
                break;

            case "lb_3.3":
                switch (tipsLevel)
                {
                    case 0:
                        tipTextGO.transform.GetChild(0).GetComponent<Text>().text = "Notice that your <color=green>presence</color> will be detected," +
                            "it is obvious that it has a kind of sensor to detect people.";
                        break;
                    case 1:
                    case 2:
                        tipTextGO.transform.GetChild(0).GetComponent<Text>().text = "The correct answer is <color=blue>presence sensor</color>.";
                        break;
                }
                break;

            case "hm_1.1":
                switch (tipsLevel)
                {
                    case 0:
                        tipTextGO.transform.GetChild(0).GetComponent<Text>().text = "Think about how does this device know that you are in the room and turn on the " +
                            "lights for you. It can definitely detects your presence.";
                        break;
                    case 1:
                    case 2:
                        tipTextGO.transform.GetChild(0).GetComponent<Text>().text = "The correct answer is <color=blue>presence sensor</color>.";
                        break;
                }
                break;

            case "hm_1.4":
                switch (tipsLevel)
                {
                    case 0:
                        tipTextGO.transform.GetChild(0).GetComponent<Text>().text = "Remember that it can monitor the room and take record. " +
                            "Think about what kind of data does it collect? (video)";
                        break;
                    case 1:
                    case 2:
                        tipTextGO.transform.GetChild(0).GetComponent<Text>().text = "The correct answer is <color=blue>camera</color>.";
                        break;
                }
                break;

            case "fh_2.1":
                switch (tipsLevel)
                {
                    case 0:
                        tipTextGO.transform.GetChild(0).GetComponent<Text>().text = "Think about what kind of device is sensitive to temperature. " +
                            "What characteristic is required to determine whether to turn on the air condioner?";
                        break;
                    case 1:
                    case 2:
                        tipTextGO.transform.GetChild(0).GetComponent<Text>().text = "The correct answer is <color=blue>temperature sensor</color>.";
                        break;
                }
                break;
        }
        // increase current tips level
        if (tipsLevel < 2) tipsLevel++;
    }

    private GameObject SetTipText()
    {
        if (this.transform.Find("TipText"))
        {
            GameObject.Destroy(this.transform.Find("TipText").gameObject);
        }
        GameObject warningText = Instantiate(warningTextPrefab);
        warningText.name = "TipText";
        warningText.transform.SetParent(this.transform);
        warningText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        if (tipsLevel == 0)
        {
            warningText.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 800);
            warningText.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 450);
            warningText.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 650);
            warningText.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 250);
        }
        else
        {
            warningText.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 550);
            warningText.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 350);
            warningText.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 450);
            warningText.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 160);
            warningText.transform.GetChild(1).GetComponent<RectTransform>().localPosition = new Vector3(0, -70, 0);
        }

        warningText.transform.GetChild(1).GetComponent<MyButton>().onClick.AddListener(() => GameObject.Destroy(warningText.gameObject));
        return warningText;
    }

    public void ResetLevel()
    {
        tipsLevel = 0;
    }

}
