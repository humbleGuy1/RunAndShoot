using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private const string Jumping = "Jumping";
 
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _animator.Play(Jumping);
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }

    private void Move()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed/2 * Time.deltaTime * Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed/2 * Time.deltaTime * Vector3.right);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Platform _))
        {
            Jump();
        }
    }
}
