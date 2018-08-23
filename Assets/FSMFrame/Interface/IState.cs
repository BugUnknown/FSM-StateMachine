using System.Collections.Generic;

namespace FSM
{
    /// <summary>
    /// 状态基础委托
    /// </summary>
    /// <param name="s"></param>
    public delegate void StateBaseEventHandle(IState s);

    /// <summary>
    /// 状态无参委托
    /// </summary>
    public delegate void StateEmptyEventHandle();

    /// <summary>
    /// 状态接口
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// 状态名称
        /// </summary>
        string StateName { get; }

        /// <summary>
        /// 进入状态事件
        /// </summary>
        StateBaseEventHandle OnStateEnter { get; set; }

        /// <summary>
        /// 离开状态事件
        /// </summary>
        StateBaseEventHandle OnStateExit { get; set; }

        /// <summary>
        /// 状态更新事件
        /// </summary>
        StateEmptyEventHandle OnStateUpdate { get; set; }

        /// <summary>
        /// 所处的状态机
        /// </summary>
        IStateMachine Parent { get; set; }

        /// <summary>
        /// 状态过渡列表
        /// </summary>
        List<ITransition> StateTransition { get; }

        /// <summary>
        /// 添加过渡
        /// </summary>
        /// <param name="t"></param>
        void AddTransition(ITransition t);

        /// <summary>
        /// 移除过渡
        /// </summary>
        /// <param name="t"></param>
        void RemoveTransition(ITransition t);
    }
}


