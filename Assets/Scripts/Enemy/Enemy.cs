using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(ColorChanger))]
[RequireComponent (typeof(CapsuleCollider))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bloodExplosion;
    [SerializeField] private ParticleSystem _bloodPuddle;

    private Animator _animator;
    private EnemyMover _enemyMover;
    private ColorChanger _colorChanger;
    private CapsuleCollider _collider;
    private const string Death = "Death";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyMover = GetComponent<EnemyMover>();
        _colorChanger = GetComponent<ColorChanger>();
        _collider = GetComponent<CapsuleCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            _enemyMover.enabled = false;
            _collider.enabled = false;


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

        Destroy(gameObject);
    }
}
