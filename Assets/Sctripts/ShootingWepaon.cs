using System.Collections;
using UnityEngine;

public class ShootingWepaon : MonoBehaviour
{
    [SerializeField] private Bullet _prefabRigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _shootDelay;
    [SerializeField] private Target _target;

    public float Speed => _speed;
    public Target Target => _target;

    private void Start()
    {
        StartCoroutine(StartShooting());
    }

    private IEnumerator StartShooting()
    {
        WaitForSeconds delay = new WaitForSeconds(_shootDelay);

        while (enabled)
        {
            Vector3 shootDiretion = (_target.transform.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_prefabRigidbody, transform.position + shootDiretion, Quaternion.identity);

            newBullet.Initialize(shootDiretion, _speed);

            yield return delay;
        }
    }
}