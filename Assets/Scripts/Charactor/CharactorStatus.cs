using UnityEngine;
/// <summary>
/// キャラクターのステータスクラス。
/// </summary>
[CreateAssetMenu(
    menuName = "Character/Status",
    fileName = "CharacterStatus")]
public class CharacterStatus : ScriptableObject
{
    public string Name;
    public int MaxHp;
    public float MoveSpeed;
    public float AttackPower;
}