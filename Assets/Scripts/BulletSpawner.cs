using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _targetToShoot;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(SpawnJob());
    }

    IEnumerator SpawnJob()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        
        while (true)
        {
            Vector3 directionToTarget = (_targetToShoot.position - transform.position).normalized;
            
            Bullet bullet = Instantiate(_prefab, transform.position + directionToTarget, Quaternion.identity);

            bullet.Init(directionToTarget, _speed, _targetToShoot);

            yield return wait;
        }
    }
}