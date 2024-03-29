﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameDevProject.utility.statemachine;

public abstract class StateMachine: State
{
    public List<State> States = new();
    private Queue<State> _queue = new();

    #nullable enable
    public State? ActiveState { get; private set; } = null;

    public String LogPrefix = "[SM]";
    public bool LogChanges = false;

    public void AddState(State state)
    {
        state.StateMachine = this;
        States.Add(state);
    }

    public void AddToQueue<T>() where T : State
    {
        AddToQueue(States.First(state => state is T));
    }

    public void AddToQueue(State state)
    {
        if (state.StateMachine != this) throw new Exception("State-machines did not match!");
        _queue.Enqueue(state);
    }
    
    public void GoToState<T>() where T : State
    {
        GotoState(States.First(state => state is T));
    }
    
    public void GotoState(State state)
    {
        if (state.StateMachine != this) throw new Exception("State-machines did not match!");
        ClearQueue();
        AddToQueue(state);
        ContinueQueue();
    }

    public void GotoNoState(bool skipNoState = false)
    {
        ClearQueue();
        ContinueQueue(skipNoState);
    }

    public void ContinueQueue(bool skipNoState = false)
    {
        if (ActiveState != null)
        {
            Log($"Deactivated state {ActiveState.GetType().Name}");
            ActiveState.Deactivate();
        }

        if (_queue.Count == 0)
        {
            if (!skipNoState)
            {
                OnNoState();
            }
            else
            {
                ActiveState = null;
            }
            
            return;
        }

        ActiveState = _queue.Dequeue();
        if (ActiveState == null)
        {
            ContinueQueue();
            return;
        }

        Log($"Activated state {ActiveState.GetType().Name}");
        ActiveState.Activate();
    }

    public void ClearQueue()
    {
        _queue.Clear();
    }

    public override void OnLateDeactivate()
    {
        if (ActiveState != null)
        {
            Log("Please call gotoNoState(true) to deactivate the current state in onDeactivate");
            GotoNoState(true);
        }
        else
        {
            ClearQueue();
        }
    }

    protected abstract void OnNoState();

    private void Log(String msg)
    {
        if (LogChanges) Console.WriteLine($"{LogPrefix} {msg}");
    }
}