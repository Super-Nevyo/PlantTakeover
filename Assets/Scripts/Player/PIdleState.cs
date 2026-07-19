using UnityEngine;

public class PIdleState : IState
{
    private Player _player;

    public PIdleState(Player player)
    {
        _player = player;
    }
    public void Enter()
    {
        EventManager.ClickAction += SendOutArms;
    }

    public void Exit()
    {
        EventManager.ClickAction -= SendOutArms;
    }

    public void Update()
    {
        _player.transform.rotation = Quaternion.RotateTowards(_player.transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2((_player.WorldMousePosition.y - _player.transform.position.y) * Mathf.Deg2Rad, (_player.WorldMousePosition.x - _player.transform.position.x) * Mathf.Deg2Rad) * Mathf.Rad2Deg), _player.RotationSpeed * Time.fixedDeltaTime);
        
    }

    public void SendOutArms()
    {
        _player.MyStateMachine.ChangeState(_player.MyStateMachine.AimState);
    }
}
