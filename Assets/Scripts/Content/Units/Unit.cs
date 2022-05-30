using System;
using System.Collections;
using System.Collections.Generic;
using Content.Units;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    private Dictionary<Type, StateBase> _state = new Dictionary<Type, StateBase>();

    private NavMeshAgent _agent;
    private StateBase _curState;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        InitState<StateIdle>();
    }

    private void Update()
        => _curState?.StateUpdate();

    private void InitState<T>() where T : StateBase, new()
    {
        _state.Clear();
        _curState = null;
        
        if (!_state.ContainsKey(typeof(T)))
            _state.Add(typeof(T),new T());

        _curState = _state[typeof(T)];
        _curState.StateEnter(this);
    }
    
    public void ChangeState<T>() where T : StateBase, new()
    {
        if (!_state.ContainsKey(typeof(T)))
            _state.Add(typeof(T),new T());

        _curState.StateExit();

        _curState = _state[typeof(T)];
        
        _curState.StateEnter(this);
    }
}
