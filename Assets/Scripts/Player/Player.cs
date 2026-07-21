using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IGrabber
{
    public PlayerStateMachine MyStateMachine;
    public GrabbyVines Arms;
    public GameObject ArmObject;
    [SerializeField] public float RotationSpeed;
    [SerializeField] public float AimMoveSpeed;
    [SerializeField] public float MoveSpeed;
    private Vector2 _mousePosition;
    [HideInInspector] public Vector2 WorldMousePosition;
    [HideInInspector] public Vector2 AimPosition;
    [HideInInspector] public Vector2 ArmPosition;
    [HideInInspector] public Transform GrabTarget;
    public Transform GrabPoint;
    [SerializeField] private float grabSize;

    void OnEnable()
    {
        if (MyStateMachine == null)
        MyStateMachine = new PlayerStateMachine(this);
        if (Arms == null) Arms = new GrabbyVines(this, ArmObject);
        MyStateMachine.Initalize(MyStateMachine.IdleState);
        Arms.Disable();
        Debug.Log("playerEnabled");
    }
    void OnDisable()
    {
        MyStateMachine.Exit();
    }
    private void FixedUpdate()
    {
        _mousePosition = Mouse.current.position.ReadValue();
        WorldMousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);
        MyStateMachine.Update();
    }

    public bool IsGrabbable()
    {
        GrabTarget = Physics2D.OverlapCircle(GrabPoint.position, grabSize, LayerMask.GetMask("Orphan"))?.GetComponent<Transform>();
        return GrabTarget != null;
    }

    public Transform GetGrabTarget()
    {
        return GrabPoint;
    }

    public void UnGrab()
    {
        GrabTarget = null;
    }
}
