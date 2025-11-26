using System;
using UnityEngine;
[DefaultExecutionOrder(-1000)]
public class GameManager : MonoBehaviour
{
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private PlayerManager  _playerManager;
    private EnemyContainer _enemyContainer;
    private void Awake()
    {
        _spawnManager.SetPlayerManeger(_playerManager);
        _enemyContainer = new EnemyContainer();
    }
}
