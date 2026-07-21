using UnityEngine;

public class PAimState : IState
{
    private Player _player;

    public PAimState(Player player)
    {
        _player = player;
    }
    public void Enter()
    {
        EventManager.UnClickAction += PickPosition;
        _player.Arms.Enable();
        _player.ArmPosition = _player.transform.position;
    }

    public void Exit()
    {
        EventManager.UnClickAction -= PickPosition;
    }

    public void Update()
    {
        _player.AimPosition = _player.WorldMousePosition;
        // TODO: make collision detection for obstacles blocking the grabber, likly means making a new MoveTowards function
        _player.ArmPosition = Vector2.MoveTowards(_player.ArmPosition, _player.AimPosition, _player.AimMoveSpeed * Time.fixedDeltaTime);
        _player.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2((_player.ArmPosition.y - _player.transform.position.y) * Mathf.Rad2Deg, (_player.ArmPosition.x - _player.transform.position.x) * Mathf.Rad2Deg) * Mathf.Rad2Deg);
        _player.Arms.Update();
    }

    public void PickPosition()
    {
        if (_player.IsGrabbable())
        {

        }
        else _player.MyStateMachine.ChangeState(_player.MyStateMachine.MoveState);
    }
}
