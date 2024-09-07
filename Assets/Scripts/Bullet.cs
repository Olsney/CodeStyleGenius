using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed;
    private Rigidbody _rigidbody;
    private Transform _target;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.LookAt(_target);

        Move();
    }
    
    public void Init(Vector3 direction, float speed, Transform targetToShoot)
    {
        _direction = direction;
        _speed = speed;
        _target = targetToShoot;
    }
    
    private void Move() =>
        _rigidbody.velocity = _direction * (_speed * Time.fixedTime);
}