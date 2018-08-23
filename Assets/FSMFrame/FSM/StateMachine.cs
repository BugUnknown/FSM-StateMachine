using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    /// <summary>
    /// 状态机
    /// 本身也是一个状态
    /// </summary>
    public class StateMachine : State, IStateMachine
    {
        #region 基础成员

        IState _current;
        IState _default;
        List<IState> allStates;
        List<ITransition> anyStateTransitions;

        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="name">Name.</param>
        public StateMachine(string name): base(name)
        {
            allStates = new List<IState>();
            anyStateTransitions = new List<ITransition>();
        }

        public IState Current
        {
            get
            {
                return _current;
            }

            set
            {
                _current = value;
            }
        }

        public IState Default 
        { 
            get 
            {
                return _default;
            }
            set 
            {
                _default = value;
            }
        }

        public List<IState> ALlStates
        {
            get
            {
                return allStates;
            }
        }

        public List<ITransition> AnyStateTransition
        {
            get
            {
                return anyStateTransitions;
            }
        }

        /// <summary>
        /// 添加任意状态
        /// </summary>
        /// <param name="t">T.</param>
        public void AddAnyState(ITransition t)
        {
            if (t!=null&&!anyStateTransitions.Contains(t))
            {
                anyStateTransitions.Add(t);
            }
            else
            {
                throw new System.NotImplementedException();
            }
        }

        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="s">S.</param>
        public void AddState(IState s)
        {
            if (s!=null && !allStates.Contains(s))
            {
                if (allStates.Count==0)
                {
                    //设置默认状态
                    _default = s;
                }
                //设置所处的状态机
                s.Parent = this;
                //添加状态
                allStates.Add(s);
            }
            else
            {
                throw new System.NotImplementedException();
            }
        }

        public void RemoveState(IState s)
        {
            //当前正在运行的状态不能移除
            if (Current == s) return;
            if (s != null && allStates.Contains(s))
            {
                s.Parent = null;
                allStates.Remove(s);
            }
            else
            {
                throw new System.NotImplementedException();
            }
        }

        public IState FindStateWithName(string name)
        {
            foreach(var item in allStates)
            {
                if (item.StateName==name)
                {
                    return item;
                }
            }
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 检测当前状态过度
        /// </summary>
        public void CheckCurrentTransition()
        {
            if (Current == null) return;
            //遍历当前所有状态的所有过渡情况
            foreach (var item in Current.StateTransition)
            {
                //如果当前过渡条件满足
                if (item.Condition())
                {
                    //过渡到目标状态
                    SwitchState(item);
                }
            }
        }

        /// <summary>
        /// 检测任意状态过渡
        /// </summary>
        public void CheckAnyStateTransition()
        {
            foreach (var item in anyStateTransitions)
            {
                if (item.Condition())
                {
                    SwitchState(item);
                    return;
                }
            }
        }

        /// <summary>
        /// 状态机启动
        /// </summary>
        public void MachineStart()
        {
            if (OnStateEnter!=null)
            {
                //执行状态机的进入事件
                OnStateEnter(null);
            }
            if (Current==null)
            {
                //当前状态就是默认状态
                Current = Default;
            }
            //状态机必须每帧检测当前状态是否可以切换
            OnStateUpdate += CheckCurrentTransition;
            //状态机必须每帧检测任意状态是否可以切换
            OnStateUpdate += CheckAnyStateTransition;
            //绑定状态机的更新事件
            StateUpdate.mgr.updateEvent += OnStateUpdate;

            if (Current!=null)
            {
                if (Current.OnStateEnter!=null)
                {
                    //执行当前状态的进入事件
                    Current.OnStateEnter(null);
                }
                if (Current.OnStateUpdate!=null)
                {
                    StateUpdate.mgr.updateEvent += Current.OnStateUpdate;
                }
            }
        }

        public void RemoveAnyStateTransition(ITransition t)
        {
            if (t!=null&&anyStateTransitions.Contains(t))
            {
                anyStateTransitions.Remove(t);
            }
            else
            {
                throw new System.NotImplementedException();
            }
        }


        public void SwitchState(ITransition s)
        {
            //移除上一个状态的更新事件
            if (s.From.OnStateUpdate!=null)
            {
                StateUpdate.mgr.updateEvent -= s.From.OnStateUpdate;

            }

            //如果有离开的事件
            if (s.From.OnStateExit!=null)
            {
                //上一个状态执行离开事件
                s.From.OnStateExit(s.To);
            }
            //更换新的状态
            _current = s.To;

            if (s.To.OnStateEnter!=null)
            {
                //下一个状态执行进入事件
                s.To.OnStateEnter(s.From);
            }
            //绑定新状态的更新事件
            if (s.To.OnStateUpdate!=null)
            {
                StateUpdate.mgr.updateEvent += s.To.OnStateUpdate;
            }
        }
    }
}