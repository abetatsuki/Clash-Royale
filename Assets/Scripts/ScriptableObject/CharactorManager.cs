using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class CharactorManager : MonoBehaviour
{
    [SerializeField] private CharacterStatus _characterStatus;
    private CharactorMover _mover;
    private NavMeshAgent _agent;
    private Transform _this;
    private Transform _target;
    private AnimatorController _animatorController;

    private void Awake()
    {
        _animatorController = GetComponentInChildren<AnimatorController>();
        _agent = GetComponent<NavMeshAgent>();
        _this = transform;
        _target = GameObject.Find("target").transform;
        _mover = new CharactorMover(_agent, _target, _this);
    }

    private void Update()
    {
        _mover.Update();
    }
}