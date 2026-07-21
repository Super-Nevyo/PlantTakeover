using UnityEngine;

public class BSShoot : IState
{
    private JeffreyBezos _bezos;
    private int _missilesFired;
    private float _step;
    private int _stepsBeforeFire = 3;

    public BSShoot(JeffreyBezos bezos)
    {
        _bezos = bezos;
    }
    public void Enter()
    {
        _missilesFired = 0;
        _step = 0;
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        if (_step < _stepsBeforeFire)
        {
            _step += Time.fixedDeltaTime;
        }
        else
        {
            if (_bezos.DistanceToPlayer < _bezos.PlayerMinDistance)
            {
                _bezos.MyStateMachine.ChangeState(_bezos.MyStateMachine.StateFly);
                return;
            }
            _step = 0;
            FireMissile();
        }
        _bezos.DrainMeatGague();
        if (_bezos.CheckForOrphans()) _bezos.MyStateMachine.ChangeState(_bezos.MyStateMachine.StateEat);
    }
    private void FireMissile()
    {
        _missilesFired++;
        GameObject missile = Object.Instantiate(_bezos.Missile, _bezos.MissleLauncher[_missilesFired % 2].position, _bezos.MissleLauncher[_missilesFired % 2].rotation);
        missile.GetComponent<BezosMisslie>().SelectTarget(_bezos.TargetPlayer.gameObject);
    }

    
}
