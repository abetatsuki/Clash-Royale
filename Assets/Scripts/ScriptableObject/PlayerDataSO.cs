using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player Data")]
public class PlayerDataSO : ScriptableObject
{
  public int Mana;
  public int Level;
  public int MaxHealth;
}
