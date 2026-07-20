using UnityEngine;

public class JeffreyBezos : MonoBehaviour
{
    public BezosStateMachine MyStateMachine;
    public Player TargetPlayer;
    public GameObject Missile;
    public Vector3[] MissleLauncher;
    public float PlayerMinDistance;
    public float OrphanCheckDistance;
    public Orphan food;
    public float DistanceToPlayer => (TargetPlayer.transform.position - transform.position).magnitude;
    void OnEnable()
    {
        if (MyStateMachine == null) MyStateMachine = new BezosStateMachine(this);
        MyStateMachine.Initalize(MyStateMachine.StateStart);
    }
    void OnDisable()
    {
        MyStateMachine.Exit();
    }
    void FixedUpdate()
    {
        MyStateMachine.Update();
    }

    public bool CheckForOrphans()
    {
        //Physics2D.CircleCast()
        return false;
    }

}
