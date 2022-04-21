using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _approachSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ExtraCollider collider))
        {
            StartCoroutine(MoveToPlayer());
        }

        if (other.TryGetComponent(out Player player))
        {
            player.AddBullet();
            Destroy(gameObject);
        }
    }

    private IEnumerator MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _approachSpeed * Time.deltaTime);
        yield return null;
    }
}
