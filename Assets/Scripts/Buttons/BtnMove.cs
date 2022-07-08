using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class BtnMove : MonoBehaviour
{
    private float repeatTime = 0;
    private float moveSpeed = 15;
    private float repeatRate = 0.01f;
    private int BtnIndex = -1;
    private int moveAmount = 48;
    private List<Transform> BtnTransforms;
    private AudioSource Audio;
    private void Start()
    {
        BtnTransforms = new List<Transform>();
        this.gameObject.AddComponent<AudioSource>();
        Audio = this.GetComponent<AudioSource>();
        Audio.clip = Resources.Load<AudioClip>("SE/popUp");
        Audio.playOnAwake = false;
        Button[] buttons = this.GetComponentsInChildren<Button>();
        foreach (var button in buttons)
        {
            BtnTransforms.Add(button.transform);
        }
        InvokeRepeating("Up", 0, repeatRate);

        // Ìø¹ýmove
        Transform image = this.transform.parent.Find("Image");
        image.gameObject.AddComponent<Button>();
        image.GetComponent<Button>().onClick.AddListener(() =>
        {
            CancelInvoke("Up");
            for(int i = 0; i < BtnTransforms.Count; i++)
            {
                BtnTransforms[i].localPosition = new Vector3(0, 720 + i * -120, 0);
            }

        });
    }
    private void Up()
    {
        if (repeatTime % moveAmount == 0 && repeatTime / moveAmount < BtnTransforms.Count)
        {
            
            Audio.Play();
            BtnIndex++;
        }

        BtnTransforms[BtnIndex].Translate(Vector2.up * moveSpeed, Space.World);
        repeatTime++;
        if (repeatTime / moveAmount == BtnTransforms.Count)
        {
            CancelInvoke("Up");
            repeatTime = 0;
        }
    }
}
