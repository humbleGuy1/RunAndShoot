using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _selfDestructionTimeInSeconds;
    [SerializeField] private int _maxHitCountsBeforeSelfDestruction;

    private float _elapsedTime;
    private int _hitCount;

    private void Start()
    {
        _elapsedTime = 0;
        _hitCount = 0;
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward, Space.Self);

        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _selfDestructionTimeInSeconds)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _hitCount++;

        if(_hitCount >= _maxHitCountsBeforeSelfDestruction)
        {
            Destroy(gameObject);
        }
    }
}
