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

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
            OnDeath?.Invoke();
        }

        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
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
}