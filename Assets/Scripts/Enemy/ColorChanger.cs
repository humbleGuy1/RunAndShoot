using UnityEngine;
using DG.Tweening;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _renderer;
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _duration;

    public void Change()
    {
        _renderer.material.DOColor(_targetColor, _duration);
    }
}
