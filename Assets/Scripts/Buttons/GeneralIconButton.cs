using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
///
/// </summary>
public class GeneralIconButton : MyButton
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        R = this.transform.GetComponent<Image>().color.r * discountFactorEnter;
        G = this.transform.GetComponent<Image>().color.g * discountFactorEnter;
        B = this.transform.GetComponent<Image>().color.b * discountFactorEnter;
        A = this.transform.GetComponent<Image>().color.a;
        Image image = this.gameObject.GetComponent<Image>();
        image.color = new Vector4(R, G, B, A);

        if(!this.GetComponent<AudioSource>()) this.gameObject.AddComponent<AudioSource>();
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>("SE/Btn_SE3");
        audio.playOnAwake = false;
        audio.Play();

        this.GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 0);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        R = this.transform.GetComponent<Image>().color.r / discountFactorEnter;
        G = this.transform.GetComponent<Image>().color.g / discountFactorEnter;
        B = this.transform.GetComponent<Image>().color.b / discountFactorEnter;
        A = this.transform.GetComponent<Image>().color.a;
        Image image = this.gameObject.GetComponent<Image>();
        image.color = new Vector4(R, G, B, A);

        this.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 0);
    }
}
