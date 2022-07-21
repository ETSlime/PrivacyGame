using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class ConfirmationPanel
{
    // the function that being called when Yes button is pressed
    public delegate void MyDelegate();

    static public void CreatePanel(Transform parent, string content, MyDelegate fun, int[] imageSize = null, int[] textSize = null, MyDelegate fun2 = null)
    {
        if (imageSize == null)
        {
            imageSize = new int[2]{600, 300};
        }
        if (textSize == null)
        {
            textSize = new int[2]{460, 100};
        }
        // define confirmation panel
        GameObject confirmImageGO = new GameObject("ConfirmImage");
        GameObject confirmTextGO = new GameObject("ConfirmText");
        GameObject confirmBtnYesGO = new GameObject("Yes");
        GameObject confirmBtnNoGO = new GameObject("No");
        GameObject confirmBtnYesTextGO = new GameObject("Text");
        GameObject confirmBtnNoTextGO = new GameObject("Text");


        // set relationship
        confirmImageGO.transform.SetParent(parent);
        confirmTextGO.transform.SetParent(confirmImageGO.transform);
        confirmBtnYesGO.transform.SetParent(confirmImageGO.transform);
        confirmBtnNoGO.transform.SetParent(confirmImageGO.transform);
        confirmBtnYesTextGO.transform.SetParent(confirmBtnYesGO.transform);
        confirmBtnNoTextGO.transform.SetParent(confirmBtnNoGO.transform);

        // set image
        confirmImageGO.AddComponent<Image>();
        Image confirmSprite = confirmImageGO.GetComponent<Image>();
        confirmSprite.sprite = Resources.Load<Sprite>("Sprite/CardFrame02,03_BackFrame_n_Blue");
        RectTransform confirmImageRTF = confirmImageGO.GetComponent<RectTransform>();
        // use anchoredposition instead of position
        confirmImageRTF.anchoredPosition = new Vector3(0, 0, 0);
        confirmImageRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, imageSize[0]);
        confirmImageRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, imageSize[1]);

        // set confirmText
        confirmTextGO.AddComponent<Text>();
        Text confirmText = confirmTextGO.GetComponent<Text>();
        confirmText.text = content;
        confirmText.font = Resources.Load<Font>("Fonts/Quicksand-Bold");
        confirmText.fontSize = 40;
        confirmText.color = Color.black;
        RectTransform confirmTextRTF = confirmTextGO.GetComponent<RectTransform>();
        confirmTextRTF.anchoredPosition = new Vector3(9, 54, 0);
        confirmTextRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, textSize[0]);
        confirmTextRTF.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, textSize[1]);

        // set button
        confirmBtnYesGO.AddComponent<MyButton>();
        confirmBtnYesGO.AddComponent<Image>();
        confirmBtnYesGO.AddComponent<AudioSource>();

        confirmBtnNoGO.AddComponent<MyButton>();
        confirmBtnNoGO.AddComponent<Image>();
        confirmBtnNoGO.AddComponent<AudioSource>();

        confirmBtnYesGO.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/warning");
        confirmBtnYesGO.GetComponent<AudioSource>().playOnAwake = false;
        confirmBtnYesGO.GetComponent<Image>().sprite = Resources.Load<Sprite>("Frame_Custom/TabMenuFrame_White");
        confirmBtnYesGO.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
        confirmBtnYesGO.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 50);
        confirmBtnYesGO.GetComponent<Image>().type = Image.Type.Sliced;
        confirmBtnYesGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(-117, -72);

        confirmBtnNoGO.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/Btn_SE");
        confirmBtnNoGO.GetComponent<AudioSource>().playOnAwake = false;
        confirmBtnNoGO.GetComponent<Image>().sprite = Resources.Load<Sprite>("Frame_Custom/TabMenuFrame_White");
        confirmBtnNoGO.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150);
        confirmBtnNoGO.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 50);
        confirmBtnNoGO.GetComponent<Image>().type = Image.Type.Sliced;
        confirmBtnNoGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(117, -72);

        // set button text
        confirmBtnYesTextGO.AddComponent<Text>();
        confirmBtnNoTextGO.AddComponent<Text>();
        confirmBtnYesTextGO.GetComponent<Text>().text = "Yes";
        confirmBtnYesTextGO.GetComponent<Text>().color = Color.black;
        confirmBtnYesTextGO.GetComponent<Text>().font = Resources.Load<Font>("Fonts/Quicksand-Bold");
        confirmBtnYesTextGO.GetComponent<Text>().fontSize = 30;
        confirmBtnYesTextGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(22, -29);
        confirmBtnNoTextGO.GetComponent<Text>().text = "No";
        confirmBtnNoTextGO.GetComponent<Text>().color = Color.black;
        confirmBtnNoTextGO.GetComponent<Text>().font = Resources.Load<Font>("Fonts/Quicksand-Bold");
        confirmBtnNoTextGO.GetComponent<Text>().fontSize = 30;
        confirmBtnNoTextGO.GetComponent<RectTransform>().anchoredPosition = new Vector2(31, -29);

        // add listener
        confirmBtnYesGO.GetComponent<MyButton>().onClick.AddListener(() =>
        {
            confirmBtnYesGO.GetComponent<AudioSource>().Play();
            GameObject.Destroy(confirmImageGO);
            fun();
        });
        confirmBtnNoGO.GetComponent<MyButton>().onClick.AddListener(() =>
        {
            confirmBtnNoGO.GetComponent<AudioSource>().Play();
            GameObject.Destroy(confirmImageGO);
            if (fun2 != null)
                fun2();
        });
    }
}
