using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GamePanel : MonoBehaviour
{
    /// <summary>
    /// 总得分Text
    /// </summary>
    public TextMeshProUGUI totalScoreText;


    /// <summary>
    /// 总得分
    /// </summary>
    public static float m_totalScore;

    /// <summary>
    /// smartphone能量条
    /// </summary>
    public static int smartphoneEnergy = 0;

    /// <summary>
    /// smartwatch能量条
    /// </summary>
    public static int smartwatchEnergy = 0;

    private void Awake()
    {
        m_totalScore = Player.points;
        // 注册加分事件
        EventDispatcher.instance.Regist(EventDef.EVENT_ADD_SCORE, OnAddScore);
    }

    private void OnDestroy()
    {
        // 注销加分事件
        EventDispatcher.instance.UnRegist(EventDef.EVENT_ADD_SCORE, OnAddScore);
    }

    /// <summary>
    /// 加分事件
    /// </summary>
    private void OnAddScore(params object[] args)
    {
        // 更新总分显示
        m_totalScore += (int)args[0];
        totalScoreText.text = m_totalScore.ToString();

        smartphoneEnergy++;
        smartwatchEnergy++;
    }
}
