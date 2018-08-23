using System.Collections.Generic;

namespace FSM
{
    /// <summary>
    /// 状态机接口
    /// </summary>
    public interface IStateMachine
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        IState Current { get; set; }

        /// <summary>
        /// 默认状态
        /// </summary>
        IState Default { get; set; }

        /// <summary>
        /// 管理的所有状态
        /// </summary>
        List<IState> ALlStates { get; }

        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="s"></param>
        void AddState(IState s);

        /// <summary>
        /// 移除状态
        /// </summary>
        /// <param name="s"></param>
        void RemoveState(IState s);

        /// <summary>
        /// 查找状态
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IState FindStateWithName(string name);

        /// <summary>
        /// 状态机启动
        /// </summary>
        void MachineStart();

        /// <summary>
        /// 检测当前状态过渡是否满足
        /// </summary>
        void CheckCurrentTransition();

        /// <summary>
        /// 检测任意状态过渡
        /// </summary>
        void CheckAnyStateTransition();

        /// <summary>
        /// 任意状态的过渡列表
        /// </summary>
        List<ITransition> AnyStateTransition { get; }

        /// <summary>
        /// 添加任意状态过渡
        /// </summary>
        /// <param name="t"></param>
        void AddAnyState(ITransition t);

        /// <summary>
        /// 移除任意状态过渡
        /// </summary>
        /// <param name="t"></param>
        void RemoveAnyStateTransition(ITransition t);

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="s"></param>
        void SwitchState(ITransition s);
    }
}
