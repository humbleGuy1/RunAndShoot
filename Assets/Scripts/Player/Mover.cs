using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed/2 * Time.deltaTime * Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed/2 * Time.deltaTime * Vector3.right);
        }
    }
}
