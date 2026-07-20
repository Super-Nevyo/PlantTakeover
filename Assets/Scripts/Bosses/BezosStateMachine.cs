using UnityEngine;

public class BezosStateMachine
{
    private JeffreyBezos _bezos;
    public IState CurrentState;
    public BSStart StateStart;
    public BSDie StateDie;
    public BSEat StateEat;
    public BSFly StateFly;
    public BSShoot StateShoot;
    public BezosStateMachine(JeffreyBezos bezos)
    {
        _bezos = bezos;
        StateStart = new BSStart(_bezos);
        StateDie = new BSDie(_bezos);
        StateEat = new BSEat(_bezos);
        StateFly = new BSFly(_bezos);
        StateShoot = new BSShoot(_bezos);
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
