using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Unity.Profiling.LowLevel.Unsafe;

public class ManaEntity
{
    private int _maxCurrentMana;
    private int _currentMana;
    public int CurrentMana => _currentMana;
    private int Level;
    private const int TestNumber = 1;
    private bool _isRunning = false;
    public event Action<int,int> OnManaChanged;
    
    public void Start()
    {
        OnManaChanged?.Invoke(CurrentMana, _maxCurrentMana);
        RunManaLoop().Forget();
    }

   
    public ManaEntity(int currentMana,int level)
    {
        _maxCurrentMana = currentMana;
        _currentMana = currentMana;
        Level = level;
    }

    public async UniTask RunManaLoop()
    {
        _isRunning = true;
        while (_isRunning)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            HealMana(TestNumber);
            OnManaChanged?.Invoke(_currentMana,_maxCurrentMana);
        }
    }
    public void AddMana(int mana)
    {
        _maxCurrentMana += mana * Level;
    }

    public void HealMana(int mana)
    {
        _currentMana += mana;
        if (_maxCurrentMana < _currentMana)
        {
            _currentMana = _maxCurrentMana;
            _isRunning = false;
        }
        
        OnManaChanged?.Invoke(_currentMana,_maxCurrentMana);
    }
    public void ManaCost(int cost)
    {
        _currentMana -= cost;
        OnManaChanged?.Invoke(_currentMana,_maxCurrentMana);
    }
}
