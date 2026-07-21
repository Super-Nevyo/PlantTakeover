using System.Collections;
using UnityEngine;

public class BezosMisslie : MonoBehaviour
{
    private GameObject _target;
    [SerializeField] float _targetTime;
    private float step = 0;
    [SerializeField] float speed;
    [SerializeField] float rotatespeed;
    [SerializeField] float explodeAfter;
    [SerializeField] float explosionSize;
    [SerializeField] float timeAfterBeep;
    [SerializeField] ParticleSystem particles;
    private Collider2D[] _hits;

    public void SelectTarget(GameObject target)
    {
        _target = target;
    }
    void Start()
    {
        StartCoroutine(ExplodeAfter(explodeAfter));
    }
    void FixedUpdate()
    {
        if (_target == null) step = _targetTime;
        if (step < _targetTime)
        {
            step += Time.fixedDeltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(_target.transform.position.y - transform.position.y, _target.transform.position.x - transform.position.x) * Mathf.Rad2Deg), rotatespeed * Time.fixedDeltaTime);
        }
        //Debug.Log(Mathf.Atan2(_target.transform.position.x - transform.position.x, _target.transform.position.y - transform.position.y) * Mathf.Rad2Deg);
        transform.position += Time.fixedDeltaTime * speed * transform.right;
    }
    private IEnumerator Explode()
    {
        
        // maybe play beep sfx
        yield return new WaitForSeconds(timeAfterBeep);
        particles.Play();
        _hits = Physics2D.OverlapCircleAll(transform.position, explosionSize, LayerMask.GetMask("Player","Orphan"));
        foreach (var hit in _hits)
        {
            hit.GetComponent<IBombable>()?.OnBomb();
        }

        Destroy(gameObject, timeAfterBeep);
    }
    private IEnumerator ExplodeAfter(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Explode());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (step < _targetTime)
            StartCoroutine(Explode());
    }
}
