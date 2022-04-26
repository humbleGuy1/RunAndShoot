using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private float _mouseSense;
    [SerializeField] private float _rotationBorderY;

    private const string MouseX = "Mouse X";

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(0, Input.GetAxis(MouseX) * _mouseSense, 0);

        LimitRotation();
    }

    private void LimitRotation()
    {
        transform.rotation = new Quaternion(transform.rotation.x, Mathf.Clamp(transform.rotation.y, -_rotationBorderY, _rotationBorderY),
            transform.rotation.z, transform.rotation.w);
    }
}
