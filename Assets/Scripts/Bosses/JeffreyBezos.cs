using System.Collections;
using Unity.VisualScripting;
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
    private Orphan spawned;
    [SerializeField] private Orphan orphanBase;
    public float SpawnOrphansEverySecs;
    public float SpawnOrphansVeriationSecs;
    public float MeatGague;
    public float MaxMeatGague;
    public float MeatGagueDrainRate;
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

}
