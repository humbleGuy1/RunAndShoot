using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Mover))]

public class StateSwitcher : MonoBehaviour
{
    [SerializeField] private Turret _turret;
    [SerializeField] private TurretController _turretController;

    public event UnityAction CameraSwithedToShooting;
    public event UnityAction CameraSwithedToRunning;

    public event UnityAction BulletCounterMoveDown;
    public event UnityAction BulletCounterMoveUp;

    private Mover _mover;

    private void Start()
    {
        _mover = GetComponent<Mover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Turret turret))
        {
            SwitchToShooting();
        }
    }

    private void SwitchToShooting()
    {
        _mover.enabled = false;
        _turret.enabled = true;
        _turretController.enabled = true;
        CameraSwithedToShooting?.Invoke();
        BulletCounterMoveDown?.Invoke();
    }

    private void SwitchToRunning()
    {
        _mover.enabled = true;
        _turret.enabled = false;
        _turretController.enabled = false;
        CameraSwithedToRunning?.Invoke();
        BulletCounterMoveUp?.Invoke();
    }
}
