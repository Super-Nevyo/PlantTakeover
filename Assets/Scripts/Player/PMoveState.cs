using UnityEngine;

public class PMoveState : IState
{
    private Player _player;

    public PMoveState(Player player)
    {
        _player = player;
    }
    public void Enter()
    {
        AudioManager.instance.PlaySFX("Plant Move");
    }

    public void Exit()
    {
        _player.Arms.Disable();
    }

    public void Update()
    {
        _player.Arms.Update();
        _player.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2((_player.ArmPosition.y - _player.transform.position.y) * Mathf.Rad2Deg, (_player.ArmPosition.x - _player.transform.position.x) * Mathf.Rad2Deg) * Mathf.Rad2Deg);
        _player.transform.position = Vector2.MoveTowards(_player.transform.position, _player.ArmPosition, _player.MoveSpeed * Time.fixedDeltaTime);
        if ((_player.ArmPosition - new Vector2(_player.transform.position.x, _player.transform.position.y)).sqrMagnitude < 0.1) _player.MyStateMachine.ChangeState(_player.MyStateMachine.IdleState);
    }
}
