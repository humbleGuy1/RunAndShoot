using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _pushForce;
    [SerializeField] private Animator _playerAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            Rigidbody playerRigidBody = player.GetComponent<Rigidbody>();
            playerRigidBody.AddForce(Vector3.up * _pushForce, ForceMode.Impulse);
            _playerAnimator.Play("Jumping");
        }
    }
}
