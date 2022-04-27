using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyMover))]

public class Enemy : MonoBehaviour
{
    private Animator _animator;
    private EnemyMover _enemyMover;
    private const string Death = "Death";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        var waitForSeconds = new WaitForSeconds(2f);

        _enemyMover.enabled = false;
        _animator.Play(Death);

        yield return waitForSeconds;

        Destroy(gameObject);
    }
}
