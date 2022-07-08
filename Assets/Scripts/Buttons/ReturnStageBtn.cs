using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
///
/// </summary>
public class ReturnStageBtn : MyButton, IPointerClickHandler
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        R = 248f / 255f;
        G = 248f / 255f;
        B = 248f / 255f;
        A = 255f / 255f;
        Image image = this.gameObject.GetComponent<Image>();
        image.color = new Vector4(R, G, B, A);

        this.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 0);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        R = 255f / 255f;
        G = 255f / 255f;
        B = 255f / 255f;
        A = 255f / 255f;
        Image image = this.gameObject.GetComponent<Image>();
        image.color = new Vector4(R, G, B, A);

        this.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 0);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!this.GetComponent<AudioSource>()) this.gameObject.AddComponent<AudioSource>();
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>("SE/Btn_SE");
        audio.playOnAwake = false;
        audio.Play();

        void load()
        {
            LoadGame.LoadScene("Select Location");
        }
        int[] imageSize = { 800, 300 };
        int[] textSize = { 720, 150 };
        string content;
        switch (SceneManager.GetActiveScene().name)
        {
            case "Shop":
                content = "Do you want to return to the location selection stage? Your data will be autosaved.";
                break;
            default:
                content = "Do you want to return to the location selection stage? All answers will be saved automatically.";
                break;
        }
        if (!this.transform.parent.Find("ConfirmImage")) ConfirmationPanel.CreatePanel(this.transform.parent, content, load, imageSize, textSize);
    }
}
