using UnityEngine;

public class BezosStateMachine
{
    private JeffreyBezos _bezos;
    public IState CurrentState;

    public BezosStateMachine(JeffreyBezos bezos)
    {
        _bezos = bezos;
    }

    public void Initalize(IState state)
    {
        CurrentState = state;
        CurrentState.Enter();
    }
    public void Exit()
    {
        CurrentState.Exit();
        CurrentState = null;
    }
    public void ChangeState(IState state)
    {
        CurrentState.Exit();
        CurrentState = state;
        CurrentState.Enter();
    }
    public void Update()
    {
        CurrentState.Update();
    }
}
