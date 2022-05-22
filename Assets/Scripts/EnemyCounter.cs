using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections.Generic;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentEnemies;
    [SerializeField] private StateSwitcher _stateSwitcher;
    [SerializeField] private Gate _gate;
    [SerializeField] private bool _toRunningState;
    [SerializeField] private bool _toDancingState;

    private Enemy[] _enemiesArray;
    private List<Enemy> _enemiesList;

    private void Start()
    {
        _enemiesArray = FindObjectsOfType<Enemy>();
        _enemiesList = _enemiesArray.OfType<Enemy>().ToList();
        _currentEnemies.text = _enemiesList.Count.ToString();

        foreach (var enemy in _enemiesList)
        {
            enemy.Dead += OnEnemyDead;
        }
    }

    private void OnEnemyDead()
    {
        for (int i = 0; i < _enemiesList.Count; i++)
        {
            if (_enemiesList[i].IsDead)
            {
                _enemiesList.Remove(_enemiesList[i]);
            }
        }

        _currentEnemies.text = _enemiesList.Count.ToString();

        if(_enemiesList.Count == 0)
        {
            if (_toRunningState)
            {
                _stateSwitcher.SwitchToRunning();
            }

            if (_toDancingState)
            {
                _stateSwitcher.SwitchToDancing();
            }

            _gate.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
