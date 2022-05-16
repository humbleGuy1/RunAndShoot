using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Mover))]

public class StateSwitcher : MonoBehaviour
{
    [SerializeField] private Turret _turret;
    [SerializeField] private TurretController _turretController;
    [SerializeField] private BulletsGroup _bulletsCounter;
    [SerializeField] private Image _bulletCounter;
    [SerializeField] private Confetti _confetti;

    private Mover _mover;
    
    public event UnityAction CameraSwithedToShooting;
    public event UnityAction CameraSwithedToRunning;
    public event UnityAction CameraSwithedToDancing;

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

    public void SwitchToRunning()
    {
        Debug.Log("SwitchedToRunning");
        _mover.ResetPositionX();
        _mover.enabled = true;
        _mover.JumpAfterShooting();
        _turret.enabled = false;
        _turretController.enabled = false;
        CameraSwithedToRunning?.Invoke();
        BulletCounterMoveUp?.Invoke();
    }

    public void SwitchToDancing()
    {
        Debug.Log("SwitchedToDancing");
        _mover.ResetPositionX();
        _mover.StartDancing();
        _turret.enabled = false;
        _turretController.enabled = false;
        _turret.gameObject.SetActive(false);
        _bulletsCounter.gameObject.SetActive(false);
        _bulletCounter.gameObject.SetActive(false);
        _confetti.gameObject.SetActive(true);
        CameraSwithedToDancing?.Invoke();
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
}
