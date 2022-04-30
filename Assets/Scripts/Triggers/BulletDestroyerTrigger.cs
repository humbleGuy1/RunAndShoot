using UnityEngine;

public class BulletDestroyerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Bullet bullet))
        {
            Destroy(bullet.gameObject);
        }
    }
}
