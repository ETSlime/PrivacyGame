using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class ResultText : MonoBehaviour, IPointerClickHandler
{
    public GameObject TextPrefab;

    public string str;
    private Text tex;
    private int max_speed;
    private int speed;
    private int index = 0;
    private string str1 = "";
    private bool ison = true;


    // Start is called before the first frame update
    private void Start()
    {
        tex = this.GetComponent<Text>();
        // if tex is not null
        if (tex)
        {
            str = tex.text;
            tex.text = "";
        }
        max_speed = 3;
        speed = 3;
    }

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
        SpeedUp();
    }

    public void SpeedUp()
    {
        // set maximum speed
        max_speed = 0;
    }
}
