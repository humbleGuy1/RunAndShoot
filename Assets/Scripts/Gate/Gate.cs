using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private CameraMover _cameraMover;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if(player.Bullets > 0)
            {
                _cameraMover.Move();
            }

            _text.gameObject.SetActive(true);
        }
    }
}
