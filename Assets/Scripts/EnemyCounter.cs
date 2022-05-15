using UnityEngine;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentEnemies;
    [SerializeField] private StateSwitcher _stateSwitcher;
    [SerializeField] private Gate _gate;
    [SerializeField] private bool _toRunningState;
    [SerializeField] private bool _toDancingState;

    private Enemy[] _enemies;

    private void Update()
    {
        _enemies = FindObjectsOfType<Enemy>();
        _currentEnemies.text = _enemies.Length.ToString();

        if(_enemies.Length <= 1)
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
