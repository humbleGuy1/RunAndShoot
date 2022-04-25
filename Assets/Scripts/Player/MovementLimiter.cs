using UnityEngine;

[RequireComponent(typeof(Player))]

public class MovementLimiter : MonoBehaviour
{

    [SerializeField] private float _sideBorder;

    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _player.transform.position = new Vector3(Mathf.Clamp(_player.transform.position.x, -_sideBorder, _sideBorder),
            transform.position.y, _player.transform.position.z);
    }
}
