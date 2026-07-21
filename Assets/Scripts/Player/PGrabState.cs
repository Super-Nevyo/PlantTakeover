using UnityEngine;

public class PGrabState : IState
{
    private Player _player;

    public PGrabState(Player player)
    {
        _player = player;
    }
    public void Enter()
    {
        //_player.GrabTarget.parent = _player.GrabPoint;
        _player.GrabTarget?.GetComponent<IGrabbable>().OnGrab(_player);
    }

    public void Exit()
    {
        _player.Arms.Disable();
    }

    public void Update()
    {
        _player.ArmPosition = Vector2.MoveTowards(_player.ArmPosition, _player.transform.position, _player.AimMoveSpeed * Time.fixedDeltaTime);
        _player.GrabPoint.position = _player.ArmPosition;
        _player.Arms.Update();
        if ((_player.ArmPosition - new Vector2(_player.transform.position.x, _player.transform.position.y)).magnitude < 0.1)
        {
            _player.GrabTarget?.GetComponent<Orphan>().Eaten();
            _player.MyStateMachine.ChangeState(_player.MyStateMachine.IdleState);
        }
    }
}
