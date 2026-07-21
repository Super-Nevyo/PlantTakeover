using UnityEngine;

public class BSDie : IState
{
    private JeffreyBezos _bezos;

    public BSDie(JeffreyBezos bezos)
    {
        _bezos = bezos;
    }
    public void Enter()
    {
        _bezos.StopCoroutine(_bezos.SpawnOrphansEvery(_bezos.SpawnOrphansEverySecs, _bezos.SpawnOrphansVeriationSecs));
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        
    }

    
}
