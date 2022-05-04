using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DifferenceShower : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _difference;

    public event UnityAction DifferenceMoved;

    private void OnDifferenceShowed(int value)
    {
        _difference.text = "+" + value.ToString();
        DifferenceMoved?.Invoke();
    }

    private void OnEnable()
    {
        _player.DifferenceShowed += OnDifferenceShowed;
    }

    private void OnDisable()
    {
        _player.DifferenceShowed -= OnDifferenceShowed;
    }
}
