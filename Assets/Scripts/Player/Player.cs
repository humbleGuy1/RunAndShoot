using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _bullets;

    public event UnityAction<int> BulletsChanged;

    public int Bullets => _bullets;

    private void Start()
    {
        BulletsChanged?.Invoke(_bullets);
    }
    public void AddBullet()
    {
        _bullets++;
        BulletsChanged?.Invoke(_bullets);
    }

    public void SpendBullet()
    {
        _bullets--;
        BulletsChanged?.Invoke(_bullets);
    }
}
