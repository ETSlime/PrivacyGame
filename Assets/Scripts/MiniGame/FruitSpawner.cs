using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    /// <summary>
    /// 水果预设
    /// </summary>
    public GameObject[] fruitPrefabs;

    /// <summary>
    /// 生成出来的水果二维数组
    /// </summary>
    public ArrayList fruitList;


    /// <summary>
    /// 水果的根节点
    /// </summary>
    private Transform m_fruitRoot;

    /// <summary>
    /// 被选中的水果
    /// </summary>
    private FruitItem m_curSelectFruit;

    /// <summary>
    /// 手指水平滑动量
    /// </summary>
    private float m_fingerMoveX;
    /// <summary>
    /// 手指竖直滑动量
    /// </summary>
    private float m_fingerMoveY;

    /// <summary>
    /// 需要消除掉的水果数组
    /// </summary>
    private ArrayList m_matchFruits;

    private void Awake()
    {
        m_fruitRoot = this.transform;
        // 绑定水果被点选的事件， 定义水果被点选之后的行为
        // 只是绑定方法，并不会执行，执行方法需要用dispatch
        EventDispatcher.instance.Regist(EventDef.EVENT_FRUIT_SELECTED, OnFruitSelected);
    }

    private void OnDestroy()
    {
        // 解除绑定
        EventDispatcher.instance.UnRegist(EventDef.EVENT_FRUIT_SELECTED, OnFruitSelected);
    }

    /// <summary>
    /// 水果被点击
    /// </summary>
    private void OnFruitSelected(params object[] args)
    {
        // 把被点击的水果对象缓存起来
        m_curSelectFruit = (FruitItem)args[0];
    }

    private void Start()
    {
        SpawnFruitArrayList();

        // 首次生成水果后，执行一次自动检测
        // 开启协程 简单来说，协程就是：你可以写一段顺序的代码，然后标明哪里需要暂停，然后在下一帧或者一段时间后，系统会继续执行这段代码
        StartCoroutine(AutoMatchAgain());
    }

    private void Update()
    {
        if (m_curSelectFruit == null) return;
        if (Input.GetMouseButtonUp(0))
        {
            // 手指抬起，释放当前选中的水果对象
            m_curSelectFruit = null;
            return;
        }


#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButton(0))
#else
        if(1 == Input.touchCount && Input.touches[0].phase == TouchPhase.Moved)
#endif
        {
            m_fingerMoveX = Input.GetAxis("Mouse X");
            m_fingerMoveY = Input.GetAxis("Mouse Y");
        }


        // 滑动量太小，不处理
        if (Mathf.Abs(m_fingerMoveX) < 0.2f && Mathf.Abs(m_fingerMoveY) < 0.2f)
            return;

        OnFruitMove();

        m_fingerMoveX = 0;
        m_fingerMoveY = 0;
    }

    /// <summary>
    /// 水果滑动响应
    /// </summary>
    private void OnFruitMove()
    {
        if (Mathf.Abs(m_fingerMoveX) > Mathf.Abs(m_fingerMoveY))
        {
            // 横向滑动
            // 判断是向左划还是向右划，MoveX < 0 向左划, columIndex - 1, MoveX > 0 向右划, columIndex + 1
            // 边界判断
            int targetColumnIndex = m_curSelectFruit.columnIndex + (m_fingerMoveX > 0 ? 1 : -1);
            if (targetColumnIndex >= GlobalDef.COLUM_COUNT || targetColumnIndex < 0) return;
            FruitItem targetItem = GetFruitItem(m_curSelectFruit.rowIndex, targetColumnIndex);
            StartCoroutine(ExchangeAndMatch(m_curSelectFruit, targetItem));
        }
        else if (Mathf.Abs(m_fingerMoveX) < Mathf.Abs(m_fingerMoveY))
        {
            // 纵向滑动
            // 判断是向上划还是向下划，MoveY < 0 向下划, rowIndex - 1, MoveY > 0 向上划, rowIndex + 1
            // 边界判断
            int targetRowIndex = m_curSelectFruit.rowIndex + (m_fingerMoveY > 0 ? 1 : -1);
            if (targetRowIndex >= GlobalDef.ROW_COUNT || targetRowIndex < 0) return;
            FruitItem targetItem = GetFruitItem(targetRowIndex, m_curSelectFruit.columnIndex);
            StartCoroutine(ExchangeAndMatch(m_curSelectFruit, targetItem));
        }
    }

    /// <summary>
    /// 根据行号列号获取水果对象
    /// </summary>
    private FruitItem GetFruitItem(int rowIndex, int columIndex)
    {
        //if (rowIndex < 0 || rowIndex >= fruitList.Count) return null;
        // 拆箱 object -> ArrayList
        // 从fruitList中取出一行，再从那一行中取出columIndex的那一个
        ArrayList rowList = (ArrayList)fruitList[rowIndex];
        //if (columIndex < 0 || columIndex >= temp.Count) return null;
        return (FruitItem)rowList[columIndex];
    }

    /// <summary>
    /// 根据行号列号设置水果对象
    /// </summary>
    private void SetFruitItem(int rowIndex, int columIndex, FruitItem item)
    {
        ArrayList rowList = (ArrayList)fruitList[rowIndex];
        rowList[columIndex] = item;
    }


    /// <summary>
    /// 交换水果并检测是否可以消除
    /// </summary>
    /// IEnumerator 是一个接口类，实现了Current()和MoveNext()
    IEnumerator ExchangeAndMatch(FruitItem item1, FruitItem item2)
    {
        Exchange(item1, item2);
        yield return new WaitForSeconds(0.3f);
        if (CheckHorizontalMatch() || CheckVerticalMatch())
        {
            // 消除匹配的水果
            RemoveMatchFruit();
            yield return new WaitForSeconds(0.2f);
            
            //上面的水果掉落下来，
            DropDownOtherFruit();

            m_matchFruits = new ArrayList();

            yield return new WaitForSeconds(0.6f);
            // 再次执行一次检测
            StartCoroutine(AutoMatchAgain());
        }
        else
        {
            // 没有任何水果匹配，交换回来
            Exchange(item1, item2);
        }
    }

    /// <summary>
    /// 自动递归检测水果消除
    /// </summary>
    /// <returns></returns>
    IEnumerator AutoMatchAgain()
    {
        // 检测是否有水果可以消除，横向纵向都要检查
        if (CheckHorizontalMatch() || CheckVerticalMatch())
        {
            // 如果有水果可以消除
            // 1. 消除当前水果
            RemoveMatchFruit();
            // 2. 等待0.2秒
            yield return new WaitForSeconds(0.2f);
            // 3. 上方水果落下，补充到消除了的水果
            DropDownOtherFruit();

            // 4. 清空需要消除掉的水果数组
            m_matchFruits = new ArrayList();

            // 5. 等待0.6秒
            yield return new WaitForSeconds(0.6f);
            // 6. 呼叫当前函数，递归检测
            StartCoroutine(AutoMatchAgain());
        }
    }

    /// <summary>
    /// 交换水果
    /// </summary>
    private void Exchange(FruitItem item1, FruitItem item2)
    {
        // 把item2放item1的位置，再把item1放item2的位置
        SetFruitItem(item1.rowIndex, item1.columnIndex, item2);
        SetFruitItem(item2.rowIndex, item2.columnIndex, item1);

        // 交换item1和item2的index
        int tmp = 0;
        tmp = item1.rowIndex;
        item1.rowIndex = item2.rowIndex;
        item2.rowIndex = tmp;

        tmp = item1.columnIndex;
        item1.columnIndex = item2.columnIndex;
        item2.columnIndex = tmp;

        // 更新item1和item2的位置
        item1.UpdatePosition(item1.rowIndex, item1.columnIndex, true);
        item2.UpdatePosition(item2.rowIndex, item2.columnIndex, true);

        m_curSelectFruit = null;
    }


    /// <summary>
    /// 横线检测水果
    /// </summary>
    private bool CheckHorizontalMatch()
    {
        bool isMatch = false;
        for (int rowIndex = 0; rowIndex < GlobalDef.ROW_COUNT; ++rowIndex)
        {
            for (int columIndex = 0; columIndex < GlobalDef.COLUM_COUNT - 2; ++columIndex)
            {
                var item1 = GetFruitItem(rowIndex, columIndex);
                var item2 = GetFruitItem(rowIndex, columIndex + 1);
                var item3 = GetFruitItem(rowIndex, columIndex + 2);
                if (item1.fruitType == item2.fruitType && item2.fruitType == item3.fruitType)
                {
                    isMatch = true;
                    AddMatchFruit(item1);
                    AddMatchFruit(item2);
                    AddMatchFruit(item3);
                }
            }
        }
        return isMatch;
    }

    /// <summary>
    /// 纵向检测水果
    /// </summary>
    /// <returns></returns>
    private bool CheckVerticalMatch()
    {
        bool isMatch = false;
        for (int columIndex = 0; columIndex < GlobalDef.COLUM_COUNT; ++columIndex)
        {
            for (int rowIndex = 0; rowIndex < GlobalDef.ROW_COUNT - 2; ++rowIndex)
            {
                var item1 = GetFruitItem(rowIndex, columIndex);
                var item2 = GetFruitItem(rowIndex + 1, columIndex);
                var item3 = GetFruitItem(rowIndex + 2, columIndex);
                if (item1.fruitType == item2.fruitType && item2.fruitType == item3.fruitType)
                {
                    isMatch = true;
                    AddMatchFruit(item1);
                    AddMatchFruit(item2);
                    AddMatchFruit(item3);
                }
            }
        }
        return isMatch;
    }

    /// <summary>
    /// 添加匹配的水果到缓存中（匹配的水果会被消除掉)
    /// </summary>
    private void AddMatchFruit(FruitItem item)
    {
        if (m_matchFruits == null)
            m_matchFruits = new ArrayList();
        int index = m_matchFruits.IndexOf(item);
        // 如果item不在m_matchFruits里，就加进去，否则的话就不加
        if (-1 == index)
            m_matchFruits.Add(item);
    }

    /// <summary>
    /// 消除水果
    /// </summary>
    private void RemoveMatchFruit()
    {
        for (int i = 0; i < m_matchFruits.Count; ++i)
        {
            // 拆箱操作
            FruitItem item = (FruitItem)m_matchFruits[i];
            // 水果消失
            item.DestroyFruitBg();

        }
    }

    /// <summary>
    /// 消除掉的水果上方的水果下落
    /// </summary>
    private void DropDownOtherFruit()
    {
        // 遍历被消除的水果
        for (int i = 0; i < m_matchFruits.Count; ++i)
        {
            // 拆箱 object -> FruitItem
            // 获取一个被消除的水果
            FruitItem fruit = (FruitItem)m_matchFruits[i];
            // 遍历被消除水果上方的所有水果
            for (int j = fruit.rowIndex + 1; j < GlobalDef.ROW_COUNT; ++j)
            {
                // 将被消除的水果上方所有水果位置往下移
                // 1. 获取处在index位置的水果
                FruitItem dropdownFruit = GetFruitItem(j, fruit.columnIndex);
                // 2. 将此水果行数减一（下移一格）
                dropdownFruit.rowIndex--;
                // 3. 根据此水果新的index，放置此水果在新的index上
                SetFruitItem(dropdownFruit.rowIndex, dropdownFruit.columnIndex, dropdownFruit);
                // 4. 根据新的index更新此水果的位置
                dropdownFruit.UpdatePosition(dropdownFruit.rowIndex, dropdownFruit.columnIndex, true);
            }
            ReuseRemovedFruit(fruit);
        }
    }

    /// <summary>
    /// 复用被消除的水果，作为新水果放到顶部
    /// </summary>
    private void ReuseRemovedFruit(FruitItem fruit)
    {
        // 随机一个水果类型
        int fruitType = Random.Range(0, fruitPrefabs.Length);
        fruit.rowIndex = GlobalDef.ROW_COUNT;
        fruit.CreateFruitBg(fruitType, fruitPrefabs[fruitType]);
        // 先放到最顶部外面
        fruit.UpdatePosition(fruit.rowIndex, fruit.columnIndex);
        // 让其下落一格
        fruit.rowIndex--;
        SetFruitItem(fruit.rowIndex, fruit.columnIndex, fruit);
        fruit.UpdatePosition(fruit.rowIndex, fruit.columnIndex, true);
    }

    /// <summary>
    /// 生成多行多列水果
    /// </summary>
    private void SpawnFruitArrayList()
    {
        fruitList = new ArrayList();
        for (int rowIndex = 0; rowIndex < GlobalDef.ROW_COUNT; ++rowIndex)
        {
            ArrayList temp = new ArrayList();
            for (int columIndex = 0; columIndex < GlobalDef.COLUM_COUNT; ++columIndex)
            {
                var item = AddRandomFruitItem(rowIndex, columIndex);
                temp.Add(item);
            }
            // 存到数组中
            fruitList.Add(temp);
        }
    }

    /// <summary>
    /// 随机一个水果
    /// </summary>
    private FruitItem AddRandomFruitItem(int rowIndex, int columIndex)
    {
        // 随机一个水果类型
        int fruitType = Random.Range(0, fruitPrefabs.Length);
        GameObject item = new GameObject("item");
        item.transform.SetParent(m_fruitRoot, false);
        item.AddComponent<BoxCollider2D>().size = Vector2.one * GlobalDef.CELL_SIZE;
        FruitItem fruitItem = item.AddComponent<FruitItem>();
        fruitItem.UpdatePosition(rowIndex, columIndex);
        fruitItem.CreateFruitBg(fruitType, fruitPrefabs[fruitType]);
        return fruitItem;
    }

    /// <summary>
    /// 提供一个接口，用来随机消灭一行水果
    /// </summary>
    public IEnumerator DestroyOneRow()
    {
        // 随机选取一行
        int rowIndex = Random.Range(0, GlobalDef.ROW_COUNT - 1);
        for (int columnIndex = 0; columnIndex < GlobalDef.COLUM_COUNT; columnIndex++)
        {
            FruitItem item = GetFruitItem(rowIndex, columnIndex);
            AddMatchFruit(item);
        }
        RemoveMatchFruit();
        yield return new WaitForSeconds(0.2f);

        DropDownOtherFruit();

        m_matchFruits = new ArrayList();

        yield return new WaitForSeconds(0.6f);
        StartCoroutine(AutoMatchAgain());
    }

}
