using UnityEngine;
using UnityEngine.UI;

public class CharactorMover
{
    private Rigidbody _rb;
    private Transform _target;
    private Transform _this;

    public CharactorMover(Rigidbody rb, Transform target, Transform _this)
    {
        _rb = rb;
        _target = target;
        this._this = _this;
    }

    public void Update()
    {
        Move();
    }

    private float DistanceToTarget()
    {
        return Vector3.Distance(_target.position, _rb.position);
    }

    private void Move()
    {
        float distance = DistanceToTarget();
        Vector3 direction = (_target.position - _rb.position).normalized;
        _rb.linearVelocity = direction * 3f;
    }
}