using Unity.VisualScripting;
using UnityEngine;

public class BSEat : IState
{
    private JeffreyBezos _bezos;
    private Vector2 _startVector;
    private float step;
    private Orphan food;

    public BSEat(JeffreyBezos bezos)
    {
        _bezos = bezos;
    }
    public void Enter()
    {
        food = _bezos.food.GetComponent<Orphan>();
        _startVector = food.transform.position;
        step = 0;
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        if (food != null)
        {
            _bezos.DrainMeatGague();
            _bezos.food.transform.position = Vector2.Lerp(_startVector, _bezos.transform.position, step / _bezos.StepsToEat);
            step += Time.fixedDeltaTime;
            if (_bezos.StepsToEat < step)
            {
                _bezos.MeatGague += food.Eaten();
                if (_bezos.MeatGague > _bezos.MaxMeatGague) _bezos.MeatGague = _bezos.MaxMeatGague;
                if (_bezos.CheckForOrphans()) _bezos.MyStateMachine.ChangeState(_bezos.MyStateMachine.StateEat);
                else _bezos.MyStateMachine.ChangeState(_bezos.MyStateMachine.StateShoot);
            }
        }
        else _bezos.MyStateMachine.ChangeState(_bezos.MyStateMachine.StateShoot);
    }

    
}
