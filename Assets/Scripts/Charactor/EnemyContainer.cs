
using System.Collections.Generic;
public class EnemyContainer 
{
    public IReadOnlyList<CharacterManager> EnemyList => _enemyList;
    private List<CharacterManager> _enemyList = new List<CharacterManager>();
    public void AddEnemy(CharacterManager enemy)
    {
        _enemyList.Add(enemy);
    }
    public void RemoveEnemy(CharacterManager enemy)
    {
        _enemyList.Remove(enemy);
    }
}
