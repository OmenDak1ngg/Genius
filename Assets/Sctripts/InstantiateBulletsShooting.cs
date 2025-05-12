using System.Collections;
using UnityEngine;

public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _shootDelay;

    public float Speed => _speed;
    public Transform ObjectToShoot { get; private set; }

    void Start()
    {
        StartCoroutine(StartShooting());
    }

    private IEnumerator StartShooting()
    {
        bool isWorking = enabled;
        WaitForSeconds delay = new WaitForSeconds(_shootDelay);
        Rigidbody bulletRigidbody;

        while (isWorking)
        {
            var shootDiretion = (ObjectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_prefab, transform.position + shootDiretion, Quaternion.identity);

            if (newBullet.TryGetComponent(out bulletRigidbody))
            {
                bulletRigidbody.transform.up = shootDiretion;
                bulletRigidbody.linearVelocity = shootDiretion * _speed;
            }

            yield return delay;
        }
    }
}