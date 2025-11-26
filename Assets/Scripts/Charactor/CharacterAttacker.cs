using UnityEngine;

public class CharacterAttacker
{
    public CharacterAttacker(CharacterStatus characterStatus)
    {
        _characterStatus = characterStatus;
    }
   
    private CharacterStatus _characterStatus;

    private void Attack(IHitable target)
    {
        if(target == null) return;
        Debug.Log($"{_characterStatus.Name} attacks {target.gameObject.name} " +
            $"for {_characterStatus.AttackPower} damage.");
        target.TakeDamage(_characterStatus.AttackPower);
    }
}
