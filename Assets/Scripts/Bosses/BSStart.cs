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
        EventManager.PlayVideo?.Invoke();
        EventManager.VideoOver += VideoOver;
        //play cutscene, start music
        //when its over, change into state shoot
    }

    public void Exit()
    {
        EventManager.VideoOver -= VideoOver;
        _bezos.TargetPlayer = GameObject.FindFirstObjectByType<Player>();
        _bezos.StartCoroutine(_bezos.SpawnOrphansEvery(_bezos.SpawnOrphansEverySecs, _bezos.SpawnOrphansVeriationSecs));
        AudioManager.instance.PlayMusic("Bezos Theme");
    }

    public void Update()
    {
        
    }
    public void VideoOver()
    {
        _bezos.MyStateMachine.ChangeState(_bezos.MyStateMachine.StateShoot);
    }

    
}
