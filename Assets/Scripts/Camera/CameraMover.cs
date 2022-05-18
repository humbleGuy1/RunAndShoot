using Cinemachine;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _targetPosition;

    private CinemachineVirtualCamera _playerCamera;
    private CinemachineTransposer _transposer;

    private void Start()
    {
        _playerCamera = GetComponent<CinemachineVirtualCamera>();
        _transposer = _playerCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

    public void Move()
    {
        StartCoroutine(MoveBackAndForward(_startPosition, _targetPosition));
    }

    private IEnumerator MoveBackAndForward(Vector3 startPosition, Vector3 targetPosition)
    {
        while(_transposer.m_FollowOffset != targetPosition)
        {
            _transposer.m_FollowOffset = Vector3.MoveTowards(_transposer.m_FollowOffset, targetPosition, _speed * Time.deltaTime);
            
            yield return null;
        }

        var waitForSeconds = new WaitForSeconds(0.5f);

        yield return waitForSeconds;

        while (_transposer.m_FollowOffset != startPosition)
        {
            _transposer.m_FollowOffset = Vector3.MoveTowards(_transposer.m_FollowOffset, startPosition, _speed * Time.deltaTime);

            yield return null;
        }
    }

}
