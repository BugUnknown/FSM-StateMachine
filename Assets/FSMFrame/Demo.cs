using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class Demo : MonoBehaviour 
{
    private void Start()
    {
        //状态机
        StateMachine machine = new StateMachine("SM");

        /// <summary>
        /// 游戏暂停状态
        /// </summary>
        State gamePause = new State("GamePause");

        gamePause.OnStateEnter += (s) =>
        {
            Debug.Log("进入游戏暂停状态");
        };

        gamePause.OnStateUpdate += () =>
        {
            Debug.Log("在游戏暂停状态中更新");
        };

        gamePause.OnStateExit += (s) =>
        {
            Debug.Log("离开游戏暂停状态");
        };

        /// <summary>
        /// 游戏启动状态
        /// </summary>
        State gameStart = new State("GameStart");

        gameStart.OnStateEnter += (s) =>
        {
            Debug.Log("进入游戏开始状态");
        };

        gameStart.OnStateUpdate += () =>
        {
            Debug.Log("在游戏开始状态中更新");
        };

        gameStart.OnStateExit += (s) =>
        {
            Debug.Log("离开游戏开始状态");
        };

        //添加状态
        machine.AddState(gamePause);
        machine.AddState(gameStart);

        //添加参数
        ParameterMgr.GetInstance().AddInt("GameState", 0);

        //定义过渡
        gamePause.AddTransition(new Transition(gamePause,gameStart,()=>
        {
            if (ParameterMgr.GetInstance().GetInt("GameState")==1)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }));

        gameStart.AddTransition(new Transition(gameStart, gamePause, () =>
        {
            if (ParameterMgr.GetInstance().GetInt("GameState") == 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }));

        //状态机启动
        machine.MachineStart();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ParameterMgr.GetInstance().SetInt("GameState", 1);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ParameterMgr.GetInstance().SetInt("GameState", 0);
        }
    }

}
