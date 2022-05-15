using System.Collections.Generic;
using UnityEngine;

public class BulletsGroup : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<MovingBullet> _bullets;

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
}
