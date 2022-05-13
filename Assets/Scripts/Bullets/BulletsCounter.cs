using System.Collections.Generic;
using UnityEngine;

public class BulletsCounter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<MovingBullet> _bullets;

    private void Start()
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
}
