using UnityEngine;

public class BlueSquare : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.MultiplyBullets(_value);
            Destroy(gameObject);
        }
    }
}
