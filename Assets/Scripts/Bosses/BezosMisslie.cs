using System.Collections;
using System.Security.Cryptography;
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
    private RaycastHit2D[] _hits;

    public void SelectTarget(GameObject target)
    {
        _target = target;
    }
    void Start()
    {

    }
    void FixedUpdate()
    {
        if (_target != null) step = _targetTime;
        if (step < _targetTime)
        {
            step += Time.fixedDeltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(transform.position.x-_target.transform.position.x,transform.position.y-_target.transform.position.y) * Mathf.Rad2Deg), rotatespeed * Time.fixedDeltaTime);
        }
        transform.position += Time.fixedDeltaTime * speed * Vector3.up;
    }
    private IEnumerator Explode()
    {
        
        // maybe play beep sfx
        yield return new WaitForSeconds(timeAfterBeep);
        particles.Play();
        _hits = Physics2D.CircleCastAll(transform.position, explosionSize, Vector2.up, 0.1f, LayerMask.GetMask("player"));
        foreach (var hit in _hits)
        {
            hit.collider.GetComponent<IBombable>()?.OnBomb();
        }
    }
    private IEnumerator ExplodeAfter(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Explode());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(Explode());
    }
}
