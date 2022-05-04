using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _text.gameObject.SetActive(true);
        }
    }
}
