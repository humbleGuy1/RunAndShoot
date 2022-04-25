using Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _playerCamera;
    [SerializeField] private CinemachineVirtualCamera _turretCamera;
    [SerializeField] private StateSwitcher _stateSwitcher;

    private void OnCameraSwithedToShooting()
    {
        _playerCamera.Priority = 0;
        _turretCamera.Priority = 1;
    }

    private void OnCameraSwithedToRunning()
    {
        _playerCamera.Priority = 1;
        _turretCamera.Priority = 0;
    }

    private void OnEnable()
    {
        _stateSwitcher.CameraSwithedToShooting += OnCameraSwithedToShooting;
        _stateSwitcher.CameraSwithedToRunning += OnCameraSwithedToRunning;
    }

    private void OnDisable()
    {
        _stateSwitcher.CameraSwithedToShooting -= OnCameraSwithedToShooting;
        _stateSwitcher.CameraSwithedToRunning -= OnCameraSwithedToRunning;
    }
}
