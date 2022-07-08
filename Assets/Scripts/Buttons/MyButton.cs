using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// custom Button
/// </summary>
public class MyButton : Button
{
    protected float R;
    protected float G;
    protected float B;
    protected float A;
    protected float discountFactorDown = 210f / 255f;
    protected float discountFactorEnter = 248f / 255f;


    public override void OnPointerDown(PointerEventData eventData)
    {
        R = this.transform.GetComponent<Image>().color.r * discountFactorDown;
        G = this.transform.GetComponent<Image>().color.g * discountFactorDown;
        B = this.transform.GetComponent<Image>().color.b * discountFactorDown;
        A = this.transform.GetComponent<Image>().color.a;
        Image image = this.gameObject.GetComponent<Image>();
        image.color = new Vector4(R, G, B, A);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        R = this.transform.GetComponent<Image>().color.r / discountFactorDown;
        G = this.transform.GetComponent<Image>().color.g / discountFactorDown;
        B = this.transform.GetComponent<Image>().color.b / discountFactorDown;
        A = this.transform.GetComponent<Image>().color.a;
        Image image = this.gameObject.GetComponent<Image>();
        image.color = new Vector4(R, G, B, A);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        R = this.transform.GetComponent<Image>().color.r * discountFactorEnter;
        G = this.transform.GetComponent<Image>().color.g * discountFactorEnter;
        B = this.transform.GetComponent<Image>().color.b * discountFactorEnter;
        A = this.transform.GetComponent<Image>().color.a;
        Image image = this.gameObject.GetComponent<Image>();
        image.color = new Vector4(R, G, B, A);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        R = this.transform.GetComponent<Image>().color.r / discountFactorEnter;
        G = this.transform.GetComponent<Image>().color.g / discountFactorEnter;
        B = this.transform.GetComponent<Image>().color.b / discountFactorEnter;
        A = this.transform.GetComponent<Image>().color.a;
        Image image = this.gameObject.GetComponent<Image>();
        image.color = new Vector4(R, G, B, A);
    }
}
