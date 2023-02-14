using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAE.StateSystem
{
    public class StateMachine<TState>
        where TState : IState<TState>
    {
        private Dictionary<string, TState> _states = new Dictionary<string, TState>();

        //string PauzeStateName;
        private TState PauzeState;
                
        private TState StartingState;

        public string _currentStateName = "";
        public string _previousStateName = "";

        public string PreviousStateName
        {
            get { return _previousStateName; }
            set { _previousStateName = value; }
        }


        public TState CurrentState
        {
            get
            {
                if (_states.ContainsKey(_currentStateName))
                    return _states[_currentStateName];
                else
                    return default (TState);
            }
        }

        public string InitialState
        {
            set
            {
                PreviousStateName = "No Previous State";
                _currentStateName = value;
                CurrentState?.OnEnter();
            }
        }

        public void MoveToState(string stateName)
        {
            PreviousStateName = _currentStateName;

            CurrentState?.OnExit();

            _currentStateName = stateName;

            CurrentState?.OnEnter();
        }        

        //registere with a parent state?
        public void Register(string stateName, TState state)
        {
            if (_states.ContainsKey(stateName))
                throw new ArgumentException($"{nameof(stateName)} alread exists");

            _states[stateName] = state;
        }

        public void RegisterPauze(TState state)
        {
            PauzeState = state;         
          
        }

        public void RegisterStart(TState state)
        {
            StartingState = state;        
        }

        public void PauzeFSM()
        {
            //PreviousStateName = _currentStateName;

            CurrentState?.OnExit();

            //_currentStateName = "PauzeState";

            PauzeState?.OnEnter();
        }

        public void UnPauzeFSM()
        {       
            PauzeState?.OnExit();

            //_currentStateName = PreviousStateName;

            CurrentState?.OnEnter();
        }

        public void ResetFSM()
        {
            //CurrentState?.OnExit();

            StartingState.OnEnter();

            _currentStateName = "";
        }

        
    }


}
