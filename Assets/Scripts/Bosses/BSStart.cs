using UnityEngine;

public class BSStart : IState
{
    private JeffreyBezos _bezos;

    public BSStart(JeffreyBezos bezos)
    {
        _bezos = bezos;
    }
    public void Enter()
    {
        //play cutscene, start music
        //when its over, change into state shoot
    }

    public void Exit()
    {
        _bezos.TargetPlayer = GameObject.FindFirstObjectByType<Player>();
        _bezos.StartCoroutine(_bezos.SpawnOrphansEvery(_bezos.SpawnOrphansEverySecs, _bezos.SpawnOrphansVeriationSecs));
    }

    public void Update()
    {
        _bezos.MyStateMachine.ChangeState(_bezos.MyStateMachine.StateShoot);
    }

    
}
