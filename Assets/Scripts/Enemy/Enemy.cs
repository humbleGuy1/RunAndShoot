using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyMover))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private StateSwitcher _stateSwitcher;
    private Animator _animator;
    private EnemyMover _enemyMover;
    private const string Death = "Death";
    private bool _isDead;

    public bool IsDead => _isDead;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyMover = GetComponent<EnemyMover>();
        _isDead = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            _enemyMover.enabled = false;
            _isDead = true;
            _stateSwitcher.SwitchToRunning();
            Destroy(gameObject);

            //StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        var waitForSeconds = new WaitForSeconds(2f);
        
        _animator.Play(Death);

        yield return waitForSeconds;

        Destroy(gameObject);
    }
}
