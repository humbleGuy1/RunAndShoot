using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Turret : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _shotEffect;
    [SerializeField] private AudioSource _shotSound;

    private Animator _animator;
    private float _timer;
    private const string RotateBarel = "RotateBarel";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _timer = _spawnDelay;   
    }

    private void Update()
    {
        if(_player.Bullets > 0)
        {
            if (_timer >= _spawnDelay)
            {
                Shoot();
                _timer = 0;
            }

            _timer += Time.deltaTime;
        }
    }

    private void Shoot()
    {
        Instantiate(_bulletPrefab,_firePoint.position, _firePoint.rotation);
        _animator.Play(RotateBarel);
        _shotEffect.Play();
        _shotSound.Play();
        _player.SpendBullet();
    }
}
