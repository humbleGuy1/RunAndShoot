using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsGroup : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<MovingBullet> _bullets;
    [SerializeField] private float _speed;
    [SerializeField] private float _movingDistanceZ;
    [SerializeField] private float _movingTime;

    private void Awake()
    {
        foreach(var bullet in _bullets)
        {
            bullet.gameObject.SetActive(false);        
        }  
    }

    private void Update()
    {
        for(int i = 0; i < _player.Bullets; i++)
        {
            _bullets[i].gameObject.SetActive(true);
        }
    }

    public void HideBullet()
    {
        _bullets[_player.Bullets].gameObject.SetActive(false);
    }

    public void MoveBullets(int value)
    {
        List<MovingBullet> bulletsToMove = new List<MovingBullet>();

        for(int i = _player.Bullets; i > _player.Bullets - value; i--)
        {
            bulletsToMove.Add(_bullets[i]);
        }

        foreach(var bullet in bulletsToMove)
        {
            bullet.transform.position = new Vector3(bullet.transform.position.x, bullet.transform.position.y, 
                bullet.transform.position.z - _movingDistanceZ);
            StartCoroutine(Moving(bullet));
        }
    }

    private IEnumerator Moving(MovingBullet bullet)
    {
        float timer = 0;

        while(timer <= _movingTime)
        {
            bullet.transform.Translate(_speed * Time.deltaTime * Vector3.forward, Space.World);
            timer += Time.deltaTime;

            yield return null;
        }
    }
}
