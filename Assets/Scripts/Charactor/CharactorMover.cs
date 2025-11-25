using System.Data;
using UnityEngine;
using UnityEngine.AI;

public class CharactorMover
{
    private NavMeshAgent _agent;
    private Transform _target;
    private Transform _this;
    private float _distance = 3f;
    private Vector3 _lastTargetPos;

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
            if (_lastTargetPos != _target.position)
            {
                _agent.SetDestination(_target.position);
                _lastTargetPos = _target.position;
            }
        }
        else
        {
            Debug.Log("最も近い距離まで歩きました。");
        }
    }
}