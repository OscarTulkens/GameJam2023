
using DAE.StateSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAE.GameSystem.GameStates
{
    public class GameStateBase : IState<GameStateBase>
    {
        public StateMachine<GameStateBase> StateMachine { get; }

        public GameStateBase(StateMachine<GameStateBase> stateMachine)
        {
            StateMachine = stateMachine;
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }

        


        internal virtual void Test1()
        {

        }

        internal virtual void Test2()
        {

        }

    }
}
