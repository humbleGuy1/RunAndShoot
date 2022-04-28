using UnityEngine;

public class RedSquare : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _value;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.AddBullets(_value);
            Destroy(gameObject);
        }
    }
}
