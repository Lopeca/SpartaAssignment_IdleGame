using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void Enter();
    public void Exit();
    public void Update();
}
public abstract class StateMachine
{
    protected IState currentState;
    
    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    public void UpdateMachine()
    {
        currentState?.Update();
    }

    public virtual void StopMachine()
    {
    }
}
