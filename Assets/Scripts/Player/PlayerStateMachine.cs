using UnityEngine;

public class PlayerStateMachine
{
    private Player _player;
    public IState CurrentState;
    public PIdleState IdleState;
    public PAimState AimState;
    public PMoveState MoveState;
    public PGrabState GrabState;
    public PlayerStateMachine(Player player)
    {
        _player = player;
        IdleState = new PIdleState(_player);
        AimState = new PAimState(_player);
        MoveState = new PMoveState(_player);
        GrabState = new PGrabState(_player);
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
    public void Update() {
        CurrentState.Update();
    }
}
