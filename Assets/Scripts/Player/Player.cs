using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _bullets;

    public event UnityAction<int> BulletsChanged;

    public void AddBullet()
    {
        _bullets++;
        BulletsChanged?.Invoke(_bullets);
    }
}
