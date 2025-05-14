using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(Vector3 diretion, float speed)
    {
        transform.up = diretion;
        _rigidbody.linearVelocity = speed * diretion;
    }
}
