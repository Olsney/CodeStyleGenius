using UnityEngine;

public class FollowerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;

    private readonly float _permittedDifference = 0.1f;
    private Transform[] _points;
    private int _currentPointIndex;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i);
    }
    
    public void FixedUpdate()
    {
        Transform target = _points[_currentPointIndex];

        LookAtTarget();

        transform.position =
            Vector3.MoveTowards(transform.position, target.position, _speed * Time.fixedTime);

        if ((transform.position - target.position).magnitude <= _permittedDifference)
            ChangePoint();
    }

    private void LookAtTarget()
    {
        Vector3 targetPosition = _points[_currentPointIndex].transform.position;

        transform.LookAt(targetPosition);
    }

    private void ChangePoint()
    {
        _currentPointIndex++;
        
        if (_currentPointIndex >= _points.Length)
            _currentPointIndex = 0;
    }
}