using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(ColorChanger))]
[RequireComponent(typeof(CapsuleCollider))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bloodExplosion;
    [SerializeField] private ParticleSystem _bloodPuddle;

    private bool _isDead;
    private Body _body;
    private Animator _animator;
    private EnemyMover _enemyMover;
    private ColorChanger _colorChanger;
    private CapsuleCollider _collider;
    private const string Death = "Death";

    public bool IsDead => _isDead;

    public event UnityAction Dead;

    private void Start()
    {
        _isDead = false;
        _body = GetComponentInChildren<Body>();
        _animator = GetComponent<Animator>();
        _enemyMover = GetComponent<EnemyMover>();
        _colorChanger = GetComponent<ColorChanger>();
        _collider = GetComponent<CapsuleCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Bullet _))
        {
            _enemyMover.enabled = false;
            _collider.enabled = false;
            _isDead = true;
            Dead?.Invoke();
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        var waitForSeconds = new WaitForSeconds(1f);
        
        _animator.Play(Death);
        _bloodExplosion.Play();
        _bloodPuddle.Play();
        _colorChanger.Change();

        yield return waitForSeconds;

        _body.gameObject.SetActive(false);

        yield return waitForSeconds;

        Destroy(gameObject);
    }
}
