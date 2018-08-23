using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class StateUpdate : MonoBehaviour 
{
    public static StateUpdate mgr;

    public float stateDeltaTime = -1;

    /// <summary>
    /// 更新事件
    /// </summary>
    public StateEmptyEventHandle updateEvent;

    private void Awake()
    {
        mgr = this;
    }

    private IEnumerator Start()
    {
        while (true)
        {
            if (stateDeltaTime!=-1 )
            {
                //等于一个自定义的时间段
                yield return new WaitForSeconds(stateDeltaTime);
            }
            else
            {
                //等于一帧
                yield return new WaitForEndOfFrame();
            }
            if (updateEvent!=null)
            {
                //执行事件
                updateEvent();
            }
        }
    }
}
