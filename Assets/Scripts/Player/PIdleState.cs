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
    }

    public void SendOutArms()
    {

    }
}
