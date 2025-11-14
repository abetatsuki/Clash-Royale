using UnityEngine;
/// <summary>
/// カードの生成の時に使うデータクラス
/// </summary>
[CreateAssetMenu(fileName = "Card", menuName = "Game/Card")]
public class CardSO : ScriptableObject
{
    public string CardName;
    public GameObject UnitPrefab;      // 実体プレハブ
    public GameObject UnitGhostPrefab; // ゴーストプレハブ（プレビュー）
    public int ManaCost;
    public float Cooldown;            // 置いた後のクールダウン（秒）
    public bool CanPlaceOnEnemySide = false; // 右側/左側判定などに使う
    public Color Color;
    public Sprite Icon;
}
