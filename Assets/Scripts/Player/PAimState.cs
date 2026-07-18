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
        EventManager.UnClickAction += MoveTo;
    }

    public void Exit()
    {
        EventManager.UnClickAction -= MoveTo;
    }

    public void Update()
    {
    }

    public void MoveTo()
    {

    }
}
