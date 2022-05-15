using Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _playerCamera;
    [SerializeField] private CinemachineVirtualCamera _turretCamera;
    [SerializeField] private CinemachineVirtualCamera _danceCamera;
    [SerializeField] private StateSwitcher _stateSwitcher;

    private void OnCameraSwithedToShooting()
    {
        _playerCamera.Priority = 0;
        _turretCamera.Priority = 1;
        _danceCamera.Priority = 0;
    }

    private void OnCameraSwithedToRunning()
    {
        _playerCamera.Priority = 1;
        _turretCamera.Priority = 0;
        _danceCamera.Priority = 0;
    }

    private void OnCameraSwitchedToDancing()
    {
        _playerCamera.Priority = 0;
        _turretCamera.Priority = 0;
        _danceCamera.Priority = 1;
    }

    private void OnEnable()
    {
        _stateSwitcher.CameraSwithedToShooting += OnCameraSwithedToShooting;
        _stateSwitcher.CameraSwithedToRunning += OnCameraSwithedToRunning;
        _stateSwitcher.CameraSwithedToDancing += OnCameraSwitchedToDancing;
    }

    private void OnDisable()
    {
        _stateSwitcher.CameraSwithedToShooting -= OnCameraSwithedToShooting;
        _stateSwitcher.CameraSwithedToRunning -= OnCameraSwithedToRunning;
        _stateSwitcher.CameraSwithedToDancing += OnCameraSwitchedToDancing;
    }
}
