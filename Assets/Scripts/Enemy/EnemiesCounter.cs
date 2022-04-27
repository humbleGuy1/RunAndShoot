using System.Collections.Generic;
using UnityEngine;

public class EnemiesCounter : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private StateSwitcher _stateSwitcher;
}
