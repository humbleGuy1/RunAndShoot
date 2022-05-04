using UnityEngine;
using DG.Tweening;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _duration;

    private Vector3 _targetLastPosition;
    private Tweener _tweenX;
    private Tweener _tweenZ;

    private void Start()
    {
       _tweenX = transform.DOMoveX(_target.position.x, _duration).SetAutoKill(false);
       _tweenZ = transform.DOMoveZ(_target.position.z, _duration).SetAutoKill(false);
       _targetLastPosition = _target.position;
    }

    private void Update()
    {
        if(_targetLastPosition != _target.position)
        {
            _tweenX.ChangeEndValue(_targetLastPosition, true).Restart();
            _tweenZ.ChangeEndValue(_targetLastPosition, true).Restart();
            _targetLastPosition = _target.position;
        }
    }
}
    