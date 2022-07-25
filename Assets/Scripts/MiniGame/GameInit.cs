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
    private GeneralIconButton tutorialBtn;
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
        Transform tutorialTF = canvas.GetChild(0).Find("Tutorial");
        Transform continueTF = canvas.GetChild(0).Find("Continue");
        Transform mask = canvas.GetChild(0).Find("Mask");
        homeBtn = homeBtnTF.gameObject.AddComponent<GeneralIconButton>();
        pauseBtn = pauseTF.gameObject.AddComponent<GeneralIconButton>();
        continueBtn = continueTF.gameObject.AddComponent<GeneralIconButton>();
        tutorialBtn = tutorialTF.gameObject.AddComponent<GeneralIconButton>();

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
            if (!canvas.transform.Find("ConfirmImage"))
                ConfirmationPanel.CreatePanel(canvas, content, Load, imageSize, textSize);
        });

        // tutorial btn listener func.
        tutorialBtn.onClick.AddListener(() =>
        {
            audio.Play();
            string content = "Do you want to read the game tutorial?";
            void Load()
            {
                LoadGame.LoadScene("Game Tutorial");
            }
            if (!canvas.transform.Find("ConfirmImage"))
                ConfirmationPanel.CreatePanel(canvas, content, Load);
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

        InvokeRepeating("UpdateGauge", 0, repeatRate);
        InvokeRepeating("TabletEnable", 0, repeatRate);

        // tools btn listener func.
        smartphoneBtn.onClick.AddListener(() =>
        {
            GlobalDef.SCORE *= 3;
            smartphoneBtn.interactable = false;
            smartphone.GetComponent<Image>().fillAmount = 0;
            GamePanel.smartphoneEnergy = 0;

            GameObject scoreUp = canvas.Find("Score Up").gameObject;
            GameObject scoreDown = canvas.Find("Score Down").gameObject;
            // show score up text
            scoreUp.SetActive(false);
            if (!scoreUp.GetComponent<AudioSource>()) scoreUp.AddComponent<AudioSource>();
            scoreUp.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/success");
            scoreUp.SetActive(true);
            scoreUp.GetComponent<Image>().CrossFadeAlpha(0, 2.0f, false);
            scoreUp.transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(0, 2.0f, false);

            // callback func. for score adjust after 15s
            void scoreAdjust()
            {
                GlobalDef.SCORE /= 3;

                // show score down text
                scoreDown.SetActive(false);
                if (!scoreDown.GetComponent<AudioSource>()) scoreDown.AddComponent<AudioSource>();
                scoreDown.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/disappear");
                scoreDown.SetActive(true);
                scoreDown.GetComponent<Image>().CrossFadeAlpha(0, 2.0f, false);
                scoreDown.transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(0, 2.0f, false);
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

            
            GameObject timeUnfreeze = canvas.Find("Time Unfreeze").gameObject;
            GameObject timeFreeze = canvas.Find("Time Freeze").gameObject;

            // show time freeze text
            timeFreeze.SetActive(false);
            if (!timeFreeze.GetComponent<AudioSource>()) timeFreeze.AddComponent<AudioSource>();
            timeFreeze.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/success");
            timeFreeze.SetActive(true);
            timeFreeze.GetComponent<Image>().CrossFadeAlpha(0, 2.0f, false);
            timeFreeze.transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(0, 2.0f, false);

            // callback func. for time continue after 10s
            void timeContinue()
            {
                Timer.stop = false;

                // show time unfreeze text
                timeUnfreeze.SetActive(false);
                if (!timeUnfreeze.GetComponent<AudioSource>()) timeUnfreeze.AddComponent<AudioSource>();
                timeUnfreeze.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("SE/disappear");
                timeUnfreeze.SetActive(true);
                timeUnfreeze.GetComponent<Image>().CrossFadeAlpha(0, 2.0f, false);
                timeUnfreeze.transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(0, 2.0f, false);
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
                tutorialBtn.interactable = true;
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
