using System;
using UnityEngine;
using UnityEngine.AI;

public class CharactorMover
{
    private NavMeshAgent _agent;
    private Transform _target;
    private Transform _this;
    private float _distance = 3f;
    private Vector3 _lastTargetPos;
    private float _speed = 3f;
    private float _currentSpeed = 0f;
    private float _decelerateRate = 3f;
    public event Action<float> ChangeSpeed;

    public CharactorMover(NavMeshAgent agent, Transform target, Transform _this)
    {
        _agent = agent;
        _target = target;
        this._this = _this;
    }

    public void Update()
    {
        Move();
    }

    private float DistanceToTarget()
    {
        return Vector3.Distance(_target.position, _agent.transform.position);
    }

    private void Move()
    {
        if (DistanceToTarget() > _agent.stoppingDistance)
        {
            _currentSpeed = Mathf.Lerp(_currentSpeed, _speed, Time.deltaTime * _decelerateRate);
            if (_lastTargetPos != _target.position)
            {
                _agent.SetDestination(_target.position);
                _lastTargetPos = _target.position;
            }
        }
        else
        {
            _currentSpeed = Mathf.Lerp(_currentSpeed, 0f,
                Time.deltaTime * _decelerateRate);
        }

        _agent.speed = _currentSpeed;
        ChangeSpeed?.Invoke(_currentSpeed);
    }
}