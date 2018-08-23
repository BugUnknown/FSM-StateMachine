
namespace FSM
{
    /// <summary>
    /// 状态过渡条件委托
    /// </summary>
    /// <returns></returns>
    public delegate bool StateTransitionConditionEventHandle();

    /// <summary>
    /// 状态过渡接口
    /// </summary>
    public interface ITransition
    {
        /// <summary>
        /// 从哪个状态来
        /// </summary>
        IState From { get; set; }

        /// <summary>
        /// 到哪个状态去
        /// </summary>
        IState To { get; set; }

        /// <summary>
        /// 状态过渡条件事件
        /// </summary>
        StateTransitionConditionEventHandle Condition { get; set; }
    }
}