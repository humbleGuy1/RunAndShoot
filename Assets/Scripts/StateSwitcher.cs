using UnityEngine;
using UnityEngine.Events;

public class StateSwitcher : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Mover _mover;
    [SerializeField] private Turret _turret;
    [SerializeField] private TurretController _turretController;

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
        _player.transform.position = new Vector3(0, _player.transform.position.y, _player.transform.position.z);
        _mover.enabled = true;
        _turret.enabled = false;
        _turretController.enabled = false;
        CameraSwithedToRunning?.Invoke();
        BulletCounterMoveUp?.Invoke();
    }
}
