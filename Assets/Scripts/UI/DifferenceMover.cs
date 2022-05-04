using UnityEngine;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(TMP_Text))]

public class DifferenceMover : MonoBehaviour
{
    [SerializeField] private DifferenceShower _differenceShower;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _fadeDuration;
    
    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnDifferenceMoved()
    {
        transform.DOMoveY(_targetPoint.position.y, _moveDuration);
        _text.DOFade(0, _fadeDuration);
    }

    private void OnEnable()
    {
        _differenceShower.DifferenceMoved += OnDifferenceMoved;
    }

    private void OnDisable()
    {
        _differenceShower.DifferenceMoved -= OnDifferenceMoved;
    }
}
