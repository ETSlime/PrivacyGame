using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class Backlog : MonoBehaviour
{
    public static List<string> backlog;
    private Transform chatFrame;
    private Transform content;

    private void Start()
    {
        backlog = new List<string>();
        chatFrame = this.transform.parent;
        content = chatFrame.Find("Backlog View").GetChild(0).GetChild(0);

        TextCtrl firstText = chatFrame.Find("Text_Base").GetChild(0).GetComponent<TextCtrl>();
        // 如果没读出来，就不放进去
        if(firstText.str.Length != 0) backlog.Add(firstText.str);
    }

    public void Init()
    {
        int textHeight = 300;
        int slotHeight = 280;
        for (int i = 0; i < backlog.Count; i++)
        {
            GameObject textImgGO = new GameObject(i.ToString());
            textImgGO.transform.SetParent(content.transform);
            Image textImg = textImgGO.AddComponent<Image>();
            textImg.sprite = Resources.Load<Sprite>("Frame_Demo_Light/PassFrame01_d");
            textImg.type = Image.Type.Sliced;
            textImg.color = new Vector4(248f / 255f, 235f / 255f, 151f / 255f, 186f / 255f);
            textImg.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1123);
            textImg.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotHeight);

            GameObject textGO = new GameObject("Text");
            textGO.transform.SetParent(textImgGO.transform);
            Text tex = textGO.AddComponent<Text>();
            tex.text = backlog[i];
            tex.fontSize = 40;
            tex.font = Resources.Load<Font>("Fonts/Rubik-Medium");
            tex.color = Color.black;
            tex.alignment = TextAnchor.MiddleLeft;
            tex.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            tex.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1000);
            tex.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, textHeight);
        }

        // set content size
        RectTransform contentRTF = content.GetComponent<RectTransform>();
        // sizeDelta = (n-1)*(Spacing X+CellSize X)
        float size = (backlog.Count - 0) * (20 + slotHeight);
        contentRTF.sizeDelta = new Vector2(0, size);

    }
}