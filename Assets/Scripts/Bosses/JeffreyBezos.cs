using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class JeffreyBezos : MonoBehaviour, IGrabber
{
    public BezosStateMachine MyStateMachine;
    public Player TargetPlayer;
    public GameObject Missile;
    public Transform[] MissleLauncher;
    public float PlayerMinDistance;
    public float OrphanCheckDistance;
    public Collider2D food;
    private Orphan spawned;
    [SerializeField] private Orphan orphanBase;
    public float SpawnOrphansEverySecs;
    public float SpawnOrphansVeriationSecs;
    public float MeatGague;
    public float MaxMeatGague;
    public float MeatGagueDrainRate;
    public float OrphanMeatAmount;
    [SerializeField] public Transform GrabTarget;
    [SerializeField] public float StepsToEat;
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
        food = Physics2D.OverlapCircle(transform.position, OrphanCheckDistance, LayerMask.GetMask("Orphans"));
        return (food != null);
    }
    public IEnumerator SpawnOrphansEvery(float between, float veriation)
    {
        while (true)
        {
            yield return new WaitForSeconds(between + Random.Range(-veriation, veriation));
            spawned = Instantiate(orphanBase);
            spawned.Target(this);
        }
    }
    public void DrainMeatGague()
    {
        MeatGague -= MeatGagueDrainRate * Time.fixedDeltaTime;
        if (MeatGague <= 0)
        {
            MeatGague = 0;
            MyStateMachine.ChangeState(MyStateMachine.StateDie);
        }
    }

    public Transform GetGrabTarget()
    {
        return GrabTarget;
    }

    public void UnGrab()
    {
        MyStateMachine.ChangeState(MyStateMachine.StateShoot);//StateFly); if state fly exists put it here
    }
}
