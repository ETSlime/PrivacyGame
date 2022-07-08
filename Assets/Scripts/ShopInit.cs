using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class ShopInit : MonoBehaviour
{
    private bool isActivate;

    private int smartwatchPrice;
    private int smartphonePrice;
    private int tabletPrice;
    public static int tipsPrice;
    public static int tipsFactor;
    private int tipsCount;
    MyButton[] items;
    private Transform itemContent;
    private Text pointsText;
    [SerializeField]
    private GameObject warningTextPrefab;

    private const string POINTS_UPDATE = "POINTS_UPDATE";
    private const string COST_UPDATE = "COST_UPDATE";
    private const string COUNT_UPDATE = "COUNT_UPDATE";

    private void Start()
    {
        isActivate = true;

        // initialize price and count
        smartwatchPrice = 30000;
        smartphonePrice = 20000;
        tabletPrice = 50000;
        tipsPrice = 10000;
        tipsFactor = 2000;
        tipsCount = 99;

        itemContent = this.transform.parent.Find("ItemFrame").GetChild(0).GetChild(0);
        items = itemContent.GetComponentsInChildren<MyButton>();

        // initialize item btn
        foreach(var item in items)
        {
            Init(item);
        }

        // initialize points
        pointsText = this.transform.parent.Find("PointsFrame").GetChild(0).GetComponent<Text>();
        pointsText.text = "Current Points: " + Player.points;
        // update points
        EventDispatcher.instance.Regist(POINTS_UPDATE, UpdatePoints);
        // update costs
        EventDispatcher.instance.Regist(COST_UPDATE, UpdateCosts);
        // updatee counts
        EventDispatcher.instance.Regist(COUNT_UPDATE, UpdateCounts);
    }

    private void OnDestroy()
    {
        EventDispatcher.instance.UnRegist(POINTS_UPDATE, UpdatePoints);
        EventDispatcher.instance.UnRegist(COST_UPDATE, UpdateCosts);
        EventDispatcher.instance.UnRegist(COUNT_UPDATE, UpdateCounts);
    }


    private void UpdatePoints(params object[] args)
    {
        pointsText.text = "Current Points: " + (string)args[0];
    }

    private void UpdateCosts(params object[] args)
    {
        Text cost = (Text)args[0];
        int price = (int)args[1];
        cost.text = "Cost: " + price;
    }

    private void UpdateCounts(params object[] args) 
    {
        Text count = (Text)args[0];
        int number = (int)args[1];
        count.text = "Number in stock: " + number;
    }

    private void Init(MyButton item)
    {
        Text cost = item.transform.Find("Cost").GetComponent<Text>();
        Text number = item.transform.Find("Number").GetComponent<Text>();
        string content = "Do you want to buy this item?";
        // set audio
        this.gameObject.AddComponent<AudioSource>();
        AudioSource audio = this.GetComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>("SE/Btn_SE4");

        switch (item.name)
        {
            case "Smartwatch":
                // set price && number in stock
                cost.text = "Cost: " + smartwatchPrice;
                if (Player.smartwatch)
                {
                    number.text = "Number in stock: 0";
                    item.interactable = false;
                }
                else
                    number.text = "Number in stock: 1";
                item.onClick.AddListener(()=> 
                {
                    audio.Play();
                    isActivate = false;
                    // disable item
                    foreach (var item in items)
                    {
                        item.interactable = false;
                    }

                    // 执行确认购买后的回调函数
                    void callback()
                    {
                        if (Player.points >= smartwatchPrice)
                        {
                            Player.points -= smartwatchPrice;
                            item.interactable = false;
                            Player.smartwatch = true;
                            Save.SaveByJSON();
                            EventDispatcher.instance.DispatchEvent(POINTS_UPDATE, Player.points.ToString());
                            EventDispatcher.instance.DispatchEvent(COUNT_UPDATE, number, 0);
                        }
                        else NoMoneyWarning();
                    }

                    ConfirmationPanel.CreatePanel(itemContent.parent, content, callback);
                });
                break;

            case "Smartphone":
                item.onClick.AddListener(() =>
                {
                    audio.Play();
                    isActivate = false;
                    // disable item
                    foreach (var item in items)
                    {
                        item.interactable = false;
                    }

                    // 执行确认购买后的回调函数
                    void callback()
                    {
                        if (Player.points >= smartphonePrice)
                        {
                            Player.points -= smartphonePrice;
                            item.interactable = false;
                            Player.smartphone = true;
                            Save.SaveByJSON();
                            EventDispatcher.instance.DispatchEvent(POINTS_UPDATE, Player.points.ToString());
                            EventDispatcher.instance.DispatchEvent(COUNT_UPDATE, number, 0);
                        }
                        else NoMoneyWarning();
                    }

                    ConfirmationPanel.CreatePanel(itemContent.parent, content, callback);
                });

                // set price && number in stock
                cost.text = "Cost: " + smartphonePrice;
                if (Player.smartphone)
                {
                    number.text = "Number in stock: 0";
                    item.interactable = false;
                }
                else
                    number.text = "Number in stock: 1";
                break;

            case "Tablet":
                item.onClick.AddListener(() =>
                {
                    audio.Play();
                    isActivate = false;
                    // disable item
                    foreach (var item in items)
                    {
                        item.interactable = false;
                    }

                    // 执行确认购买后的回调函数
                    void callback()
                    {
                        if (Player.points >= tabletPrice)
                        {
                            Player.points -= tabletPrice;
                            item.interactable = false;
                            Player.tablet = true;
                            Save.SaveByJSON();
                            EventDispatcher.instance.DispatchEvent(POINTS_UPDATE, Player.points.ToString());
                            EventDispatcher.instance.DispatchEvent(COUNT_UPDATE, number, 0);
                        }
                        else NoMoneyWarning();
                    }

                    ConfirmationPanel.CreatePanel(itemContent.parent, content, callback);
                });

                // set price && number in stock
                cost.text = "Cost: " + tabletPrice;
                if (Player.tablet)
                {
                    number.text = "Number in stock: 0";
                    item.interactable = false;
                }
                else
                    number.text = "Number in stock: 1";
                break;

            case "Tips":
                // set price && number in stock
                cost.text = "Cost: " + (tipsPrice + Player.tipsBought * tipsFactor).ToString();
                number.text = "Number in stock: " + (tipsCount - Player.tipsBought).ToString();

                item.onClick.AddListener(() =>
                {
                    audio.Play();
                    isActivate = false;
                    // disable item
                    foreach (var item in items)
                    {
                        item.interactable = false;
                    }

                    // 执行确认购买后的回调函数
                    void callback()
                    {
                        int totalPrice = tipsPrice + Player.tipsBought * tipsFactor;
                        int count = tipsCount - Player.tipsBought;
                        if (Player.points >= totalPrice)
                        {
                            Player.points -= totalPrice;
                            Player.tipsBought++;
                            Player.tips++;
                            Save.SaveByJSON();
                            int nextPrice = tipsPrice + Player.tipsBought * tipsFactor;
                            EventDispatcher.instance.DispatchEvent(POINTS_UPDATE, Player.points.ToString());
                            EventDispatcher.instance.DispatchEvent(COST_UPDATE, cost, nextPrice);
                            EventDispatcher.instance.DispatchEvent(COUNT_UPDATE, number, count - 1);
                        }
                        else NoMoneyWarning();
                    }

                    ConfirmationPanel.CreatePanel(itemContent.parent, content, callback);
                });
                break;
        }
    }

    private void NoMoneyWarning()
    {
        GameObject warningText = Instantiate(warningTextPrefab);
        warningText.name = "Warning Text";
        warningText.transform.SetParent(itemContent.parent);
        warningText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        warningText.transform.GetChild(1).GetComponent<MyButton>().onClick.AddListener(() => GameObject.Destroy(warningText.gameObject));
    }

    public void Update()
    {
        if (!isActivate)
        {
            if (!itemContent.parent.Find("confirmImage") && !itemContent.parent.Find("Warning Text"))
            {
                foreach(var item in items)
                {
                    string costNumber = item.transform.Find("Number").GetComponent<Text>().text;
                    if (int.Parse(costNumber.Substring(16, costNumber.Length - 16)) > 0) item.interactable = true;
                }
                isActivate = true;
            }
        }
    }
}
