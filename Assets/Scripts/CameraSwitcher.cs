using Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _playerCamera;
    [SerializeField] private CinemachineVirtualCamera _turretCamera;
    [SerializeField] private StateSwitcher _stateSwitcher;

    private void OnCameraSwithed()
    {
        _playerCamera.Priority = 0;
        _turretCamera.Priority = 1;
    }

    private void OnEnable()
    {
        _stateSwitcher.CameraSwithed += OnCameraSwithed;
    }

    private void OnDisable()
    {
        _stateSwitcher.CameraSwithed -= OnCameraSwithed;
    }
}
