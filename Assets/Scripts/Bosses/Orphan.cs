using UnityEngine;

public class Orphan : MonoBehaviour, IBombable
{
    private JeffreyBezos _bezos;
    private float speed;
    private Rigidbody2D rb;
    [SerializeField] private Vector2 spawnHalfExtent;
    [SerializeField] private Vector2 spawnOffset;
    [SerializeField] private float approchRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(Random.Range(-spawnHalfExtent.x, spawnHalfExtent.x) + spawnOffset.x, Random.Range(-spawnHalfExtent.y, spawnHalfExtent.y) + spawnOffset.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_bezos != null)
        {
            if ((_bezos.transform.position - transform.position).magnitude <= approchRange)
            rb.linearVelocity = speed * (_bezos.transform.position - transform.position).normalized;
        }
    }
    public void OnBomb()
    {
        Die();
    }
    public void Die()
    {
        // play explosion? 
    }
    public void Target(JeffreyBezos bezos)
    {
        _bezos = bezos;
    }
}
