using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    private GameObject _currentPreview;
    private CardSO _currentCard;
    private bool _isValidPlacement;
    private int _currentMana;
    private int _currentMaxMana;
    private PlayerManager _playerManager;
    private ManaEntity _manaEntity;
    private bool _isGeneret = false;

    [Header("陣地設定")] [SerializeField] private float _playerTerritoryMaxZ = 0f; // プレイヤー陣地のZ座標上限
    [SerializeField] private float _playerTerritoryMinZ = 0f;
    [SerializeField] private float _playerTerritoryMaX = 0f;
    [SerializeField] private float _playerTerritoryMinX = 0f;

    public void SetPlayerManeger(PlayerManager player)
    {
        _playerManager = player;
    }

    public void SetMana(int currentMana, int currentMaxMana)
    {
        _currentMana = currentMana;
        _currentMaxMana = currentMaxMana;
    }


    private void Awake()
    {
        Instance = this;
        _playerManager.OnManaChanged += SetMana;
        _manaEntity = _playerManager.ManaEntity;
    }

    private void Update()
    {
        if (_currentPreview == null) return;

        FollowMouseByRay();
        CheckPlace();
    }

    public void StartPlacing(CardSO card)
    {
        if (!_isGeneret)
        {
        _currentCard = card;
        _currentPreview = Instantiate(card.UnitGhostPrefab);
        _isValidPlacement = false;
        _isGeneret = true;
            
        }
    }

    private void FollowMouseByRay()
    {
        _isValidPlacement = false;

        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        // Raycast が地面に当たらない
        if (!Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("Ground", "Bridge")))
            return;
     //   Debug.Log("HitX = " + hit.point.x);
        // 地面じゃない（斜面など）
        if (Vector3.Dot(hit.normal, Vector3.up) <= 0.9f)
            return;

        // プレビュー位置は常に ray のヒット位置へ
        _currentPreview.transform.position = hit.point;

        // Z が自陣外なら NG
        if (hit.point.z > _playerTerritoryMaxZ)
            return;
        if (hit.point.z < _playerTerritoryMinZ)
            return;
        // X が自陣外なら NG
        if (hit.point.x > _playerTerritoryMaX)
            return;
        if (hit.point.x < _playerTerritoryMinX)
            return;
        // ここまで通ればすべての条件を満たしている
        _isValidPlacement = true;
    }


    private void CheckPlace()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && _isValidPlacement)
        {
            Debug.Log(_currentMana);
            if (_currentMana > 0)
            {
                Instantiate(_currentCard.UnitPrefab,
                    _currentPreview.transform.position,
                    Quaternion.identity);

                Destroy(_currentPreview);
                _currentPreview = null;
                _currentCard = null;
                _manaEntity.ManaCost(1);
                _isGeneret = false;
            }
        }
    }
}