using UnityEngine;
using UnityEngine.UI;

public class BulletCounterMover : MonoBehaviour
{
    [SerializeField] private StateSwitcher _stateSwitcher;
    [SerializeField] private Image _counter;
    [SerializeField] private RectTransform _targetPoint;
    
    private RectTransform _startPoint;

    private void Start()
    {
        _startPoint.position = _counter.rectTransform.position;
    }

    private void OnMoveDown()
    {
        _counter.rectTransform.position = _targetPoint.position;
    }

    private void OnMoveUp()
    {
        _counter.rectTransform.position = _startPoint.position;
    }

    private void OnEnable()
    {
        _stateSwitcher.BulletCounterMoveDown += OnMoveDown;
        _stateSwitcher.BulletCounterMoveUp += OnMoveUp;
    }

    private void OnDisable()
    {
        _stateSwitcher.BulletCounterMoveDown -= OnMoveDown;
        _stateSwitcher.BulletCounterMoveUp -= OnMoveUp;
    }
}