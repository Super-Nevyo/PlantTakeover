using UnityEngine;

public class Orphan : MonoBehaviour, IBombable, IGrabbable
{
    private JeffreyBezos _bezos;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    [SerializeField] private Vector2 spawnHalfExtent;
    [SerializeField] private Vector2 spawnOffset;
    [SerializeField] private float approchRange;
    [SerializeField] private ParticleSystem boom;
    [SerializeField] private float meatValue;
    private bool eaten;
    private IGrabber _grabber;
    private bool _isGrabbed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(Random.Range(-spawnHalfExtent.x, spawnHalfExtent.x) + spawnOffset.x, Random.Range(-spawnHalfExtent.y, spawnHalfExtent.y) + spawnOffset.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_bezos != null && !_isGrabbed)
        {
            if ((_bezos.transform.position - transform.position).magnitude >= approchRange)
                rb.linearVelocity = speed * (_bezos.transform.position - transform.position).normalized;
            else rb.linearVelocity = Vector2.zero;
        }
    }
    public void OnBomb()
    {
        Die();
    }
    public void OnGrab(IGrabber grabber)
    {
        if (_grabber != null) _grabber.UnGrab();
        _grabber = grabber;
        transform.position = _grabber.GetGrabTarget().position;
        transform.parent = _grabber.GetGrabTarget();
        _isGrabbed = true;
        rb.linearVelocity = Vector2.zero;
    }
    public void Die()
    {
        // play explosion? 
        boom.Play();
        Destroy(gameObject, 0.2f);
    }
    public float Eaten()
    {
        Die();
        if (!eaten)
        {
            eaten = true;
            return meatValue;
        }
        else return 0;
    }
    public void Target(JeffreyBezos bezos)
    {
        _bezos = bezos;
    }
}
