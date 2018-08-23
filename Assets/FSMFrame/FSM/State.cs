using System.Collections.Generic;

namespace FSM
{
    public class State : IState
    {
        #region 基础成员

        private string stateName;
        private IStateMachine parent;
        private StateBaseEventHandle onStateEnter;
        private StateBaseEventHandle onStateExit;
        private StateEmptyEventHandle onStateUpdate;
        private List<ITransition> transitions;

        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="name"></param>
        public State(string name)
        {
            stateName = name;
            transitions = new List<ITransition>();
        }

        public string StateName
        {
            get
            {
                return stateName;
            }
        }

        public StateBaseEventHandle OnStateEnter
        {
            get { return onStateEnter; }
            set { onStateEnter = value; }
        }

        public StateBaseEventHandle OnStateExit
        { get { return onStateExit; }
            set { onStateExit = value; }
        }

        public StateEmptyEventHandle OnStateUpdate
        { get { return onStateUpdate; } 
            set { onStateUpdate = value; } 
        }

        public IStateMachine Parent 
        { get { return parent; }
            set { parent = value; }
        }

        public List<ITransition> StateTransition 
        {
            get
            {
                return transitions;
            }
        }

        public void AddTransition(ITransition t)
        {
            if (t!=null && !transitions.Contains(t))
            {
                transitions.Add(t);
            }
        }

        public void RemoveTransition(ITransition t)
        {
            if (t!=null&&transitions.Contains(t))
            {
                transitions.Remove(t);
            }
        }
    }
}