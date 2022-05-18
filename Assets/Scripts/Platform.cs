using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player _))
        {
            _effect.Play();
        }
    }
}
