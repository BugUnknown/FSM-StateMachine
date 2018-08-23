using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class Transition : ITransition
    {
        #region 基础成员

        private IState _from;
        private IState _to; 
        private StateTransitionConditionEventHandle condition;

        #endregion

        public Transition(IState fr,IState t,StateTransitionConditionEventHandle ev)
        {
            _from = fr;
            _to = t;
            condition = ev;
        }

        public IState From
        {
            get
            {
                return _from;
            }

            set
            {
                _from = value;
            }
        }

        public IState To 
        { 
            get
            {
                return _to; 
            }
            set
            {
                _to = value;
            }
        }
        public StateTransitionConditionEventHandle Condition 
        { 
            get 
            {
                return condition;
            }
            set
            {
                condition = value;
            }

        }
    }
}

