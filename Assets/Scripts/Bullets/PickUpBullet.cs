using UnityEngine;
using System.Collections;

public class PickUpBullet : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _approachSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TakeBulletCollider _))
        {
            StartCoroutine(MoveToPlayer());
        }

        if (other.TryGetComponent(out DestroyBulletCollider _))
        {
            _player.AddBullet();
            Destroy(gameObject);
        }
    }

    private IEnumerator MoveToPlayer()
    {
        while(transform.position != _player.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _approachSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
