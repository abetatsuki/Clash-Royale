using System;
using UnityEngine;

[DefaultExecutionOrder(-1000)]
public class PlayerManager : MonoBehaviour
{
    private ManaEntity _manaEntity;
    [SerializeField] private PlayerDataSO _playerDataSO;
    private HealthEntity _healthEntity;
    public ManaEntity ManaEntity => _manaEntity;

    public event Action<int, int> OnManaChanged
    {
        add => _manaEntity.OnManaChanged += value;
        remove => _manaEntity.OnManaChanged -= value;
    }

    private void Start()
    {
       
        _manaEntity.ManaCost(10);
       
        _manaEntity.Start();
    }

    public void Awake()
    {
        InitializeEntities();
    }

    private void InitializeEntities()
    {
        if (_manaEntity == null || _healthEntity == null)
        {
            _manaEntity = new ManaEntity(_playerDataSO.Mana, _playerDataSO.Level);
            _healthEntity = new HealthEntity(_playerDataSO.MaxHealth);
        }
    }
}