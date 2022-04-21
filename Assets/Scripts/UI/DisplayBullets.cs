using UnityEngine;
using UnityEngine.UI;

public class DisplayBullets : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _currentBullets;

    private void OnBulletsChanged(int value)
    {
        _currentBullets.text = value.ToString();
    }

    private void OnEnable()
    {
        _player.BulletsChanged += OnBulletsChanged;
    }

    private void OnDisable()
    {
        _player.BulletsChanged -= OnBulletsChanged;
    }
}
