using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Mover))]

public class StateSwitcher : MonoBehaviour
{
    [SerializeField] private Turret _turret;
    [SerializeField] private TurretController _turretController;

    public event UnityAction CameraSwithed;

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
        CameraSwithed?.Invoke();
    }

    private void SwitchToRunning()
    {

    }
}
