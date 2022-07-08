using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
///
/// </summary>
public class GameInit : MonoBehaviour
{
    private Transform canvas;
    private bool isActivate;
    private GeneralIconButton homeBtn;
    private GeneralIconButton pauseBtn;
    private GeneralIconButton continueBtn;
    [SerializeField]
    private GameObject smartphonePrefab;
    [SerializeField]
    private GameObject smartwatchPrefab;
    [SerializeField]
    private GameObject tabletPrefab;

    // score *3
    private GameObject smartphone;
    // time freeze
    private GameObject smartwatch;
    // boom!
    private GameObject tablet;

    private float repeatRate = 0.1f;
    private float smartphoneGauge = 35;
    private float smartwatchGauge = 50;
    private float tabletCD = 50;

    private GeneralIconButton smartphoneBtn;
    private GeneralIconButton smartwatchBtn;
    private GeneralIconButton tabletBtn;

    private void Start()
    {
        isActivate = true;

        canvas = this.transform.parent;
        Transform homeBtnTF = canvas.GetChild(0).Find("HomeButton");
        Transform pauseTF = canvas.GetChild(0).Find("Pause");
        Transform continueTF = canvas.GetChild(0).Find("Continue");
        Transform mask = canvas.GetChild(0).Find("Mask");
        homeBtn = homeBtnTF.gameObject.AddComponent<GeneralIconButton>();
        pauseBtn = pauseTF.gameObject.AddComponent<GeneralIconButton>();
        continueBtn = continueTF.gameObject.AddComponent<GeneralIconButton>();

        this.gameObject.AddComponent<AudioSource>();
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>("SE/Btn_SE4");

        // home btn listener func.
        homeBtn.onClick.AddListener(() =>
        {
            audio.Play();
            isActivate = false;
            string content = "Do you want to return to the location selection stage?";
            void Load()
            {
                LoadGame.LoadScene("Select Location");
            }
            int[] imageSize = { 600, 300 };
            int[] textSize = { 500, 150 };
            ConfirmationPanel.CreatePanel(canvas, content, Load, imageSize, textSize);
            homeBtn.interactable = false;
            pauseBtn.interactable = false;
        });

        // pause btn listener func.
        pauseBtn.onClick.AddListener(() =>
        {
            audio.Play();
            pauseBtn.gameObject.SetActive(false);
            continueBtn.gameObject.SetActive(true);
            mask.gameObject.SetActive(true);
            if (smartphone) smartphoneBtn.interactable = false;
            if (smartwatch) smartwatchBtn.interactable = false;
            if (tablet) tabletBtn.interactable = false;
            GlobalDef.PAUSE = true;
            Time.timeScale = 0;
        });

        // continue btn listener func.
        continueBtn.onClick.AddListener(() =>
        {
            audio.Play();
            pauseBtn.gameObject.SetActive(true);
            continueBtn.gameObject.SetActive(false);
            mask.gameObject.SetActive(false);
            if (smartphone) smartphoneBtn.interactable = true;
            if (smartwatch) smartwatchBtn.interactable = true;
            if (tablet) tabletBtn.interactable = true;
            GlobalDef.PAUSE = false;
            Time.timeScale = 1;
        });

        smartphone = Instantiate(smartphonePrefab);
        smartwatch = Instantiate(smartwatchPrefab);
        tablet = Instantiate(tabletPrefab);

        Transform Tools = canvas.GetChild(0).Find("Tools");
        smartphone.transform.SetParent(Tools);
        smartwatch.transform.SetParent(Tools);
        tablet.transform.SetParent(Tools);

        smartphone.GetComponent<RectTransform>().anchoredPosition = new Vector2(-116, -178);
        smartwatch.GetComponent<RectTransform>().anchoredPosition = new Vector2(-116, -407);
        tablet.GetComponent<RectTransform>().anchoredPosition = new Vector2(-116, -620);

        smartphoneBtn = smartphone.GetComponent<GeneralIconButton>();
        smartwatchBtn = smartwatch.GetComponent<GeneralIconButton>();
        tabletBtn = tablet.GetComponent<GeneralIconButton>();

        // initially disabled
        smartphoneBtn.interactable = false;
        smartphone.GetComponent<Image>().fillAmount = 0;
        smartwatchBtn.interactable = false;
        smartwatchBtn.GetComponent<Image>().fillAmount = 0;
        tabletBtn.interactable = false;
        tabletBtn.GetComponent<Image>().fillAmount = 0;

        Debug.Log(smartphone.GetComponent<Image>().fillAmount);

        InvokeRepeating("UpdateGauge", 0, repeatRate);
        InvokeRepeating("TabletEnable", 0, repeatRate);

        // tools btn listener func.
        smartphoneBtn.onClick.AddListener(() =>
        {
            GlobalDef.SCORE *= 3;
            smartphoneBtn.interactable = false;
            smartphone.GetComponent<Image>().fillAmount = 0;
            GamePanel.smartphoneEnergy = 0;

            // callback func. for score adjust after 15s
            void scoreAdjust()
            {
                GlobalDef.SCORE /= 3;
            }
            Sequence seq = DOTween.Sequence();
            seq.AppendInterval(15f);
            seq.AppendCallback(scoreAdjust);
        });

        smartwatchBtn.onClick.AddListener(() =>
        {
            Timer.stop = true;
            smartwatchBtn.interactable = false;
            smartwatchBtn.GetComponent<Image>().fillAmount = 0;
            GamePanel.smartwatchEnergy = 0;

            // callback func. for time continue after 10s
            void timeContinue()
            {
                Timer.stop = false;
            }
            Sequence seq = DOTween.Sequence();
            seq.AppendInterval(10f);
            seq.AppendCallback(timeContinue);
        });

        tabletBtn.onClick.AddListener(() =>
        {
            tabletBtn.interactable = false;
            tabletBtn.GetComponent<Image>().fillAmount = 0;
            FruitSpawner fruitSpawner = GameObject.Find("Play").transform.GetChild(1).GetComponent<FruitSpawner>();
            StartCoroutine(fruitSpawner.DestroyOneRow());
            InvokeRepeating("TabletEnable", 0, repeatRate);
        });

        // check if player have item
        if (!Player.smartphone) smartphone.gameObject.SetActive(false);
        if (!Player.smartwatch) smartwatch.gameObject.SetActive(false);
        if (!Player.tablet) tablet.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (!isActivate)
        {
            if (!canvas.Find("confirmImage"))
            {
                homeBtn.interactable = true;
                pauseBtn.interactable = true;
            }
        }
    }
    
    private void UpdateGauge()
    {
        if(smartphone != null)
        {
            Image smartphoneImg = smartphone.GetComponent<Image>();
            smartphoneImg.fillAmount = GamePanel.smartphoneEnergy / smartphoneGauge;
            if(smartphoneImg.fillAmount == 1) smartphoneBtn.interactable = true;
        }

        if (smartwatch != null)
        {
            Image smartwatchImg = smartwatch.GetComponent<Image>();
            smartwatchImg.fillAmount = GamePanel.smartwatchEnergy / smartwatchGauge;
            if (smartwatchImg.fillAmount == 1) smartwatchBtn.interactable = true;
        }
    }

    private void TabletEnable()
    {
        Image tabletImg = tablet.GetComponent<Image>();
        tabletImg.fillAmount += 1 / tabletCD * repeatRate;
        if (tabletImg.fillAmount == 1)
        {
            tabletBtn.interactable = true;
            CancelInvoke("TabletEnable");
        }
    }
}
