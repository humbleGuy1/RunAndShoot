using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Mover))]

public class StateSwitcher : MonoBehaviour
{
    [SerializeField] private Turret _turret;
    [SerializeField] private TurretController _turretController;

    private Mover _mover;
    
    public event UnityAction CameraSwithedToShooting;
    public event UnityAction CameraSwithedToRunning;

    public event UnityAction BulletCounterMoveDown;
    public event UnityAction BulletCounterMoveUp;

    private void Start()
    {
        _mover = GetComponent<Mover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out SwitchToShootingTrigger shootingTrigger))
        {
            SwitchToShooting();
            Destroy(shootingTrigger);
        }
    }

    private void SwitchToShooting()
    {
        Debug.Log("SwitchedToShooting");
        _mover.enabled = false;
        _turret.enabled = true;
        _turretController.enabled = true;
        CameraSwithedToShooting?.Invoke();
        BulletCounterMoveDown?.Invoke();
    }

    public void SwitchToRunning()
    {
        Debug.Log("SwitchedToRunning");
        _mover.ResetPosition();
        _mover.Jump();
        _mover.enabled = true;
        _turret.enabled = false;
        _turretController.enabled = false;
        CameraSwithedToRunning?.Invoke();
        BulletCounterMoveUp?.Invoke();
    }
}
