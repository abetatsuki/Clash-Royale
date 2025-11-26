using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class CharactorManager : MonoBehaviour, IHitable
{
    [SerializeField] private CharacterStatus _characterStatus;
    private CharactorMover _mover;
    private NavMeshAgent _agent;
    private Transform _this;
    private Transform _target;
    private Animator _animator;
    private AnimationCon _animCon;
    private HealthEntity _healthEntity;
    private CharacterAttacker _attacker;
    public void TakeDamage( int  damage) => _healthEntity.TakeDamage(damage);

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _this = transform;
        _target = GameObject.Find("target").transform;
        _healthEntity = new HealthEntity(100); 
        _mover = new CharactorMover(_agent, _target, _this);
        _animCon = new AnimationCon(_animator, _mover);
        _attacker = new CharacterAttacker(_characterStatus);
    }

    private void Update()
    {
        _mover.Update();
    }
}