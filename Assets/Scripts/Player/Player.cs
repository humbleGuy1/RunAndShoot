using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _bullets;
    [SerializeField] private ParticleSystem _takeBulletEffect;
    [SerializeField] private BulletsGroup _bulletsGroup;

    public event UnityAction<int> BulletsChanged;
    public event UnityAction<int> DifferenceShowed;

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

    public void AddBullets(int value)
    {
        int difference = _bullets + value - _bullets;
        DifferenceShowed?.Invoke(difference);
        _bullets += value;
        BulletsChanged?.Invoke(_bullets);
        _bulletsGroup.MoveBullets(difference);
    }

    public void MultiplyBullets(int value)
    {
        int difference = _bullets * value - _bullets;
        DifferenceShowed?.Invoke(difference);
        _bullets *= value;
        BulletsChanged?.Invoke(_bullets);
        _bulletsGroup.MoveBullets(difference);
    }

    public void SpendBullet()
    {
        _bullets--;
        BulletsChanged?.Invoke(_bullets);
        _bulletsGroup.HideBullet();
    }

    public void ActivateTakeBulletEffect()
    {
        _takeBulletEffect.Play();
    }
}
