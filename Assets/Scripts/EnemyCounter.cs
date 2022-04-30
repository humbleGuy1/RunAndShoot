using UnityEngine;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentEnemies;
    [SerializeField] private StateSwitcher _stateSwitcher;
    [SerializeField] private Gate _gate;

    private Enemy[] _enemies;

    private void Update()
    {
        _enemies = FindObjectsOfType<Enemy>();
        _currentEnemies.text = _enemies.Length.ToString();

        if(_enemies.Length <= 1)
        {
            _stateSwitcher.SwitchToRunning();
            _gate.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
