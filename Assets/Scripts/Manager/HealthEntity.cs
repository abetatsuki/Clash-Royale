using UnityEngine;
using System;

public class HealthEntity
{

    public HealthEntity(int maxhealth)
    {
        _currentHealth = maxhealth;
        _maxHealth = maxhealth;
    }

    public event Action<int, int> OnHealthChanged;
    public event Action OnDeath;
    public bool IsAlive => _isAlive;

    public void TakeDamage(int damage)
    {
        if (!_isAlive) return;
        
        _currentHealth =  Mathf.Max(_currentHealth - damage, 0);
        if (_currentHealth == 0)
        {
            _isAlive = false;
            OnDeath?.Invoke();
        }
       
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        Debug.Log(_currentHealth);
    }

    public void Heal(int amount)
    {
        _currentHealth += amount;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    private int _currentHealth;
    private readonly int _maxHealth;
    private bool _isAlive = true;
}