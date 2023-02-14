using DAE.GameSystem.GameStates;
using DAE.GameSystem.Singleton;
using DAE.ObjectPool;
using DAE.StateSystem;
using Pools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameloopGJ : SingletonMonoBehaviour<GameloopGJ>
{

    //private PlayerInput playerInput;
    //private GameControlls GameControlls;

    public StateMachine<GameStateBase> _MenuFSM;

    public ObjectPool<PoolTemplate> TestObjectPool;
    public PoolTemplate TestpoolTemplate;
    public int minPoolObject;
    public int MAxpoolObject;
    public Transform TemplatepoolParent;

    void Start()
    {
        _MenuFSM = new StateMachine<GameStateBase>();
        _MenuFSM.Register(GameState.GamePlayState, new GamePlayState(_MenuFSM));
        _MenuFSM.InitialState = GameState.MenuState;

        TestObjectPool = new ObjectPool<PoolTemplate>();
        TestObjectPool.PoolObjectCreated += (s, e) =>
        {
            Debug.Log(e.poolableObject + "created");
        };
        TestObjectPool.InitializeObjectPool(TestpoolTemplate, TemplatepoolParent, minPoolObject, MAxpoolObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Testtrigger1()
    {
        _MenuFSM.CurrentState.Test1();
    }

    public void Testtrigger2()
    {
        _MenuFSM.CurrentState.Test2();
    }

    public void GoToGamePlayState()
    {
        _MenuFSM.MoveToState(GameState.GamePlayState);
    }

}
