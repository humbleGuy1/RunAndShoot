using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForceAfterShooting;
    [SerializeField] private float _jumpForcePlatform;
    [SerializeField] private float _rotationdDegree;
    [SerializeField] private float _rotationdDuration;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private bool _isOnGround;
    private const string Dancing = "Dancing";
    private const string IsOnGround = "IsOnGround";
 
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        _animator.SetBool(IsOnGround, _isOnGround);
    }

    public void JumpAfterShooting()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForceAfterShooting, ForceMode.Impulse);
        _isOnGround = false;
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

    private void JumpAfterSteppingOnplatform()
    {
        _rigidbody.AddForce(Vector3.forward + Vector3.up * _jumpForcePlatform, ForceMode.Impulse);
        _isOnGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Platform _))
        {
            JumpAfterSteppingOnplatform();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Ground _))
        {
            _isOnGround = true;
        }
    }
}
