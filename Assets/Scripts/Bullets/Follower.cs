using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _value;
    [SerializeField] private float _offsetY;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_target.transform.position.x,
            _target.transform.position.y + _offsetY, _target.transform.position.z), _value * Time.deltaTime);
    }
}
