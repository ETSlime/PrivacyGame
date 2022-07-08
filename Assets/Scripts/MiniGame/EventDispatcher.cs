using UnityEngine;
using System.Collections.Generic;

public delegate void MyEventHandler(params object[] objs);

/// <summary>
/// 事件管理器，订阅事件与事件触发
/// </summary>
public class EventDispatcher
{

    // listener是一个dict，通过string(事件名称eventName)查找执行事件的方法
    // 执行事件的方法由另一个dict组成，可以有很多个方法，通过int(方法的hashcode)查找
    private Dictionary<string, Dictionary<int, MyEventHandler>> listeners = new Dictionary<string, Dictionary<int, MyEventHandler>>();
    private readonly string ErrorMessage = "DispatchEvent Error, Event:{0}, Error:{1}, {2}";

    public static EventDispatcher instance = new EventDispatcher();

    /// <summary>
    /// 订阅事件
    /// </summary>
    public void Regist(string eventName, MyEventHandler handler)
    {
        if (handler == null)
            return;

        // 如果listener中没有相应的事件名称，就把相应的事件名称添加进来，并新建一个dict记录对应的方法
        if (!listeners.ContainsKey(eventName))
        {
            listeners.Add(eventName, new Dictionary<int, MyEventHandler>());
        }
        // 获取事件名称的对应方法handlerDic
        Dictionary<int, MyEventHandler> handlerDic = listeners[eventName];
        // 获取委托方法的hashcode
        int handlerHash = handler.GetHashCode();
        // 如果hashcode重复，移除掉旧的委托方法，把新的加入到handlerDic
        if (handlerDic.ContainsKey(handlerHash))
        {
            handlerDic.Remove(handlerHash);
        }
        listeners[eventName].Add(handler.GetHashCode(), handler);
    }

    /// <summary>
    /// 注销事件
    /// </summary>
    public void UnRegist(string eventName, MyEventHandler handler)
    {
        if (handler == null)
            return;

        if (listeners.ContainsKey(eventName))
        {
            listeners[eventName].Remove(handler.GetHashCode());
            // 如果事件没有对应的方法，就把事件从listener里删去
            if (listeners[eventName] == null || listeners[eventName].Count == 0)
            {
                listeners.Remove(eventName);
            }
        }
    }

    public void UnRegistALL(string eventName)
    {
        if (listeners.ContainsKey(eventName))
        {
            listeners.Remove(eventName);
        }    
    }

    /// <summary>
    /// 触发事件
    /// </summary>
    public void DispatchEvent(string eventName, params object[] objs)
    {
        if (GlobalDef.PAUSE) return;
        // 先找到事件对应的方法池
        if (listeners.ContainsKey(eventName))
        {
            Dictionary<int, MyEventHandler> handlerDic = listeners[eventName];
            // 如果对应事件的方法池里的方法数量不为0
            if (handlerDic != null &&  handlerDic.Count > 0)
            {
                
                // 取出所有方法池里的方法并且全部执行
                //Dictionary<int, MyEventHandler> dic = new Dictionary<int, MyEventHandler>(handlerDic);
                foreach (MyEventHandler fun in handlerDic.Values)
                {
                    try
                    {
                        fun(objs);
                    }
                    catch (System.Exception ex)
                    {
                        Debug.LogErrorFormat(ErrorMessage, eventName, ex.Message, ex.StackTrace);
                    }
                }
            }
        }
    }


    /// <summary>
    /// 清空事件
    /// </summary>
    /// <param name="key"></param>
    public void ClearEvents(string eventName)
    {
        if (listeners.ContainsKey(eventName))
        {
            listeners.Remove(eventName);
        }
    }
}
