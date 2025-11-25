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
    private Animator _animator;
    private AnimationCon _animCon;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _this = transform;
        _target = GameObject.Find("target").transform;
        _mover = new CharactorMover(_agent, _target, _this);
        _animCon = new AnimationCon(_animator, _mover);
    }

    private void Update()
    {
        _mover.Update();
    }
}