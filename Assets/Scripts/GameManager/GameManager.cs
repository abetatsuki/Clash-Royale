using System;
using UnityEngine;
[DefaultExecutionOrder(-1000)]
public class GameManager : MonoBehaviour
{
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private PlayerManager  _playerManager;

    private void Awake()
    {
        _spawnManager.SetPlayerManeger(_playerManager);
    }
}
