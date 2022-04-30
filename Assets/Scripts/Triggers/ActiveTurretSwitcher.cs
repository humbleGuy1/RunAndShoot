using UnityEngine;

public class ActiveTurretSwitcher : MonoBehaviour
{
    [SerializeField] private StateSwitcher _stateSwitcher1;
    [SerializeField] private StateSwitcher _stateSwitcher2;
    [SerializeField] private Turret _turret;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player _))
        {
            _stateSwitcher1.enabled = false;
            _stateSwitcher2.enabled = true;
            _turret.gameObject.SetActive(false);
        }
    }
}
