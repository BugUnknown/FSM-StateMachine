using System.Collections.Generic;
using UnityEngine;

public class ParameterMgr : SingleTon<ParameterMgr>
{
    /// <summary>
    /// Int类型参数列表
    /// </summary>
    private Dictionary<string, int> intParmeters;

    /// <summary>
    /// 构造
    /// </summary>
    public ParameterMgr()
    {
        intParmeters = new Dictionary<string, int>();
    }

    /// <summary>
    /// 添加参数
    /// </summary>
    /// <param name="paraName"></param>
    /// <param name="value"></param>
    public void AddInt(string paraName,int value)
    {
        //不包含该参数
        if (!intParmeters.ContainsKey(paraName))
        {
            intParmeters.Add(paraName,value);
        }
        else
        {
            Debug.LogWarning("已包含参数");
        }
    }

    /// <summary>
    /// 移除参数
    /// </summary>
    /// <param name="parName"></param>
    /// <param name="value"></param>
    public void RemoveInt(string parName,int value)
    {
        if (intParmeters.ContainsKey(parName))
        {
            //移除
            intParmeters.Remove(parName);
        }
        else
        {
            Debug.LogWarning("没有该参数");
        }
    }

    /// <summary>
    /// 获取Int类型的参数
    /// </summary>
    /// <param name="paraName"></param>
    /// <returns></returns>
    public int GetInt(string paraName)
    {
        if (intParmeters.ContainsKey(paraName))
        {
            //返回
            return intParmeters[paraName];
        }
        Debug.LogWarning("没有该参数");
        //表示异常
        return -1000;
    }

    /// <summary>
    /// 设置Int类型的参数
    /// </summary>
    /// <param name="paraName"></param>
    public void SetInt(string paraName,int value)
    {
        if (intParmeters.ContainsKey(paraName))
        {
            intParmeters[paraName] = value;
        }
        else
        {
            Debug.LogWarning("请先添加参数");
        }
    }
}

