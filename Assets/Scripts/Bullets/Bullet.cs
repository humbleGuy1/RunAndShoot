using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _selfDestructionTimeInSeconds;

    private float _elapsedTime;

    private void Start()
    {
        _elapsedTime = 0;    
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward, Space.Self);

        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _selfDestructionTimeInSeconds)
            Destroy(gameObject);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Destroy(gameObject);
    //}
}
