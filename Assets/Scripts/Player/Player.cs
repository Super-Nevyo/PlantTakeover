using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine MyStateMachine;
    public GrabbyVines Arms;
    [SerializeField] private float rotationSpeed;

    void OnEnable()
    {
        if (MyStateMachine == null)
        MyStateMachine = new PlayerStateMachine(this);
        MyStateMachine.Initalize(MyStateMachine.IdleState);
    }
    void OnDisable()
    {
        MyStateMachine.Exit();
    }
}
