using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _rotationdDegree;
    [SerializeField] private float _rotationdDuration;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private const string Jumping = "Jumping";
    private const string Dancing = "Dancing";
 
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
        _rigidbody.AddForce(Vector3.forward + Vector3.up * _jumpForce, ForceMode.Impulse);
        _animator.Play(Jumping);
    }

    public void ResetPositionX()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }

    public void StartDancing()
    {
        _animator.Play(Dancing);
    }

    private void Move()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed/4 * Time.deltaTime * Vector3.left, Space.World);
            RotateY(-_rotationdDegree);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed/4 * Time.deltaTime * Vector3.right, Space.World);
            RotateY(_rotationdDegree);
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            RotateY(0);
        }
    }

    private void RotateY(float degree)
    {
        transform.DORotate(new Vector3(0, degree, 0), _rotationdDuration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Platform _))
        {
            Jump();
        }
    }
}
