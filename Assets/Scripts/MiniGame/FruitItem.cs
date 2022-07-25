﻿using UnityEngine;
using DG.Tweening;


/// <summary>
/// 水果脚本
/// </summary>
public class FruitItem : MonoBehaviour
{
    /// <summary>
    /// 行号
    /// </summary>
    public int rowIndex;
    /// <summary>
    /// 列号
    /// </summary>
    public int columnIndex;
    /// <summary>
    /// 水果类型
    /// </summary>
    public int fruitType;

    /// <summary>
    /// 水果图片
    /// </summary>
    public GameObject fruitSpriteObj;


    private Transform m_selfTransform;

    private AudioSource audioSource;

    private void Awake()
    {
        m_selfTransform = transform;
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.volume = 0.5f;
        audioSource.clip = Resources.Load<AudioClip>("SE/fruit_disappear");
    }

    /// <summary>
    /// 创建水果图片
    /// </summary>
    /// <param name="fruitType">水果类型</param>
    /// <param name="prefab">水果图片预设</param>
    public void CreateFruitBg(int fruitType, GameObject prefab)
    {
        if (fruitSpriteObj != null) return;
        this.fruitType = fruitType;
        fruitSpriteObj = Instantiate(prefab);
        fruitSpriteObj.transform.localScale = Vector3.one * GlobalDef.CELL_SIZE;
        fruitSpriteObj.transform.SetParent(m_selfTransform, false);
    }

    /// <summary>
    /// 设置坐标
    /// </summary>
    public void UpdatePosition(int rowIndex, int columIndex, bool dotween = false)
    {
        this.rowIndex = rowIndex;
        this.columnIndex = columIndex;
        var targetPos = new Vector3((columIndex - GlobalDef.COLUM_COUNT / 2f) * GlobalDef.CELL_SIZE + GlobalDef.CELL_SIZE / 2f, (rowIndex - GlobalDef.ROW_COUNT / 2f) * GlobalDef.CELL_SIZE + GlobalDef.CELL_SIZE / 2f, 0);
        if(dotween)
        {
            // 0.3秒移动到目标点
            m_selfTransform.DOLocalMove(targetPos, 0.3f);
        }
        else
        {
            m_selfTransform.localPosition = targetPos;
        }
    }

    /// <summary>
    /// 水果被点击
    /// </summary>
    private void OnMouseDown()
    {
        // 抛出事件
        // 每次点击水果，向EventDispatcher抛出一个水果被点选了的事件，下同理
        EventDispatcher.instance.DispatchEvent(EventDef.EVENT_FRUIT_SELECTED, this);
    }

    /// <summary>
    /// 销毁水果图片
    /// </summary>
    public void DestroyFruitBg()
    {
        Destroy(fruitSpriteObj);
        fruitSpriteObj = null;
        // 水果消失事件
        EventDispatcher.instance.DispatchEvent(EventDef.EVENT_FRUIT_DISAPPEAR, m_selfTransform.position);
        // 加分事件，每个水果10分
        EventDispatcher.instance.DispatchEvent(EventDef.EVENT_ADD_SCORE, GlobalDef.SCORE);
        // 水果消除时播放声音
        audioSource.Play();
    }
}
