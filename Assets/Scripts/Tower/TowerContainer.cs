using System.Collections.Generic;
using UnityEngine;

public class TowerContainer
{
    public IReadOnlyList<TowerManager> TowerList => _towerList;
    private List<TowerManager> _towerList = new List<TowerManager>();
    public void AddTower(TowerManager tower)
    {
        _towerList.Add(tower);
    }

    public void RemoveTower(TowerManager tower)
    {
        _towerList.Remove(tower);
    }
}
