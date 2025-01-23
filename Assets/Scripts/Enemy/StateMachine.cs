using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public Dictionary<string, GameObject> Prefabs { get; private set; } = new Dictionary<string, GameObject>(); 
    public IState CurrentState { get; private set; }

    public void ChangeState(IState newState)
    {
        if (CurrentState != null)
        {
            CurrentState.Exit();
        }

        CurrentState = newState;
        CurrentState.Enter();
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Execute();
        }
    }

    public void AddPrefab(string name, GameObject prefab)
    {
        Prefabs.Add(name, prefab);
    }
}
